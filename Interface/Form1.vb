Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim a As New Uri("http://127.0.0.1/qc/public/")

            Me.WebBrowser1.Url = a

        Catch ex As Exception
            Me.WebBrowser1.DocumentText = ""
        End Try

        'me.WebBrowser1 .Url .
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        MsgBox(Me.WebBrowser1.Url.ToString)
        'If Me.WebBrowser1.IsOffline = True Then
        '    MsgBox("sdfsdfsdf")
        'End If
    End Sub
End Class