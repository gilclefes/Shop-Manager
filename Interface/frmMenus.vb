Public Class frmMenus
    Public menus As List(Of menusClass)

    Private Sub TblMenuBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TblMenuBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.TblMenuBindingSource.EndEdit()
            Me.TblMenuTableAdapter.Update(Me.Shops_DBDataSet.tblMenu)
        Catch ex As Exception
            Utils.showException(ex)
        End Try


    End Sub

    Private Sub frmMenus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'inserting menu names in DB
            Me.TblMenuTableAdapter.Fill(Me.Shops_DBDataSet.tblMenu)

            If Me.Shops_DBDataSet.tblMenu.Rows.Count <= 0 Then
                For Each m As menusClass In menus
                    Me.TblMenuTableAdapter.InsertQuery(m.MenuName, m.MenuText)
                Next

                Me.TblMenuTableAdapter.Fill(Me.Shops_DBDataSet.tblMenu)
            Else

            End If

        Catch ex As Exception
            Utils.showException(ex)
        End Try
        'TODO: This line of code loads data into the 'Shops_DBDataSet.tblMenu' table. You can move, or remove it, as needed.
        ' Me.TblMenuTableAdapter.Fill(Me.Shops_DBDataSet.tblMenu)

    End Sub

    Private Sub TblMenuDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TblMenuDataGridView.DataError
        Try
            Utils.showException(e.Exception)
        Catch ex As Exception
            Me.TblMenuDataGridView.CancelEdit()
        End Try
    End Sub
End Class