Option Strict Off
Imports System.Drawing
Imports System.Dynamic
Imports System.Windows.Forms

Public Class frmMain
    Private thHeartbeat As New Threading.Thread(AddressOf CheckHeartbeat)

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtProgName.Text = Project.Version.GetName()
        Text = Project.Version.GetName()
        txtProgVer.Text = Project.Version.GetVersion(True)
        txtStatusExplain.Text = ""
        alertPlayer.Load()
        Init()

        Dim logdel = Sub(s As String)
                         MsgBox(s)
                     End Sub
        Dim proxy As Object = New ExpandoObject()
        proxy.LogWrite = logdel
        commonScope.SetVariable("proxy", proxy)
    End Sub

    Private Sub btnReadNode_Click(sender As Object, e As EventArgs) Handles btnReadNode.Click
        Execute(Engine.ApplicationStartupPath & "\script\initialization.py")
        PrintConsole(ConsoleMessageType.Info, "초기화 스크립트 실행 완료")
        CallFunction("makeNode", Engine.ApplicationStartupPath & "\port.txt")
        PrintConsole(ConsoleMessageType.Info, "노트 초기화 스크립트 실행 완료")
        Dim noderes As IronPython.Runtime.List = CallFunction("getNodeSeqList").result
        txtStatusExplain.Text = "총 " & noderes.__len__ & "개의 노드 초기화 됨"
        lstNodeStatus.Items.Clear()
        For Each nownode In noderes
            Dim nowdata = CallFunction("getNodeData", nownode).result
            lstNodeStatus.Items.Add(New ListViewItem({nownode, nowdata(0), nowdata(1), "초기화"}))
            heartbeatFailCount.Add(nownode, 0)
        Next
        PrintConsole(ConsoleMessageType.Info, "노드 정보 얻어오기 완료")

        Execute(Engine.ApplicationStartupPath & "\script\command.py")
        Dim cmdres As IronPython.Runtime.List = CallFunction("getCommandList").result
        txtCmdType.Items.Clear()
        For Each nowcmd In cmdres
            txtCmdType.Items.Add(nowcmd)
        Next
        txtCmdType.SelectedItem = txtCmdType.Items(0)
        txtCmdType_SelectedIndexChanged(Nothing, Nothing)
        PrintConsole(ConsoleMessageType.Info, "명령 리스트 얻어오기 완료")

        thHeartbeat.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Engine.EFUNC_EngineShutdown.DynamicInvoke()
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

    Private heartbeatFailCount As New Dictionary(Of Integer, Integer)
    Private Const heartbeatFailLimit As Integer = 3
    Private Sub CheckHeartbeat()
        Do While True
            If chkHeartbeat.Checked Then
                For Each nowrow As ListViewItem In lstNodeStatus.Items
                    Try
                        nowrow.BackColor = Color.Black
                        nowrow.ForeColor = Color.White
                        Dim nowseq = Integer.Parse(nowrow.SubItems(0).Text)
                        Dim heartres = CallFunction("getHeartbeat", nowseq).result
                        If heartres Then
                            nowrow.SubItems(3).Text = "OK"
                            nowrow.ForeColor = Color.LightGreen
                            heartbeatFailCount(nowseq) = 0
                        Else
                            nowrow.ForeColor = Color.Red
                            heartbeatFailCount(nowseq) += 1
                            If heartbeatFailCount(nowseq) > heartbeatFailLimit Then
                                PrintConsole(ConsoleMessageType.Alert, "하트비트 수신 실패 한도 초과 (" & nowrow.SubItems(0).Text & "번 노드)")
                                nowrow.SubItems(3).Text = "FAIL *"
                                nowrow.BackColor = Color.DarkRed
                            Else
                                PrintConsole(ConsoleMessageType.Critical, "하트비트 수신 실패 (" & nowrow.SubItems(0).Text & "번 노드)")
                                nowrow.SubItems(3).Text = "FAIL (" & heartbeatFailCount(nowseq).ToString & ")"
                            End If
                        End If
                    Catch ex As Exception
                        nowrow.SubItems(3).Text = "ERROR"
                        nowrow.ForeColor = Color.LightYellow
                        PrintConsole(ConsoleMessageType.Critical, nowrow.SubItems(0).Text & "번 노드 하트비트 스크립트 실행중 오류 → " & ex.Message)
                    Finally
                        Threading.Thread.Sleep(5000 / lstNodeStatus.Items.Count)
                    End Try
                Next
            End If
        Loop
    End Sub

    Private Sub txtCmdType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCmdType.SelectedIndexChanged
        If txtCmdType.SelectedIndex >= 0 Then
            Dim cmdres = CallFunction("getCommandExplain", txtCmdType.SelectedItem).result
            txtCmdTypeExplain.Text = cmdres
        End If
    End Sub

    Private isAlertSituation As Boolean = False
    Private alertPlayer As New Media.SoundPlayer(Application.StartupPath & "\sound\alert.wav")
    Private isAlertSoundPlayed As Boolean = False

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
End Class