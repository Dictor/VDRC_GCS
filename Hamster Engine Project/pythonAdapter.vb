Imports IronPython.Hosting
Imports Microsoft.Scripting.Hosting

Module PythonAdapter
    Private commonEngine As ScriptEngine
    Public commonScope As ScriptScope
    Public commonOperation As ObjectOperations

    Public Sub Init()
        commonEngine = Python.CreateEngine()
        commonScope = commonEngine.CreateScope()
        commonOperation = commonEngine.Operations
        Dim libpath = commonEngine.GetSearchPaths()
        libpath.Add(EngineWrapper.EngineArgument.ApplicationStartupPath & "\pythonLibs")
        commonEngine.SetSearchPaths(libpath)
    End Sub

    Public Function GetList(scope As ScriptScope, listName As String) As IList(Of Object)
        Dim originalResult As IList(Of Object) = CType(scope.GetVariable(listName), IList(Of Object))
        Return originalResult
    End Function

    Public Function Execute(filePath As String) As PythonResult
        Dim scrSource As ScriptSource = commonEngine.CreateScriptSourceFromFile(filePath, Text.Encoding.UTF8)
        scrSource.Execute(commonScope)
        Return New PythonResult(commonScope, Nothing)
    End Function

    Public Function CallFunction(functionName As String, functionParam As Object) As PythonResult
        Dim scrFunction = commonScope.GetVariable(Of Func(Of Object, Object))(functionName)
        Return New PythonResult(commonScope, scrFunction(functionParam))
    End Function

    Public Function CallFunction(functionName As String) As PythonResult
        Dim scrFunction = commonScope.GetVariable(Of Func(Of Object))(functionName)
        Return New PythonResult(commonScope, scrFunction())
    End Function

    Public Function ExecuteInNewScope(filePath As String) As PythonResult
        Dim scrScope As ScriptScope = commonEngine.CreateScope()
        Dim scrSource As ScriptSource = commonEngine.CreateScriptSourceFromFile(filePath, Text.Encoding.UTF8)
        scrSource.Execute(scrScope)
        Return New PythonResult(scrScope, Nothing)
    End Function

    Public Function ExecuteInNewScope(filePath As String, functionName As String, functionParam As Object) As PythonResult
        Dim scrScope As ScriptScope = commonEngine.CreateScope()
        Dim scrSource As ScriptSource = commonEngine.CreateScriptSourceFromFile(filePath, Text.Encoding.UTF8)
        scrSource.Execute(scrScope)
        Dim scrFunction = scrScope.GetVariable(Of Func(Of Object, Object))(functionName)
        Return New PythonResult(scrScope, scrFunction(functionParam))
    End Function

    Public Function ExecuteInNewScope(filePath As String, functionName As String) As PythonResult
        Dim scrScope As ScriptScope = commonEngine.CreateScope()
        Dim scrSource As ScriptSource = commonEngine.CreateScriptSourceFromFile(filePath, Text.Encoding.UTF8)
        scrSource.Execute(scrScope)
        Dim scrFunction = scrScope.GetVariable(Of Func(Of Object))(functionName)
        Return New PythonResult(scrScope, scrFunction())
    End Function

    Public Class PythonResult
            Public ReadOnly scope As ScriptScope
            Public ReadOnly result As Object

            Public Sub New(resScope As ScriptScope, resResult As Object)
                scope = resScope
                result = resResult
            End Sub
        End Class
    End Module
