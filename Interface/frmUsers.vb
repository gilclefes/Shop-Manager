
Public Class frmUsers

    Private Sub UserstblBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserstblBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.UserstblBindingSource.EndEdit()

            If Me.Shops_DBDataSet.HasChanges = True Then
                For Each row As Shops_DBDataSet.userstblRow In Me.Shops_DBDataSet.userstbl.GetChanges.Rows


                    If row.RowState = DataRowState.Modified Or row.RowState = DataRowState.Added Then
                        If Utils.ValueExist(Me.UserstblDataGridView, 2, CStr(row("employeeid"))) = True Then
                            Utils.showMessage("Please Duplicates are not accepted in the Employee Column")
                            Me.UserstblBindingSource.CancelEdit()
                            Exit Sub
                        End If
                    End If

                Next
            End If


            For Each row As Shops_DBDataSet.userstblRow In Me.Shops_DBDataSet.userstbl.Rows
                If row.RowState = DataRowState.Added Then
                    row.Passwd = Utils.encrypt("user")
                End If
            Next

            Me.UserstblTableAdapter.Update(Me.Shops_DBDataSet.userstbl)

        Catch ex As Exception
            Utils.showError(ex.ToString)
        End Try

    End Sub

    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.usergroups' table. You can move, or remove it, as needed.
            Me.UsergroupsTableAdapter.Fill(Me.Shops_DBDataSet.usergroups)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Employees' table. You can move, or remove it, as needed.
            Me.EmployeesTableAdapter.Fill(Me.Shops_DBDataSet.Employees)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.userstbl' table. You can move, or remove it, as needed.
            Me.UserstblTableAdapter.Fill(Me.Shops_DBDataSet.userstbl)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try
    End Sub


    Private Sub tsbResetPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbResetPassword.Click
        Try
            If Utils.QuestionPrompt("Are you sure to reset Password") = Windows.Forms.DialogResult.Yes Then
                If Me.UserstblDataGridView.CurrentRow.Index >= 0 Then
                    Me.UserstblBindingSource.EndEdit()
                    Me.Shops_DBDataSet.userstbl.Rows(Me.UserstblDataGridView.CurrentRow.Index)("Passwd") = Utils.encrypt("user")
                    Me.UserstblTableAdapter.Update(Me.Shops_DBDataSet.userstbl)
                End If
            End If

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.UsergroupsBindingSource.EndEdit()
        Catch ex As Exception
            Me.UsergroupsBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        If Me.Validate And Not Me.UserstblBindingSource Is Nothing Then
            If Me.UserstblBindingSource.Position >= 0 Then
                If String.Equals("admin", Me.Shops_DBDataSet.userstbl.Rows(Me.UserstblBindingSource.Position)(0).ToString) Then
                    Utils.showMessage("Please Admin Account cannot be deleted")
                Else
                    Me.UserstblBindingSource.RemoveCurrent()
                    Me.UserstblBindingSource.CancelEdit()
                End If
            End If
        End If
    End Sub
End Class