Imports Hamster_Engine_Project.HE_Common_Component

Public Class Project
    Public Shared Version As New HamsterVersion("VDRC GCS", 0, 0, 181213, 19)
    Private Shared LoadObject_PROJ_Info As New Dictionary(Of String, Object()) '("개체 전체 이름", {"어셈블리 경로"})
    Public Shared mainFrm As New frmMain

    Public Function initialization(EngineAsm As Dictionary(Of String, Object), enginefunc As [Delegate]()(), args As Object()) As Dictionary(Of String, Object())
#Region "EngineVarSet"
        Engine.ApplicationStartupPath = args(0)
        Engine.Version = args(1)
        Engine.EFUNC_EngineShutdown = enginefunc(0)(0)
        Engine.EFUNC_LogWrite = enginefunc(1)(0)
        Engine.EFUNC_SetMainForm = enginefunc(2)(0)
        Engine.EFUNC_ShowWarningMsg = enginefunc(3)(0)
        Engine.EFUNC_ShowErrorMsg = enginefunc(4)(0)
#End Region
        Return LoadObject_PROJ_Info
    End Function

    Public Sub main(ProjsideAsm As Dictionary(Of String, Object))
        Engine.EFUNC_SetMainForm.DynamicInvoke(mainFrm)
    End Sub
End Class

Public Class Engine
    Public Shared EFUNC_EngineShutdown As [Delegate]
    Public Shared EFUNC_LogWrite As [Delegate]
    Public Shared EFUNC_SetMainForm As [Delegate]
    Public Shared EFUNC_ShowWarningMsg As [Delegate]
    Public Shared EFUNC_ShowErrorMsg As [Delegate]
    Public Shared ApplicationStartupPath As String
    Public Shared Version As Object
End Class

