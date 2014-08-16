Public Class frmMain
    Private source As String
    Private parseCache As Dictionary(Of String, String)
    Private cacheXML As String = "\cache.xml"
    Private configXML As String = "\config.xml"
    Private cacheTemp As String = "\cache.xml.tmp"
    Private defaultUrl As String = "http://lib.best33.com/share/cloudKT.xml"
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
        Me.Hide()
        Me.Visible = False
        Me.Refresh()
        cacheXML = Application.StartupPath + cacheXML
        configXML = Application.StartupPath + configXML
        cacheTemp = Application.StartupPath + cacheTemp
        source = clsXML.GetXML("source", "", configXML)
        If source = "" Then
            If Not clsXML.WriteXML("source", defaultUrl, configXML) Then
                clsXML.ResetXML(Application.StartupPath + "\config.xml")
                clsXML.WriteXML("source", defaultUrl, configXML)
            End If
            source = defaultUrl
        End If
        If System.IO.File.Exists(cacheXML) Then
            UpdateView()
        End If
        Call meniRefresh_Click(sender, e)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Visible Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub btnOption_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOption.MouseDown
        menOption.Show(btnOption, New Point(e.X, e.Y))
    End Sub

    Private Sub ntyIcon_DoubleClick(sender As Object, e As EventArgs) Handles ntyIcon.DoubleClick
        Me.Show()
    End Sub

    Private Sub meniSourceList_Click(sender As Object, e As EventArgs) Handles meniSourceList.Click
        source = InputBox("Source(XML File):", source, clsXML.GetXML("source", defaultUrl, configXML))
        If Not clsXML.WriteXML("source", source, configXML) Then
            clsXML.ResetXML(configXML)
            clsXML.WriteXML("source", source, configXML)
        End If
        Call meniRefresh_Click(sender, e)
    End Sub

    Public Sub DownloadFileFinished(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        If e.Error IsNot Nothing Then
            If MsgBox("网络更新失败！" + Chr(10) + Chr(13) + e.Error.ToString, MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then
                Call DownloadXML()
            End If
        Else
            FileCopy(cacheTemp, cacheXML)
            Kill(cacheTemp)
            UpdateView()
        End If
    End Sub

    Private Sub DownloadXML()
        Dim dl As New System.Net.WebClient()
        AddHandler dl.DownloadFileCompleted, AddressOf DownloadFileFinished
        dl.DownloadFileAsync(New Uri(source), cacheTemp)
    End Sub

    Private Sub UpdateView()
        Dim i As Integer
        parseCache = clsXML.sourceParser()
        'Console.WriteLine(result("Author"))
        'Console.WriteLine(result("URL"))
        lstSource.Items.Clear()
        For i = 1 To parseCache(0)
            'Console.WriteLine(result(CType(i, String) + ":0"))
            lstSource.Items.Add(parseCache(CType(i, String) + ":0"))
        Next
    End Sub

    Private Sub meniRefresh_Click(sender As Object, e As EventArgs) Handles meniRefresh.Click
        DownloadXML()
    End Sub

    Private Sub meniAbout_Click(sender As Object, e As EventArgs) Handles meniAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub meniExit_Click(sender As Object, e As EventArgs) Handles meniExit.Click
        Call My.MyApplication.endMe()
    End Sub

    Private Sub lstEmoji_DoubleClick(sender As Object, e As EventArgs) Handles lstEmoji.DoubleClick
        Clipboard.SetData(DataFormats.Text, CType(lstEmoji.SelectedItem, Object))
        Me.Close()
        SendKeys.Send("^V")
    End Sub

    Private Sub lstSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSource.SelectedIndexChanged
        Dim i, j As Integer
        i = lstSource.SelectedIndex + 1
        'Dim result As Dictionary(Of String, String) = clsXML.sourceParser()
        'Console.WriteLine(result(CType(i, String) + ":0"))
        lstEmoji.Items.Clear()
        For j = 1 To CType(parseCache(i), Integer) - 1
            'Console.WriteLine(result(CType(i, String) + ":" + CType(j, String)))
            lstEmoji.Items.Add(parseCache(CType(i, String) + ":" + CType(j, String)))
        Next
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Hide()
    End Sub
End Class
