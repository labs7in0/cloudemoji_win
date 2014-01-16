Public Class frmMain
    Private source As String

    Public Const WM_HOTKEY = &H312
    Public Const GWL_WNDPROC = (-4)

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HOTKEY Then
            If Me.Visible Then
                Me.Hide()
            Else
                Me.Show()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        source = clsINI.GetIni("source list", "0", "", Application.StartupPath + "\config.ini")
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub btnOption_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOption.MouseDown
        menOption.Show(btnOption, New Point(e.X, e.Y))
    End Sub

    Private Sub ntyIcon_DoubleClick(sender As Object, e As EventArgs) Handles ntyIcon.DoubleClick
        Me.Show()
    End Sub

    Private Sub meniSourceList_Click(sender As Object, e As EventArgs) Handles meniSourceList.Click
        source = InputBox("Source(XML File):", , "http://dl.dropboxusercontent.com/u/120725807/test.xml")
        clsParser.refreshCache(source)
        If Not clsINI.WriteIni("source list", "0", source, Application.StartupPath + "\config.ini") Then
            MsgBox("Get an error when write configure file.")
        End If
    End Sub

    Private Sub meniRefresh_Click(sender As Object, e As EventArgs) Handles meniRefresh.Click
        Dim i As Int16
        i = 1
        While (1)
            i = i * 64
        End While
    End Sub

    Private Sub meniAbout_Click(sender As Object, e As EventArgs) Handles meniAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub meniExit_Click(sender As Object, e As EventArgs) Handles meniExit.Click
        Call My.MyApplication.endMe()
    End Sub

    Private Sub lstEmoji_DoubleClick(sender As Object, e As EventArgs) Handles lstEmoji.DoubleClick
        'Clipboard.Clear()
        'Clipboard.SetText(lstEmoji.Items(lstEmoji.SelectedIndex))
        Me.Close()
        Threading.Thread.Sleep(100)
        SendKeys.Send(lstEmoji.Items(lstEmoji.SelectedIndex))
    End Sub
End Class
