Public Class frmLocations

    Private Sub LocationBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.LocationBindingSource.EndEdit()

            If Me.Shops_DBDataSet.HasChanges = True Then
                For Each row As DataRow In Me.Shops_DBDataSet.Location.GetChanges.Rows
                    If row.RowState = DataRowState.Modified Or row.RowState = DataRowState.Added Then
                        If Utils.ValueExist(Me.LocationDataGridView, 1, CStr(row("locationName"))) = True Then
                            Utils.showMessage("Please Duplicates are not accepted in the Location Name Column")
                            Me.LocationBindingSource.CancelEdit()
                            Exit Sub
                        End If
                    End If
                Next
            End If

            Me.LocationTableAdapter.Update(Me.Shops_DBDataSet.Location)
        Catch ex As Exception
            Utils.showError(ex.ToString)
        End Try


    End Sub

    Private Sub frmLocations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Location' table. You can move, or remove it, as needed.
            Me.LocationTableAdapter.Fill(Me.Shops_DBDataSet.Location)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.LocationBindingSource.EndEdit()
        Catch ex As Exception
            Me.LocationBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub LocationDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles LocationDataGridView.DataError
        Try

        Catch ex As Exception
            Me.LocationBindingSource.CancelEdit()
        End Try
    End Sub
End Class