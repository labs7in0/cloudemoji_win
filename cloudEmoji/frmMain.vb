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
        source = clsXML.GetXML("source", "", Application.StartupPath + "\config.xml")
        If source = "" Then
            If Not clsXML.WriteXML("source", "http://dl.dropboxusercontent.com/u/120725807/test.xml", Application.StartupPath + "\config.xml") Then
                clsXML.ResetXML(Application.StartupPath + "\config.xml")
                clsXML.WriteXML("source", "http://dl.dropboxusercontent.com/u/120725807/test.xml", Application.StartupPath + "\config.xml")
            End If
            source = "http://dl.dropboxusercontent.com/u/120725807/test.xml"
        End If

        Call meniRefresh_Click(sender, e)
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
        If Not clsXML.WriteXML("source", source, Application.StartupPath + "\config.xml") Then
            clsXML.ResetXML(Application.StartupPath + "\config.xml")
            clsXML.WriteXML("source", source, Application.StartupPath + "\config.xml")
        End If
        Call meniRefresh_Click(sender, e)
    End Sub

    Private Sub meniRefresh_Click(sender As Object, e As EventArgs) Handles meniRefresh.Click
        clsXML.refreshCache(source)

        Dim i As Integer
        Dim result As Dictionary(Of String, String) = clsXML.sourceParser()
        Console.WriteLine(result("Author"))
        Console.WriteLine(result("URL"))
        lstSource.Items.Clear()
        For i = 1 To result(0)
            Console.WriteLine(result(CType(i, String) + ":0"))
            lstSource.Items.Add(result(CType(i, String) + ":0"))
        Next
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

    Private Sub lstSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSource.SelectedIndexChanged
        Dim i, j As Integer
        i = lstSource.SelectedIndex + 1
        Dim result As Dictionary(Of String, String) = clsXML.sourceParser()
        Console.WriteLine(result(CType(i, String) + ":0"))
        lstEmoji.Items.Clear()
        For j = 1 To CType(result(i), Integer) - 1
            Console.WriteLine(result(CType(i, String) + ":" + CType(j, String)))
            lstEmoji.Items.Add(result(CType(i, String) + ":" + CType(j, String)))
        Next
    End Sub
End Class
