Imports System.Net
Public Class Form1
    Dim WithEvents downloader As New WebClient
    

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            downloader.DownloadFileAsync(New Uri(TextBox1.Text), SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub downloader_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles downloader.DownloadFileCompleted
        ProgressBar1.Value = 0
        Label1.Hide()
    End Sub

    Private Sub downloader_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label1.Show()
        Label1.Text = "Download in corso..." & e.ProgressPercentage & "%"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        downloader.CancelAsync()
        ProgressBar1.Value = 0
        Label1.Hide()
    End Sub
End Class
