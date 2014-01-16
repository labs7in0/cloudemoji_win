Namespace My

    Partial Friend Class MyApplication

        Private Const MOD_ALT = &H1
        Private Const MOD_CONTROL = &H2
        Private Const MOD_SHIFT = &H4

        Private Declare Auto Function RegisterHotKey Lib "user32.dll" Alias _
            "RegisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Boolean

        Private Declare Auto Function UnRegisterHotKey Lib "user32.dll" Alias _
            "UnregisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer) As Boolean

        Public Shared Sub endMe()
            frmMain.ntyIcon.Dispose()
            UnRegisterHotKey(frmMain.Handle, 0)
            End
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            Call endMe()
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            RegisterHotKey(frmMain.Handle, 0, MOD_SHIFT + MOD_CONTROL, Asc("E"))
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MessageBox.Show(e.Exception.StackTrace, e.Exception.GetType().ToString & " -- " & e.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call endMe()
        End Sub
    End Class

End Namespace

