Public Class frmPromptSettings
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
   
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not IsNumeric(Me.txtVAT.Text) Then
            Utils.showMessage("Please VAT should be numeric")
            Exit Sub
        End If

        If CDec(Me.txtVAT.Text) > 100 Then
            Utils.showMessage("Please VAT can not be greater than 100%")
            Exit Sub
        End If

        If CDec(Me.txtVAT.Text) < 0 Then
            Utils.showMessage("Please VAT can not be less than 100%")
            Exit Sub
        End If

        Try
            With My.Settings
                .expiryPrompt = Me.nudExpiry.Value
                ' .reorderPromts = Me.nudReorder.Value
                .VAT = CDec(Me.txtVAT.Text)
                .PrintReceipts = Me.chkReceipts.Checked
            End With
            My.Settings.Save()
            Utils.showMessage("Settings saved successfully")
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

   
    Private Sub frmPromptSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            With My.Settings
                Me.nudExpiry.Value = .expiryPrompt
                'Me.nudReorder.Value = .reorderPromts
                Me.txtVAT.Text = .VAT
                Me.chkReceipts.Checked = .PrintReceipts
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class