Public Class frmChangePassword
    Public userid As String
    Public password As String
    Public oldPass As String
    Private daUsers As New Shops_DBDataSetTableAdapters.userstblTableAdapter
    Private dtUsers As New Shops_DBDataSet.userstblDataTable

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If Me.txtCurrentPass.Text = "" Then
            Me.btnOk.DialogResult = Windows.Forms.DialogResult.Ignore
            Utils.showMessage("Please Current Password can not be empty")
            Exit Sub
        End If

        If Me.txtNewPass.Text = "" Or Me.txtConfrimPass.Text = "" Then
            Me.btnOk.DialogResult = Windows.Forms.DialogResult.Ignore
            Utils.showMessage("Please Password can not be empty")
            Exit Sub
        End If


        Me.daUsers.FillByUser(Me.dtUsers, Me.userid)

        If Me.dtUsers.Rows.Count <= 0 Then
            Me.btnOk.DialogResult = Windows.Forms.DialogResult.No
            Utils.showMessage("An Error Occured")

        Else
            Dim row As Shops_DBDataSet.userstblRow = Me.dtUsers.Rows(0)
            Me.password = Utils.decrypt(row.Passwd)

            If String.Compare(Me.password, Me.txtCurrentPass.Text.Trim) = 0 Then
                If String.Compare(Me.txtConfrimPass.Text.Trim, Me.txtNewPass.Text.Trim, False) = 0 Then
                    password = Me.txtNewPass.Text
                    Me.daUsers.UpdateQuery(Utils.encrypt(password), Me.userid)
                    Utils.showMessage("Please Successfully Changed")
                    Me.btnOk.DialogResult = Windows.Forms.DialogResult.OK
                Else

                    Me.btnOk.DialogResult = Windows.Forms.DialogResult.Ignore
                    Utils.showMessage("Please New and Confirm Passwords Should be the Same")
                End If
            Else

                Me.btnOk.DialogResult = Windows.Forms.DialogResult.Ignore
                Utils.showMessage("Please Enter Your Correct Password")
            End If

        End If
    End Sub

    Private Sub frmChangePassword_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnOk.DialogResult = Windows.Forms.DialogResult.OK Then
        ElseIf Me.btnOk.DialogResult = Windows.Forms.DialogResult.Ignore Then
            'If Utils.QuestionPrompt("Do you want to Quit program") = Windows.Forms.DialogResult.Yes Then
            'Else
            e.Cancel = True
            'End If

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.btnOk.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
End Class