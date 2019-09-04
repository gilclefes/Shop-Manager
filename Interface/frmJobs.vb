Public Class frmJobs

    Private Sub JobsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobsBindingNavigatorSaveItem.Click
        Try

            Me.Validate()
            Me.JobsBindingSource.EndEdit()

            If Me.Shops_DBDataSet.HasChanges = True Then
                For Each row As DataRow In Me.Shops_DBDataSet.Jobs.GetChanges.Rows
                    If row.RowState = DataRowState.Modified Or row.RowState = DataRowState.Added Then
                        If Utils.ValueExist(Me.JobsDataGridView, 1, CStr(row("jobName"))) = True Then
                            Utils.showMessage("Please Duplicates are not accepted in the Job Name Column")
                            Me.JobsBindingSource.CancelEdit()
                            Exit Sub
                        End If
                    End If
                Next
            End If

            Me.JobsTableAdapter.Update(Me.Shops_DBDataSet.Jobs)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub frmJobs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Jobs' table. You can move, or remove it, as needed.
            Me.JobsTableAdapter.Fill(Me.Shops_DBDataSet.Jobs)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.JobsBindingSource.EndEdit()
        Catch ex As Exception
            Me.JobsBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub JobsDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles JobsDataGridView.DataError
        Try

        Catch ex As Exception
            Me.JobsBindingSource.CancelEdit()
        End Try
    End Sub
End Class
