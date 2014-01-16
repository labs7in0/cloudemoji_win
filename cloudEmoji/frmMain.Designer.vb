<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lstSource = New System.Windows.Forms.ListBox()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.lstEmoji = New System.Windows.Forms.ListBox()
        Me.btnOption = New System.Windows.Forms.Button()
        Me.menOption = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.meniSourceList = New System.Windows.Forms.ToolStripMenuItem()
        Me.meniRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.meniAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.meniExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.menOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstSource
        '
        Me.lstSource.FormattingEnabled = True
        Me.lstSource.ItemHeight = 24
        Me.lstSource.Location = New System.Drawing.Point(12, 36)
        Me.lstSource.Name = "lstSource"
        Me.lstSource.Size = New System.Drawing.Size(102, 292)
        Me.lstSource.TabIndex = 0
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Location = New System.Drawing.Point(12, 9)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(94, 24)
        Me.lblSource.TabIndex = 1
        Me.lblSource.Text = "Source:"
        '
        'lstEmoji
        '
        Me.lstEmoji.FormattingEnabled = True
        Me.lstEmoji.ItemHeight = 24
        Me.lstEmoji.Items.AddRange(New Object() {"aa", "bb", "cc"})
        Me.lstEmoji.Location = New System.Drawing.Point(120, 36)
        Me.lstEmoji.Name = "lstEmoji"
        Me.lstEmoji.Size = New System.Drawing.Size(142, 292)
        Me.lstEmoji.TabIndex = 2
        '
        'btnOption
        '
        Me.btnOption.Location = New System.Drawing.Point(204, 9)
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(57, 23)
        Me.btnOption.TabIndex = 3
        Me.btnOption.Text = "..."
        Me.btnOption.UseVisualStyleBackColor = True
        '
        'menOption
        '
        Me.menOption.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.meniSourceList, Me.meniRefresh, Me.meniAbout, Me.meniExit})
        Me.menOption.Name = "ContextMenuStrip1"
        Me.menOption.Size = New System.Drawing.Size(243, 148)
        '
        'meniSourceList
        '
        Me.meniSourceList.Name = "meniSourceList"
        Me.meniSourceList.Size = New System.Drawing.Size(242, 36)
        Me.meniSourceList.Text = "Source List(&S)"
        '
        'meniRefresh
        '
        Me.meniRefresh.Name = "meniRefresh"
        Me.meniRefresh.Size = New System.Drawing.Size(242, 36)
        Me.meniRefresh.Text = "Refresh(&R)"
        '
        'meniAbout
        '
        Me.meniAbout.Name = "meniAbout"
        Me.meniAbout.Size = New System.Drawing.Size(242, 36)
        Me.meniAbout.Text = "About(&A)"
        '
        'meniExit
        '
        Me.meniExit.Name = "meniExit"
        Me.meniExit.Size = New System.Drawing.Size(242, 36)
        Me.meniExit.Text = "Exit(&E)"
        '
        'ntyIcon
        '
        Me.ntyIcon.ContextMenuStrip = Me.menOption
        Me.ntyIcon.Icon = CType(resources.GetObject("ntyIcon.Icon"), System.Drawing.Icon)
        Me.ntyIcon.Text = "Cloud Emoji"
        Me.ntyIcon.Visible = True
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(274, 339)
        Me.Controls.Add(Me.btnOption)
        Me.Controls.Add(Me.lstEmoji)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.lstSource)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cloud Emoji"
        Me.TopMost = True
        Me.menOption.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstSource As System.Windows.Forms.ListBox
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents lstEmoji As System.Windows.Forms.ListBox
    Friend WithEvents btnOption As System.Windows.Forms.Button
    Friend WithEvents menOption As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents meniSourceList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents meniAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents meniExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents meniRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntyIcon As System.Windows.Forms.NotifyIcon

End Class
