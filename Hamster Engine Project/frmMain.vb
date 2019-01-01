Option Strict Off
Imports System.Collections.Concurrent
Imports System.Drawing
Imports System.Dynamic
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Text
Imports System.Threading
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



#Region "RTK-GPS Tab"
    Private Serial As New SerialPort
    Private thSerial As Thread
    Private thRtkMessage As New Thread(AddressOf ProcessMessage)

    Private bufRawSerial As New Queue(Of Byte)(1024)
    Private bufEachMessage As New List(Of Byte)
    Private latestData As New Dictionary(Of String, RTCMMessage)

    Private RTCMexplain As New Dictionary(Of String, String)
    Private MessageCount As Long = 0

    Private isMavReady As Boolean = False
    Private mavMessageFlag As Byte
    Private mavCurrentSeqID As Integer
    Private mavSystemID As Integer
    Private mavComponentID As Integer
    Private UDPSender As New Sockets.UdpClient
    Private UDPEndpoint As IPEndPoint

    Public Class RTCMMessage
        Public Data As List(Of Byte)
        Public FullMessage As Byte()
        Public Length As UInt32
        Public CRC24 As UInt32
        Public ID As UInt32
        Public IssueTime As Date

        ''' <summary>
        ''' 새로운 RTCM 메세지 컨테이너를 초기화 합니다
        ''' </summary>
        ''' <param name="data">RTCM 메세지에서 헤더를 제외한 데이터 프레임</param>
        ''' <param name="fullmsg">RTCM 전체 메세지</param>
        ''' <param name="len">RTCM 메세지에서 헤더를 제외한 데이터 프레임의 길이</param>
        ''' <param name="crc">RTCM 메세지의 CRC</param>
        ''' <param name="time">메세지가 수신된 시간</param>
        Public Sub New(data As List(Of Byte), fullmsg As Byte(), len As Long, crc As Long, time As Date)
            data = data
            FullMessage = fullmsg
            Length = len
            CRC24 = crc
            ID = FullMessage(3)
            ID = ID << 4
            ID = ID Or ((FullMessage(4) >> 4) And &HF)
            IssueTime = time
        End Sub
    End Class

    Private Sub txtProgName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each nowline In Split(File.ReadAllText(Application.StartupPath & "\RTCMexplain.txt"), vbCrLf)
            Dim pline = Split(nowline, ",")
            RTCMexplain.Add(pline(0), pline(1))
        Next
        lstData.Sorting = SortOrder.Descending
        lstData.ListViewItemSorter = New ListViewComparer(1, SortOrder.Ascending)
        Dim s = lstData.ListViewItemSorter()

        Dim dummyrtcm As Byte() = {&HD3, 1, 255, 255, 255}
        latestData.Add("-1", New RTCMMessage(New List(Of Byte) From {255}, dummyrtcm, 1, 0, Now))
    End Sub

    Public Class ListViewComparer
        Implements IComparer

        Public col As Integer
        Public order As SortOrder

        Public Sub New()
            col = 0
            order = SortOrder.Ascending
        End Sub

        Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
            col = column
            Me.order = order
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim returnVal As Integer = -1
            Dim a = Convert.ToDouble((CType(x, ListViewItem)).SubItems(col).Text.Replace("초 전", ""))
            Dim b = Convert.ToDouble((CType(y, ListViewItem)).SubItems(col).Text.Replace("초 전", ""))
            If a > b Then
                Return 1
            ElseIf a = b Then
                Return 0
            Else
                Return -1
            End If
        End Function
    End Class

    Private Function WaitRTCMMessage() As RTCMMessage
