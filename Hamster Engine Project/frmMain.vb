Option Strict Off
Imports System.Collections.Concurrent
Imports System.Drawing
Imports System.Dynamic
Imports System.Windows.Forms

Public Class frmMain
    Private thMessage As New Threading.Thread(AddressOf CheckMessage)
    Private MessageList As New ConcurrentBag(Of MavlinkMessage)
    Private LastestHeartbeatTime As New Dictionary(Of Integer, DateTime)
    Private Const heartbeatFailLimit As Integer = 5

    Private isAlertSituation As Boolean = False
    Private alertPlayer As New Media.SoundPlayer(Application.StartupPath & "\sound\alert.wav")
    Private isAlertSoundPlayed As Boolean = False

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtProgName.Text = Project.Version.GetName()
        Text = Project.Version.GetName()
        txtProgVer.Text = Project.Version.GetVersion(True)
        txtStatusExplain.Text = ""
        alertPlayer.Load()
        Init()

        Dim logdel = Sub(t As ConsoleMessageType, s As String)
                         PrintConsole(t, s)
                     End Sub
        Dim pushmsg = Sub(s As Integer, n As String, d As IronPython.Runtime.List)
                          PushMessage(s, n, d)
                      End Sub
        Dim proxy As Object = New ExpandoObject()
        proxy.LogWrite = logdel
        proxy.PushMessage = pushmsg
        commonScope.SetVariable("proxy", proxy)
    End Sub

    Private Sub btnReadNode_Click(sender As Object, e As EventArgs) Handles btnReadNode.Click
        Execute(EngineWrapper.EngineArgument.ApplicationStartupPath & "\script\initialization.py")
        PrintConsole(ConsoleMessageType.Info, "초기화 스크립트 실행 완료")
        CallFunction("makeNode", EngineWrapper.EngineArgument.ApplicationStartupPath & "\port.txt")
        PrintConsole(ConsoleMessageType.Info, "노트 초기화 스크립트 실행 완료")
        Dim noderes As IronPython.Runtime.List = CallFunction("getNodeSeqList").result
        txtStatusExplain.Text = "총 " & noderes.__len__ & "개의 노드 초기화 됨"
        lstNodeStatus.Items.Clear()
        For Each nownode In noderes
            Dim nowdata = CallFunction("getNodeData", nownode).result
            lstNodeStatus.Items.Add(New ListViewItem({nownode, nowdata(0), nowdata(1), "", "", "초기화"}))
        Next
        PrintConsole(ConsoleMessageType.Info, "노드 정보 얻어오기 완료")

        Execute(EngineWrapper.EngineArgument.ApplicationStartupPath & "\script\command.py")
        Dim cmdres As IronPython.Runtime.List = CallFunction("getCommandList").result
        txtCmdType.Items.Clear()
        For Each nowcmd In cmdres
            txtCmdType.Items.Add(nowcmd)
        Next
        txtCmdType.SelectedItem = txtCmdType.Items(0)
        txtCmdType_SelectedIndexChanged(Nothing, Nothing)
        PrintConsole(ConsoleMessageType.Info, "명령 리스트 얻어오기 완료")

        thMessage.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        EngineWrapper.EngineFunction.EFUNC_EngineShutdown.DynamicInvoke()
    End Sub

    Private Sub lstNodeStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNodeStatus.SelectedIndexChanged
        If lstNodeStatus.SelectedItems.Count > 0 Then
            Dim isFirstItem As Boolean = True
            txtTargetCustom.Text = ""
            For i As Integer = 0 To lstNodeStatus.SelectedItems.Count - 1
                If isFirstItem Then
                    txtTargetCustom.Text += lstNodeStatus.SelectedItems(i).Text
                    isFirstItem = False
                Else
                    txtTargetCustom.Text += " " & lstNodeStatus.SelectedItems(i).Text
                End If
            Next
        End If
    End Sub

    Private typeToString = {"DEBUG", "INFO", "WARNING", "CRITICAL", "ALERT"}
    Private typeToColor = {Color.LightGray, Color.White, Color.Yellow, Color.Red, Color.White}
    Public Sub PrintConsole(type As ConsoleMessageType, msg As String)
        If type = ConsoleMessageType.Alert Then isAlertSituation = True
        Dim nowRow = New ListViewItem({Now.ToString("HH:mm:ss"), typeToString(type), msg})
        nowRow.ForeColor = typeToColor(type)
        If type = ConsoleMessageType.Alert Then
            nowRow.BackColor = Color.DarkRed
        End If
        lstConsole.Items.Add(nowRow)
        lstConsole.EnsureVisible(lstConsole.Items.Count - 1)
    End Sub

    Public Enum ConsoleMessageType
        Debug = 0
        Info = 1
        Warning = 2
        Critical = 3
        Alert = 4
    End Enum

    Private Sub PrintPacketMonitor(isrecv As Boolean, msg As MavlinkMessage)
        Dim dir As String = IIf(isrecv, msg.SeqNumber.ToString & " →", msg.SeqNumber.ToString & " →")
        Dim nowRow = New ListViewItem({Now.ToString("HH:mm:ss"), dir, msg.Name, msg.Data(0)})
        lstPacket.Items.Add(nowRow)
        lstPacket.EnsureVisible(lstPacket.Items.Count - 1)
    End Sub

    Private Sub CheckMessage()
        Do While True
            For Each nowrow As ListViewItem In lstNodeStatus.Items
                CallFunction("read_message", Integer.Parse(nowrow.SubItems(0).Text))
            Next

            Do While MessageList.Count > 0
                Dim nowmsg As MavlinkMessage = Nothing
                MessageList.TryTake(nowmsg)
                If nowmsg Is Nothing Then Exit Do
                PrintPacketMonitor(True, nowmsg)

                If nowmsg.Name = "HEARTBEAT" Then
                    If LastestHeartbeatTime.ContainsKey(nowmsg.SeqNumber) Then
                        LastestHeartbeatTime(nowmsg.SeqNumber) = Now
                        GetRowbySeq(nowmsg.SeqNumber).SubItems(5).Text = CallFunction("getMavEnum", {"MAV_STATE", nowmsg.Data(1)}).result
                    Else
                        LastestHeartbeatTime.Add(nowmsg.SeqNumber, Now)
                    End If
                ElseIf nowmsg.Name = "STATUS_TEXT" Then
                    GetRowbySeq(nowmsg.SeqNumber).SubItems(5).Text = nowmsg.Data(1)
                ElseIf nowmsg.Name = "MISSION_ACK" Then
                    GetRowbySeq(nowmsg.SeqNumber).SubItems(4).Text = nowmsg.Data(1)
                End If
            Loop
        Loop
    End Sub

    Private Sub PushMessage(seq As Integer, name As String, data As IronPython.Runtime.List)
        MessageList.Add(New MavlinkMessage(seq, name, data))
    End Sub

    Private Sub txtCmdType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCmdType.SelectedIndexChanged
        If txtCmdType.SelectedIndex >= 0 Then
            Dim cmdres = CallFunction("getCommandExplain", txtCmdType.SelectedItem).result
            txtCmdTypeExplain.Text = cmdres
        End If
    End Sub

    Private Sub txtAlert_Click(sender As Object, e As EventArgs) Handles txtAlert.Click
        isAlertSituation = False
    End Sub

    Private Sub timAlert_Tick(sender As Object, e As EventArgs) Handles timAlert.Tick
        If isAlertSituation Then
            If Not isAlertSoundPlayed Then
                alertPlayer.PlayLooping()
                isAlertSoundPlayed = True
            End If
            txtAlert.Visible = Not txtAlert.Visible
        Else
            isAlertSoundPlayed = False
            txtAlert.Visible = False
            alertPlayer.Stop()
        End If
    End Sub

    Private Sub btnCmdImmdExe_Click(sender As Object, e As EventArgs) Handles btnCmdImmdExe.Click
        Dim targetNodeSeq() As String

        If btnTargetAll.Checked Then
            Dim tempList As New List(Of String)
            For Each nowRow As ListViewItem In lstNodeStatus.Items
                tempList.Add(nowRow.SubItems(0).Text)
            Next
            targetNodeSeq = tempList.ToArray
        Else
            Dim pNode = txtTargetCustom.Text.Split(" ")
            If pNode.Count = 0 Then
                Exit Sub
            Else
                targetNodeSeq = pNode
            End If
        End If

        For Each nowSeq In targetNodeSeq
            CallFunction(txtCmdType.SelectedItem, Integer.Parse(nowSeq))
            PrintConsole(ConsoleMessageType.Info, nowSeq & "번 노드에 '" & txtCmdType.SelectedItem & "' 명령 전송")
        Next
    End Sub

    Private Function GetRowbySeq(seqnum As Integer) As ListViewItem
        For Each nowrow As ListViewItem In lstNodeStatus.Items
            If Integer.Parse(nowrow.SubItems(0).Text) = seqnum Then
                Return nowrow
            End If
        Next
        Return Nothing
    End Function

    Private Sub timHeartbeat_Tick(sender As Object, e As EventArgs) Handles timHeartbeat.Tick
        If chkHeartbeat.Checked Then
            For Each nowrow As ListViewItem In lstNodeStatus.Items
                Dim nowseq = Integer.Parse(nowrow.SubItems(0).Text)
                If LastestHeartbeatTime.ContainsKey(nowseq) Then
                    Try
                        nowrow.BackColor = Color.Black
                        nowrow.ForeColor = Color.White

                        Dim difftime As TimeSpan = Now - LastestHeartbeatTime(nowseq)
                        If difftime.TotalSeconds < 2 Then
                            nowrow.SubItems(3).Text = "OK (" & difftime.TotalSeconds.ToString("00") & "초 전)"
                            nowrow.ForeColor = Color.LightGreen
                        Else
                            If difftime.TotalSeconds > heartbeatFailLimit Then
                                PrintConsole(ConsoleMessageType.Alert, "하트비트 수신 실패 한도 초과 (" & nowrow.SubItems(0).Text & "번 노드)")
                            End If
                            nowrow.SubItems(3).Text = "FAIL (" & difftime.TotalSeconds.ToString("00") & "초 전)"
                            nowrow.BackColor = Color.DarkRed
                        End If
                    Catch ex As Exception
                        nowrow.SubItems(3).Text = "ERROR"
                        nowrow.ForeColor = Color.Yellow
                        PrintConsole(ConsoleMessageType.Critical, nowrow.SubItems(0).Text & "번 노드 하트비트 스크립트 실행중 오류 → " & ex.Message)
                    End Try
                Else
                    LastestHeartbeatTime.Add(nowseq, Now)
                End If
            Next
            txtStatusExplain.Text = "마지막 체크 : " & Now.ToString
        End If
    End Sub

    Private Sub lstPacket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPacket.SelectedIndexChanged
        If lstPacket.SelectedItems.Count > 0 Then
            txtPacketDetail.Text = lstPacket.SelectedItems(0).SubItems(3).Text
        End If
    End Sub

    Private Class MavlinkMessage
        Public Sub New(seq As Integer, mname As String, mdata As IronPython.Runtime.List)
            SeqNumber = seq
            Name = mname
            Data = mdata
        End Sub

        Public SeqNumber As Integer
        Public Name As String
        Public Data As IronPython.Runtime.List
    End Class
End Class