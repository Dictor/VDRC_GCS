<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.chkHeartbeat = New System.Windows.Forms.CheckBox()
        Me.btnReadNode = New System.Windows.Forms.Button()
        Me.lstNodeStatus = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAddr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPort = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHeartbeat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colACK = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtStatusExplain = New System.Windows.Forms.Label()
        Me.txtProgName = New System.Windows.Forms.Label()
        Me.txtProgVer = New System.Windows.Forms.Label()
        Me.tabpCommand = New System.Windows.Forms.TabPage()
        Me.grpCmdExecute = New System.Windows.Forms.GroupBox()
        Me.btnCmdImmdExe = New System.Windows.Forms.Button()
        Me.grpCmdKind = New System.Windows.Forms.GroupBox()
        Me.txtCmdTypeExplain = New System.Windows.Forms.Label()
        Me.txtCmdType = New System.Windows.Forms.ComboBox()
        Me.grpCmdTarget = New System.Windows.Forms.GroupBox()
        Me.txtTargetCustom = New System.Windows.Forms.TextBox()
        Me.btnTargetCustom = New System.Windows.Forms.RadioButton()
        Me.btnTargetAll = New System.Windows.Forms.RadioButton()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabpRTK = New System.Windows.Forms.TabPage()
        Me.grpRTKData = New System.Windows.Forms.GroupBox()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkDropExceptDefID = New System.Windows.Forms.CheckBox()
        Me.chkShowDefID = New System.Windows.Forms.CheckBox()
        Me.btnListReset = New System.Windows.Forms.Button()
        Me.txtKeywordCount = New System.Windows.Forms.Label()
        Me.grpRTKComm = New System.Windows.Forms.GroupBox()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBaud = New System.Windows.Forms.TextBox()
        Me.txtComPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstRawSerial = New System.Windows.Forms.ListBox()
        Me.tabpConsole = New System.Windows.Forms.TabPage()
        Me.lstConsole = New System.Windows.Forms.ListView()
        Me.colTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMsg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabPacket = New System.Windows.Forms.TabPage()
        Me.txtPacketDetail = New System.Windows.Forms.Label()
        Me.lstPacket = New System.Windows.Forms.ListView()
        Me.colMsgTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMsgDir = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMsgName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMsgData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtAlert = New System.Windows.Forms.Label()
        Me.timAlert = New System.Windows.Forms.Timer(Me.components)
        Me.colIssueTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRealLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCRC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colExplain = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.timHeartbeat = New System.Windows.Forms.Timer(Me.components)
        Me.timLstUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.grpStatus.SuspendLayout()
        Me.tabpCommand.SuspendLayout()
        Me.grpCmdExecute.SuspendLayout()
        Me.grpCmdKind.SuspendLayout()
        Me.grpCmdTarget.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabpRTK.SuspendLayout()
        Me.grpRTKData.SuspendLayout()
        Me.grpRTKComm.SuspendLayout()
        Me.tabpConsole.SuspendLayout()
        Me.tabPacket.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpStatus
        '
        Me.grpStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStatus.Controls.Add(Me.chkHeartbeat)
        Me.grpStatus.Controls.Add(Me.btnReadNode)
        Me.grpStatus.Controls.Add(Me.lstNodeStatus)
        Me.grpStatus.Controls.Add(Me.txtStatusExplain)
        Me.grpStatus.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grpStatus.Location = New System.Drawing.Point(726, 12)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(418, 613)
        Me.grpStatus.TabIndex = 0
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "노드 상태"
        '
        'chkHeartbeat
        '
        Me.chkHeartbeat.AutoSize = True
        Me.chkHeartbeat.Checked = True
        Me.chkHeartbeat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHeartbeat.Location = New System.Drawing.Point(99, 22)
        Me.chkHeartbeat.Name = "chkHeartbeat"
        Me.chkHeartbeat.Size = New System.Drawing.Size(102, 19)
        Me.chkHeartbeat.TabIndex = 6
        Me.chkHeartbeat.Text = "하트비트 체크"
        Me.chkHeartbeat.UseVisualStyleBackColor = True
        '
        'btnReadNode
        '
        Me.btnReadNode.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnReadNode.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.btnReadNode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnReadNode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Olive
        Me.btnReadNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReadNode.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnReadNode.Location = New System.Drawing.Point(9, 20)
        Me.btnReadNode.Name = "btnReadNode"
        Me.btnReadNode.Size = New System.Drawing.Size(84, 24)
        Me.btnReadNode.TabIndex = 5
        Me.btnReadNode.Text = "노드 생성"
        Me.btnReadNode.UseVisualStyleBackColor = False
        '
        'lstNodeStatus
        '
        Me.lstNodeStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstNodeStatus.BackColor = System.Drawing.SystemColors.ControlText
        Me.lstNodeStatus.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colAddr, Me.colPort, Me.colHeartbeat, Me.colACK, Me.colStatus})
        Me.lstNodeStatus.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lstNodeStatus.FullRowSelect = True
        Me.lstNodeStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstNodeStatus.HideSelection = False
        Me.lstNodeStatus.Location = New System.Drawing.Point(8, 72)
        Me.lstNodeStatus.Name = "lstNodeStatus"
        Me.lstNodeStatus.Size = New System.Drawing.Size(403, 531)
        Me.lstNodeStatus.TabIndex = 1
        Me.lstNodeStatus.UseCompatibleStateImageBehavior = False
        Me.lstNodeStatus.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 40
        '
        'colAddr
        '
        Me.colAddr.Text = "주소"
        Me.colAddr.Width = 68
        '
        'colPort
        '
        Me.colPort.Text = "포트"
        Me.colPort.Width = 50
        '
        'colHeartbeat
        '
        Me.colHeartbeat.Text = "하트비트"
        Me.colHeartbeat.Width = 101
        '
        'colACK
        '
        Me.colACK.Text = "ACK"
        '
        'colStatus
        '
        Me.colStatus.Text = "상태"
        '
        'txtStatusExplain
        '
        Me.txtStatusExplain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatusExplain.Location = New System.Drawing.Point(7, 51)
        Me.txtStatusExplain.Name = "txtStatusExplain"
        Me.txtStatusExplain.Size = New System.Drawing.Size(404, 14)
        Me.txtStatusExplain.TabIndex = 0
        Me.txtStatusExplain.Text = "Explain"
        '
        'txtProgName
        '
        Me.txtProgName.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtProgName.Location = New System.Drawing.Point(5, 9)
        Me.txtProgName.Name = "txtProgName"
        Me.txtProgName.Size = New System.Drawing.Size(594, 31)
        Me.txtProgName.TabIndex = 1
        Me.txtProgName.Text = "Program Name"
        '
        'txtProgVer
        '
        Me.txtProgVer.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtProgVer.Location = New System.Drawing.Point(7, 33)
        Me.txtProgVer.Name = "txtProgVer"
        Me.txtProgVer.Size = New System.Drawing.Size(592, 23)
        Me.txtProgVer.TabIndex = 2
        Me.txtProgVer.Text = "Program Version"
        '
        'tabpCommand
        '
        Me.tabpCommand.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabpCommand.Controls.Add(Me.grpCmdExecute)
        Me.tabpCommand.Controls.Add(Me.grpCmdKind)
        Me.tabpCommand.Controls.Add(Me.grpCmdTarget)
        Me.tabpCommand.Location = New System.Drawing.Point(4, 24)
        Me.tabpCommand.Name = "tabpCommand"
        Me.tabpCommand.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpCommand.Size = New System.Drawing.Size(701, 533)
        Me.tabpCommand.TabIndex = 1
        Me.tabpCommand.Text = "명령"
        '
        'grpCmdExecute
        '
        Me.grpCmdExecute.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCmdExecute.Controls.Add(Me.btnCmdImmdExe)
        Me.grpCmdExecute.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grpCmdExecute.Location = New System.Drawing.Point(6, 121)
        Me.grpCmdExecute.Name = "grpCmdExecute"
        Me.grpCmdExecute.Size = New System.Drawing.Size(689, 51)
        Me.grpCmdExecute.TabIndex = 8
        Me.grpCmdExecute.TabStop = False
        Me.grpCmdExecute.Text = "명령 실행"
        '
        'btnCmdImmdExe
        '
        Me.btnCmdImmdExe.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCmdImmdExe.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.btnCmdImmdExe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCmdImmdExe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Olive
        Me.btnCmdImmdExe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCmdImmdExe.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnCmdImmdExe.Location = New System.Drawing.Point(17, 17)
        Me.btnCmdImmdExe.Name = "btnCmdImmdExe"
        Me.btnCmdImmdExe.Size = New System.Drawing.Size(122, 24)
        Me.btnCmdImmdExe.TabIndex = 2
        Me.btnCmdImmdExe.Text = "즉시 실행"
        Me.btnCmdImmdExe.UseVisualStyleBackColor = False
        '
        'grpCmdKind
        '
        Me.grpCmdKind.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCmdKind.Controls.Add(Me.txtCmdTypeExplain)
        Me.grpCmdKind.Controls.Add(Me.txtCmdType)
        Me.grpCmdKind.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grpCmdKind.Location = New System.Drawing.Point(6, 58)
        Me.grpCmdKind.Name = "grpCmdKind"
        Me.grpCmdKind.Size = New System.Drawing.Size(689, 57)
        Me.grpCmdKind.TabIndex = 7
        Me.grpCmdKind.TabStop = False
        Me.grpCmdKind.Text = "명령 종류"
        '
        'txtCmdTypeExplain
        '
        Me.txtCmdTypeExplain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCmdTypeExplain.Location = New System.Drawing.Point(263, 21)
        Me.txtCmdTypeExplain.Name = "txtCmdTypeExplain"
        Me.txtCmdTypeExplain.Size = New System.Drawing.Size(412, 20)
        Me.txtCmdTypeExplain.TabIndex = 1
        Me.txtCmdTypeExplain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCmdType
        '
        Me.txtCmdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCmdType.FormattingEnabled = True
        Me.txtCmdType.Location = New System.Drawing.Point(17, 21)
        Me.txtCmdType.Name = "txtCmdType"
        Me.txtCmdType.Size = New System.Drawing.Size(240, 23)
        Me.txtCmdType.TabIndex = 0
        '
        'grpCmdTarget
        '
        Me.grpCmdTarget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCmdTarget.Controls.Add(Me.txtTargetCustom)
        Me.grpCmdTarget.Controls.Add(Me.btnTargetCustom)
        Me.grpCmdTarget.Controls.Add(Me.btnTargetAll)
        Me.grpCmdTarget.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grpCmdTarget.Location = New System.Drawing.Point(6, 6)
        Me.grpCmdTarget.Name = "grpCmdTarget"
        Me.grpCmdTarget.Size = New System.Drawing.Size(689, 46)
        Me.grpCmdTarget.TabIndex = 4
        Me.grpCmdTarget.TabStop = False
        Me.grpCmdTarget.Text = "명령 대상"
        '
        'txtTargetCustom
        '
        Me.txtTargetCustom.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTargetCustom.Location = New System.Drawing.Point(187, 15)
        Me.txtTargetCustom.Name = "txtTargetCustom"
        Me.txtTargetCustom.Size = New System.Drawing.Size(488, 23)
        Me.txtTargetCustom.TabIndex = 6
        '
        'btnTargetCustom
        '
        Me.btnTargetCustom.AutoSize = True
        Me.btnTargetCustom.Checked = True
        Me.btnTargetCustom.Location = New System.Drawing.Point(94, 18)
        Me.btnTargetCustom.Name = "btnTargetCustom"
        Me.btnTargetCustom.Size = New System.Drawing.Size(89, 19)
        Me.btnTargetCustom.TabIndex = 5
        Me.btnTargetCustom.TabStop = True
        Me.btnTargetCustom.Text = "사용자 지정"
        Me.btnTargetCustom.UseVisualStyleBackColor = True
        '
        'btnTargetAll
        '
        Me.btnTargetAll.AutoSize = True
        Me.btnTargetAll.Location = New System.Drawing.Point(17, 18)
        Me.btnTargetAll.Name = "btnTargetAll"
        Me.btnTargetAll.Size = New System.Drawing.Size(49, 19)
        Me.btnTargetAll.TabIndex = 4
        Me.btnTargetAll.Text = "전체"
        Me.btnTargetAll.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.tabpCommand)
        Me.tabMain.Controls.Add(Me.tabpRTK)
        Me.tabMain.Controls.Add(Me.tabpConsole)
        Me.tabMain.Controls.Add(Me.tabPacket)
        Me.tabMain.Location = New System.Drawing.Point(11, 63)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(709, 561)
        Me.tabMain.TabIndex = 3
        '
        'tabpRTK
        '
        Me.tabpRTK.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabpRTK.Controls.Add(Me.grpRTKData)
        Me.tabpRTK.Controls.Add(Me.grpRTKComm)
        Me.tabpRTK.Location = New System.Drawing.Point(4, 24)
        Me.tabpRTK.Name = "tabpRTK"
        Me.tabpRTK.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpRTK.Size = New System.Drawing.Size(701, 533)
        Me.tabpRTK.TabIndex = 2
        Me.tabpRTK.Text = "RTK-GPS"
        '
        'grpRTKData
        '
        Me.grpRTKData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpRTKData.Controls.Add(Me.lstData)
        Me.grpRTKData.Controls.Add(Me.chkDropExceptDefID)
        Me.grpRTKData.Controls.Add(Me.chkShowDefID)
        Me.grpRTKData.Controls.Add(Me.btnListReset)
        Me.grpRTKData.Controls.Add(Me.txtKeywordCount)
        Me.grpRTKData.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grpRTKData.Location = New System.Drawing.Point(6, 133)
        Me.grpRTKData.Name = "grpRTKData"
        Me.grpRTKData.Size = New System.Drawing.Size(689, 382)
        Me.grpRTKData.TabIndex = 11
        Me.grpRTKData.TabStop = False
        Me.grpRTKData.Text = "Data"
        '
        'lstData
        '
        Me.lstData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstData.BackColor = System.Drawing.SystemColors.ControlText
        Me.lstData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lstData.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lstData.Location = New System.Drawing.Point(9, 45)
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(674, 329)
        Me.lstData.TabIndex = 8
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "시간"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "길이"
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "실제길이"
        Me.ColumnHeader4.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CRC"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "메세지 설명"
        Me.ColumnHeader6.Width = 450
        '
        'chkDropExceptDefID
        '
        Me.chkDropExceptDefID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDropExceptDefID.Location = New System.Drawing.Point(297, 16)
        Me.chkDropExceptDefID.Name = "chkDropExceptDefID"
        Me.chkDropExceptDefID.Size = New System.Drawing.Size(131, 25)
        Me.chkDropExceptDefID.TabIndex = 18
        Me.chkDropExceptDefID.Text = "정의된 ID외 드랍"
        Me.chkDropExceptDefID.UseVisualStyleBackColor = True
        '
        'chkShowDefID
        '
        Me.chkShowDefID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowDefID.Location = New System.Drawing.Point(434, 15)
        Me.chkShowDefID.Name = "chkShowDefID"
        Me.chkShowDefID.Size = New System.Drawing.Size(131, 25)
        Me.chkShowDefID.TabIndex = 17
        Me.chkShowDefID.Text = "정의된 ID만 표시"
        Me.chkShowDefID.UseVisualStyleBackColor = True
        '
        'btnListReset
        '
        Me.btnListReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnListReset.Location = New System.Drawing.Point(571, 15)
        Me.btnListReset.Name = "btnListReset"
        Me.btnListReset.Size = New System.Drawing.Size(112, 25)
        Me.btnListReset.TabIndex = 16
        Me.btnListReset.Text = "리스트 초기화"
        Me.btnListReset.UseVisualStyleBackColor = True
        '
        'txtKeywordCount
        '
        Me.txtKeywordCount.Location = New System.Drawing.Point(6, 19)
        Me.txtKeywordCount.Name = "txtKeywordCount"
        Me.txtKeywordCount.Size = New System.Drawing.Size(221, 17)
        Me.txtKeywordCount.TabIndex = 1
        Me.txtKeywordCount.Text = "키워드 갯수 : "
        '
        'grpRTKComm
        '
        Me.grpRTKComm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpRTKComm.Controls.Add(Me.btnDisconnect)
        Me.grpRTKComm.Controls.Add(Me.btnConnect)
        Me.grpRTKComm.Controls.Add(Me.Label2)
        Me.grpRTKComm.Controls.Add(Me.txtBaud)
        Me.grpRTKComm.Controls.Add(Me.txtComPort)
        Me.grpRTKComm.Controls.Add(Me.Label1)
        Me.grpRTKComm.Controls.Add(Me.lstRawSerial)
        Me.grpRTKComm.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grpRTKComm.Location = New System.Drawing.Point(6, 6)
        Me.grpRTKComm.Name = "grpRTKComm"
        Me.grpRTKComm.Size = New System.Drawing.Size(689, 121)
        Me.grpRTKComm.TabIndex = 3
        Me.grpRTKComm.TabStop = False
        Me.grpRTKComm.Text = "Communication"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnDisconnect.Enabled = False
        Me.btnDisconnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisconnect.Location = New System.Drawing.Point(66, 84)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(78, 27)
        Me.btnDisconnect.TabIndex = 9
        Me.btnDisconnect.Text = "연결 끊기"
        Me.btnDisconnect.UseVisualStyleBackColor = False
        '
        'btnConnect
        '
        Me.btnConnect.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnConnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Location = New System.Drawing.Point(9, 84)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(51, 27)
        Me.btnConnect.TabIndex = 3
        Me.btnConnect.Text = "연결"
        Me.btnConnect.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Baudrate"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBaud
        '
        Me.txtBaud.Location = New System.Drawing.Point(74, 55)
        Me.txtBaud.Name = "txtBaud"
        Me.txtBaud.Size = New System.Drawing.Size(70, 23)
        Me.txtBaud.TabIndex = 5
        Me.txtBaud.Text = "115200"
        '
        'txtComPort
        '
        Me.txtComPort.Location = New System.Drawing.Point(74, 21)
        Me.txtComPort.Name = "txtComPort"
        Me.txtComPort.Size = New System.Drawing.Size(70, 23)
        Me.txtComPort.TabIndex = 3
        Me.txtComPort.Text = "COM"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Port"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstRawSerial
        '
        Me.lstRawSerial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstRawSerial.BackColor = System.Drawing.SystemColors.ControlText
        Me.lstRawSerial.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstRawSerial.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lstRawSerial.FormattingEnabled = True
        Me.lstRawSerial.Location = New System.Drawing.Point(148, 17)
        Me.lstRawSerial.Margin = New System.Windows.Forms.Padding(2)
        Me.lstRawSerial.Name = "lstRawSerial"
        Me.lstRawSerial.Size = New System.Drawing.Size(535, 95)
        Me.lstRawSerial.TabIndex = 1
        '
        'tabpConsole
        '
        Me.tabpConsole.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabpConsole.Controls.Add(Me.lstConsole)
        Me.tabpConsole.Location = New System.Drawing.Point(4, 22)
        Me.tabpConsole.Name = "tabpConsole"
        Me.tabpConsole.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpConsole.Size = New System.Drawing.Size(701, 535)
        Me.tabpConsole.TabIndex = 4
        Me.tabpConsole.Text = "콘솔"
        '
        'lstConsole
        '
        Me.lstConsole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstConsole.BackColor = System.Drawing.SystemColors.ControlText
        Me.lstConsole.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTime, Me.colType, Me.colMsg})
        Me.lstConsole.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lstConsole.Location = New System.Drawing.Point(6, 6)
        Me.lstConsole.Name = "lstConsole"
        Me.lstConsole.Size = New System.Drawing.Size(689, 513)
        Me.lstConsole.TabIndex = 0
        Me.lstConsole.UseCompatibleStateImageBehavior = False
        Me.lstConsole.View = System.Windows.Forms.View.Details
        '
        'colTime
        '
        Me.colTime.Text = "시간"
        Me.colTime.Width = 80
        '
        'colType
        '
        Me.colType.Text = "메세지 종류"
        Me.colType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colType.Width = 80
        '
        'colMsg
        '
        Me.colMsg.Text = "메세지"
        Me.colMsg.Width = 550
        '
        'tabPacket
        '
        Me.tabPacket.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabPacket.Controls.Add(Me.txtPacketDetail)
        Me.tabPacket.Controls.Add(Me.lstPacket)
        Me.tabPacket.Location = New System.Drawing.Point(4, 22)
        Me.tabPacket.Name = "tabPacket"
        Me.tabPacket.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPacket.Size = New System.Drawing.Size(701, 535)
        Me.tabPacket.TabIndex = 5
        Me.tabPacket.Text = "패킷 모니터"
        '
        'txtPacketDetail
        '
        Me.txtPacketDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPacketDetail.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtPacketDetail.Location = New System.Drawing.Point(6, 432)
        Me.txtPacketDetail.Name = "txtPacketDetail"
        Me.txtPacketDetail.Size = New System.Drawing.Size(689, 94)
        Me.txtPacketDetail.TabIndex = 2
        Me.txtPacketDetail.Text = "패킷 데이터"
        '
        'lstPacket
        '
        Me.lstPacket.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPacket.BackColor = System.Drawing.SystemColors.ControlText
        Me.lstPacket.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMsgTime, Me.colMsgDir, Me.colMsgName, Me.colMsgData})
        Me.lstPacket.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lstPacket.FullRowSelect = True
        Me.lstPacket.Location = New System.Drawing.Point(6, 10)
        Me.lstPacket.MultiSelect = False
        Me.lstPacket.Name = "lstPacket"
        Me.lstPacket.Size = New System.Drawing.Size(689, 419)
        Me.lstPacket.TabIndex = 1
        Me.lstPacket.UseCompatibleStateImageBehavior = False
        Me.lstPacket.View = System.Windows.Forms.View.Details
        '
        'colMsgTime
        '
        Me.colMsgTime.Text = "시간"
        Me.colMsgTime.Width = 80
        '
        'colMsgDir
        '
        Me.colMsgDir.Text = "방향"
        Me.colMsgDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colMsgDir.Width = 50
        '
        'colMsgName
        '
        Me.colMsgName.Text = "메세지 종류"
        Me.colMsgName.Width = 93
        '
        'colMsgData
        '
        Me.colMsgData.Text = "메세지 내용"
        Me.colMsgData.Width = 454
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Maroon
        Me.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Olive
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnExit.Location = New System.Drawing.Point(663, 14)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(53, 40)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "종료"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'txtAlert
        '
        Me.txtAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlert.BackColor = System.Drawing.Color.Red
        Me.txtAlert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlert.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtAlert.Location = New System.Drawing.Point(548, 14)
        Me.txtAlert.Margin = New System.Windows.Forms.Padding(0)
        Me.txtAlert.Name = "txtAlert"
        Me.txtAlert.Size = New System.Drawing.Size(81, 40)
        Me.txtAlert.TabIndex = 7
        Me.txtAlert.Text = "ALERT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtAlert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtAlert.Visible = False
        '
        'timAlert
        '
        Me.timAlert.Enabled = True
        Me.timAlert.Interval = 850
        '
        'timHeartbeat
        '
        Me.timHeartbeat.Enabled = True
        Me.timHeartbeat.Interval = 1000
        '
        'timLstUpdate
        '
        Me.timLstUpdate.Interval = 500
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.ClientSize = New System.Drawing.Size(1156, 637)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtAlert)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.txtProgVer)
        Me.Controls.Add(Me.txtProgName)
        Me.Controls.Add(Me.grpStatus)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.tabpCommand.ResumeLayout(False)
        Me.grpCmdExecute.ResumeLayout(False)
        Me.grpCmdKind.ResumeLayout(False)
        Me.grpCmdTarget.ResumeLayout(False)
        Me.grpCmdTarget.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tabpRTK.ResumeLayout(False)
        Me.grpRTKData.ResumeLayout(False)
        Me.grpRTKComm.ResumeLayout(False)
        Me.grpRTKComm.PerformLayout()
        Me.tabpConsole.ResumeLayout(False)
        Me.tabPacket.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents lstNodeStatus As System.Windows.Forms.ListView
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAddr As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPort As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHeartbeat As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtStatusExplain As System.Windows.Forms.Label
    Friend WithEvents txtProgName As System.Windows.Forms.Label
    Friend WithEvents txtProgVer As System.Windows.Forms.Label
    Friend WithEvents tabpCommand As System.Windows.Forms.TabPage
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabpRTK As System.Windows.Forms.TabPage
    Friend WithEvents tabpConsole As System.Windows.Forms.TabPage
    Friend WithEvents lstConsole As System.Windows.Forms.ListView
    Friend WithEvents colTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents colType As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMsg As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpCmdTarget As System.Windows.Forms.GroupBox
    Friend WithEvents btnTargetCustom As System.Windows.Forms.RadioButton
    Friend WithEvents btnTargetAll As System.Windows.Forms.RadioButton
    Friend WithEvents grpCmdKind As System.Windows.Forms.GroupBox
    Friend WithEvents txtCmdType As System.Windows.Forms.ComboBox
    Friend WithEvents txtTargetCustom As System.Windows.Forms.TextBox
    Friend WithEvents grpCmdExecute As System.Windows.Forms.GroupBox
    Friend WithEvents btnCmdImmdExe As System.Windows.Forms.Button
    Friend WithEvents txtCmdTypeExplain As System.Windows.Forms.Label
    Friend WithEvents btnReadNode As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtAlert As System.Windows.Forms.Label
    Friend WithEvents timAlert As System.Windows.Forms.Timer
    Friend WithEvents chkHeartbeat As System.Windows.Forms.CheckBox
    Friend WithEvents grpRTKData As System.Windows.Forms.GroupBox
    Friend WithEvents chkDropExceptDefID As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowDefID As System.Windows.Forms.CheckBox
    Friend WithEvents btnListReset As System.Windows.Forms.Button
    Friend WithEvents txtKeywordCount As System.Windows.Forms.Label
    Friend WithEvents grpRTKComm As System.Windows.Forms.GroupBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBaud As System.Windows.Forms.TextBox
    Friend WithEvents txtComPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstRawSerial As System.Windows.Forms.ListBox
    Friend WithEvents colIssueTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLength As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRealLength As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCRC As System.Windows.Forms.ColumnHeader
    Friend WithEvents colExplain As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstData As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colACK As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabPacket As System.Windows.Forms.TabPage
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents timHeartbeat As System.Windows.Forms.Timer
    Friend WithEvents lstPacket As System.Windows.Forms.ListView
    Friend WithEvents colMsgTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMsgDir As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMsgName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMsgData As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPacketDetail As System.Windows.Forms.Label
    Friend WithEvents timLstUpdate As System.Windows.Forms.Timer
End Class