resetWait:
        '페이로드 빼고 6바이트 (페이로드가 1바이트인 예)
        'bit          value                byte
        '1~8        : 0xD3	            -> 0
        '9~13       : 0	                -> 1
        '14~24      : LENGTH = 1        -> 2
        '25~32      : PAYLOAD(1Byte)    -> 3
        '33~56      : CRC               -> 4 5 6
        Dim RTCMcount = 0
        Dim RTCMlen As UInt16 = 0
        Dim RTCMcrc As UInt32 = 0
        Dim RTCMdata As New List(Of Byte)
        Dim result As RTCMMessage
        Dim dropbytes As Integer = 0
        Dim dropbuf As New List(Of Byte)

        Do While True
            Do Until bufRawSerial.Count > 0 '메세지 수신까지 대기
            Loop
            Dim nowbyte = bufRawSerial.Dequeue
            If RTCMcount = 0 Then
                If Not nowbyte = &HD3 Then 'RTCM 헤더 수신까지 대기 1
                    dropbytes += 1
                    dropbuf.Add(nowbyte)
                    Continue Do
                Else
                    If Not dropbytes = 0 Then
                        lstRawSerialPrint("[DROP RTCM]Mavlink 마커 없는 데이터 : " & dropbytes.ToString & "bytes")
                        EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[DROP RTCM detail]" & ByteArrayToString(dropbuf.ToArray))
                    End If
                End If
            ElseIf RTCMcount = 1 Then '두번째 세번째 바이트는 메세지 length 2
                If Not (nowbyte And &HF8) = 0 Then
                    lstRawSerialPrint("[DROP RTCM]올바르지 않은 Premble 헤더 (0x000000이 아님)")
                    GoTo resetWait
                End If
                RTCMlen = (nowbyte And &H3) << 8
            ElseIf RTCMcount = 2 Then
                RTCMlen = RTCMlen Or nowbyte
            ElseIf RTCMcount <= 2 + RTCMlen Then '3
                RTCMdata.Add(nowbyte)
            ElseIf (RTCMcount > 2 + RTCMlen) And (RTCMcount <= (2 + RTCMlen) + 2) Then '4,  5
                RTCMcrc = RTCMcrc << 8
                RTCMcrc = RTCMcrc Or nowbyte
            ElseIf RTCMcount = (2 + RTCMlen) + 3 Then '6
                RTCMcrc = RTCMcrc << 8
                RTCMcrc = RTCMcrc Or nowbyte
                bufEachMessage.Add(nowbyte)
                result = New RTCMMessage(RTCMdata, bufEachMessage.ToArray, RTCMlen, RTCMcrc, Now)
                bufEachMessage.Clear()
                Exit Do
            End If

            If (RTCMcount = 4) And (chkDropExceptDefID.Checked = True) Then
                Dim ID As UInt16 = bufEachMessage(3)
                ID = ID << 4
                ID = ID Or ((bufEachMessage(4) >> 4) And &HF)
                If Not RTCMexplain.ContainsKey(ID.ToString) Then
                    lstRawSerialPrint("[DROP RTCM]정의되지 않은 ID")
                    GoTo resetWait
                End If
            End If

            bufEachMessage.Add(nowbyte)
            RTCMcount += 1
        Loop
        Return result
    End Function

    Public Shared Function ByteArrayToString(ByVal ba As Byte()) As String
        Dim hex As StringBuilder = New StringBuilder(ba.Length * 2)
        For Each b As Byte In ba
            hex.AppendFormat("{0:x2}", b)
        Next
        Return hex.ToString.ToUpper()
    End Function

    Private Sub ProcessMessage()
        Dim exmsg, exmsglen As String
        Do While True
            Try
                Dim r = WaitRTCMMessage()
                If latestData.ContainsKey(r.ID) Then
                    latestData(r.ID) = r
                Else
                    latestData.Add(r.ID, r)
                End If
                If RTCMexplain.ContainsKey(r.ID) Then
                    If isMavReady Then
                        MavSendRTCM(r)
                    End If
                End If
                'lstRawSerialPrint(ByteArrayToString(r.FullMessage))
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("수신한 메세지 HEX : " & ByteArrayToString(r.FullMessage))
                MessageCount += 1
                txtKeywordCount.Text = "수신한 메세지 개수 : " & MessageCount & "   키워드 개수 : " & latestData.Count
            Catch ex As ThreadAbortException
            Catch ex As Exception
                EngineWrapper.EngineFunction.EFUNC_ShowErrorMsg.DynamicInvoke("PROCESS_MESSAGE_ERROR", "메서지를 처리하는데 실패했습니다! 메세지 내용 : " & exmsg & " (길이 : " & exmsglen & ")", "", "", ex)
            End Try
        Loop
    End Sub

    Private Sub SerialRead()
        Do While True
            Try
                If Not Serial.IsOpen Then
                    lstRawSerialPrint("[시리얼 포트가 예상치 못하게 닫혔습니다]")
                    btnDisconnect_Click(Nothing, Nothing)
                End If
                Do While Serial.BytesToRead > 0
                    bufRawSerial.Enqueue(Serial.ReadByte)
                Loop
            Catch ex As TimeoutException
            Catch ex As ThreadAbortException
            Catch ex As Exception
                lstRawSerialPrint("[시리얼 포트를 읽는 중 오류가 발생했습니다] → " & ex.Message)
                btnDisconnect_Click(Nothing, Nothing)
            End Try
        Loop
    End Sub

    Private Sub MavSendRTCM(r As RTCMMessage)
        Try
            If r.FullMessage.Count > 180 Then
                lstRawSerialPrint("[MavLink 분할 UDP 전송 요청] → ID : " & r.ID)
                Dim flags As Byte = (mavCurrentSeqID << 3) And &HFF
                Dim fragdata1 As New List(Of Byte)
                Dim fragdata2 As New List(Of Byte)
                For i As Integer = 0 To 179
                    fragdata1.Add(r.FullMessage(i))
                Next
                For i As Integer = 180 To r.FullMessage.Count - 1
                    fragdata2.Add(r.FullMessage(i))
                Next
                Dim flags1 As Byte = (mavCurrentSeqID << 3) And &HFF
                Dim flags2 As Byte = (mavCurrentSeqID << 3) And &HFF
                flags1 += &H1
                flags2 += &H3
                Dim nowmsg1 As New Mavlink.MavlinkDefMessage.GPS_RTCM_DATA(mavCurrentSeqID, mavSystemID, mavComponentID, flags1, fragdata1.Count, fragdata1.ToArray)
                Dim nowmsg2 As New Mavlink.MavlinkDefMessage.GPS_RTCM_DATA(mavCurrentSeqID, mavSystemID, mavComponentID, flags2, fragdata2.Count, fragdata2.ToArray)
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[MavLink UDP 메세지 생성 완료]")
                Dim snowmsg1 = nowmsg1.Serialize()
                Dim snowmsg2 = nowmsg2.Serialize()
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[MavLink UDP 메세지 직렬화 완료]")
                UDPSender.Send(snowmsg1, snowmsg1.Count, UDPEndpoint)
                UDPSender.Send(snowmsg2, snowmsg2.Count, UDPEndpoint)
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[MavLink 분할 UDP 메세지 전송]" & vbCrLf & nowmsg1.ToString)
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[MavLink 분할 UDP 메세지 전송]" & vbCrLf & nowmsg2.ToString)
            Else
                lstRawSerialPrint("[MavLink UDP 전송 요청] → ID : " & r.ID)
                Dim flags As Byte = (mavCurrentSeqID << 3) And &HFF
                lstRawSerialPrint("[MavLink UDP 전송 요청] → FLAG : " & flags)
                Dim nowmsg As New Mavlink.MavlinkDefMessage.GPS_RTCM_DATA(mavCurrentSeqID, mavSystemID, mavComponentID, flags, r.FullMessage.Count, r.FullMessage)
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[MavLink UDP 메세지 생성 완료]")
                Dim snowmsg = nowmsg.Serialize()
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[MavLink UDP 메세지 직렬화 완료]")
                UDPSender.Send(snowmsg, snowmsg.Count, UDPEndpoint)
                EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke("[MavLink UDP 메세지 전송]" & vbCrLf & nowmsg.ToString)
            End If
            If mavComponentID >= Byte.MaxValue Then
                mavCurrentSeqID = 0
            Else
                mavCurrentSeqID += 1
            End If
        Catch ex As OverflowException
            lstRawSerialPrint("[MavLink 전송 실패] → " & ex.GetType.FullName)
            mavCurrentSeqID = 0
        Catch ex As Mavlink.MavlinkException.MavlinkPayloadTooLargeException
            lstRawSerialPrint("[MavLink 전송 실패] → " & ex.GetType.FullName)
        Catch ex As Exception
            lstRawSerialPrint("[MavLink 전송 실패] → " & ex.GetType.FullName)
            EngineWrapper.EngineFunction.EFUNC_ShowErrorMsg.DynamicInvoke("MAVLINK_SEND_ERROR", "MAVLINK 메세지를 전송하는데 실패했습니다!", "", "", ex)
        End Try
    End Sub

    Private Sub timLstUpdate_Tick(sender As Object, e As EventArgs) Handles timLstUpdate.Tick
        Try
            lstData.Items.Clear()
            Dim displaylst As New Dictionary(Of String, RTCMMessage)(latestData)
            For Each nowele In displaylst
                Dim timediff As TimeSpan = Now - nowele.Value.IssueTime
                Dim lst As ListViewItem
                If chkShowDefID.Checked Then
                    If RTCMexplain.ContainsKey(nowele.Value.ID) Then
                        lst = New ListViewItem({nowele.Value.ID, Math.Round(timediff.TotalSeconds, 1) & "초 전", nowele.Value.Length, nowele.Value.FullMessage.Count, nowele.Value.CRC24.ToString("x6"), RTCMIDtoExplain(nowele.Value.ID)})
                        lstData.Items.Add(lst)
                    End If
                Else
                    lst = New ListViewItem({nowele.Value.ID, Math.Round(timediff.TotalSeconds, 1) & "초 전", nowele.Value.Length, nowele.Value.FullMessage.Count, nowele.Value.CRC24.ToString("x6"), RTCMIDtoExplain(nowele.Value.ID)})
                    lstData.Items.Add(lst)
                End If
            Next
            lstData.Sort()
        Catch ex As Exception
            EngineWrapper.EngineFunction.EFUNC_ShowErrorMsg.DynamicInvoke("MESSAGE_DISPLAY_ERROR", "메세지를 표출하는 중 오류가 발생했습니다", "", "", ex)
        End Try
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            If txtComPort.Text = "" Or txtBaud.Text = "" Then
                Exit Sub
            End If
            btnConnect.Enabled = False
            btnDisconnect.Enabled = True

            Serial.PortName = txtComPort.Text
            Serial.BaudRate = txtBaud.Text
            lstRawSerialPrint("[시리얼 포트 열기] → " & Serial.PortName & ", " & Serial.BaudRate)
            Serial.Open()
            thSerial = New Thread(AddressOf SerialRead)
            thSerial.Start()
            thMessage = New Thread(AddressOf ProcessMessage)
            thMessage.Start()
            timLstUpdate.Enabled = True

            txtBaud.Enabled = False
            txtComPort.Enabled = False
            lstRawSerialPrint("[시리얼 포트 열기 성공]")
            latestData.Clear()
        Catch ex As Exception
            lstRawSerialPrint("[시리얼 포트 열기 실패] → " & ex.Message)
            EngineWrapper.EngineFunction.EFUNC_ShowErrorMsg.DynamicInvoke("COMPORT_OPEN_ERROR", "시리얼 포트를 여는데 실패했습니다!", "", "", ex)
            btnDisconnect_Click(Nothing, Nothing)
        End Try
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Try
            thSerial.Abort()
            thRtkMessage.Abort()
            Serial.Close()
        Catch
        End Try
        timLstUpdate.Enabled = False
        btnConnect.Enabled = True
        btnDisconnect.Enabled = False
        txtBaud.Enabled = True
        txtComPort.Enabled = True
        lstRawSerialPrint("[시리얼 포트 닫기 성공]")
    End Sub

    Private Function RTCMIDtoExplain(id As String) As String
        If RTCMexplain.ContainsKey(id) Then
            Return RTCMexplain(id)
        Else
            Return ""
        End If
    End Function

    Private Sub lstRawSerialPrint(msg As String)
        lstRawSerial.Items.Add(msg)
        lstRawSerial.SelectedIndex = lstRawSerial.Items.Count - 1
        EngineWrapper.EngineFunction.EFUNC_LogWrite.DynamicInvoke(msg)
    End Sub

    Private Sub btnListReset_Click(sender As Object, e As EventArgs) Handles btnListReset.Click
        latestData.Clear()
    End Sub
#End Region

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