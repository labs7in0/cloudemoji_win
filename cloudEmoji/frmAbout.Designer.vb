<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lnk7IN0 = New System.Windows.Forms.LinkLabel()
        Me.lnkProject = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(142, 24)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Cloud Emoji"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(12, 33)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(238, 24)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "{0}.{1} (Build {2})"
        '
        'lnk7IN0
        '
        Me.lnk7IN0.AutoSize = True
        Me.lnk7IN0.Location = New System.Drawing.Point(12, 57)
        Me.lnk7IN0.Name = "lnk7IN0"
        Me.lnk7IN0.Size = New System.Drawing.Size(274, 24)
        Me.lnk7IN0.TabIndex = 3
        Me.lnk7IN0.TabStop = True
        Me.lnk7IN0.Text = "Desktop Client by 7IN0"
        '
        'lnkProject
        '
        Me.lnkProject.AutoSize = True
        Me.lnkProject.Location = New System.Drawing.Point(12, 96)
        Me.lnkProject.Name = "lnkProject"
        Me.lnkProject.Size = New System.Drawing.Size(274, 24)
        Me.lnkProject.TabIndex = 4
        Me.lnkProject.TabStop = True
        Me.lnkProject.Text = "Cloud Emoticon Project"
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(174, 129)
        Me.Controls.Add(Me.lnkProject)
        Me.Controls.Add(Me.lnk7IN0)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lnk7IN0 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkProject As System.Windows.Forms.LinkLabel

End Class
