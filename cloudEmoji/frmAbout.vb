Imports System.Windows.Forms

Public Class frmAbout

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = System.String.Format(lblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Revision)
    End Sub

    Private Sub lnk7IN0_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk7IN0.LinkClicked
        Shell("explorer http://7in0.me")
    End Sub

    Private Sub lnkProject_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkProject.LinkClicked
        Shell("explorer http://www.heartunlock.com/soft/cloud_emoticon/")
    End Sub
End Class
