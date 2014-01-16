Public Class clsINI

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Public Shared Function GetIni(ByVal section As String, ByVal key As String, Optional ByVal lpDefault As String = "", Optional ByVal iniFilePath As String = "config.ini") As String
        Try
            Dim Str As String = ""

            Str = LSet(Str, 256)
            GetPrivateProfileString(section, key, lpDefault, Str, Len(Str), iniFilePath)

            Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function WriteIni(ByVal section As String, ByVal key As String, ByVal lpDefault As String, Optional ByVal iniFilePath As String = "config.ini") As Long
        Try
            Return WritePrivateProfileString(section, key, lpDefault, iniFilePath)
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
