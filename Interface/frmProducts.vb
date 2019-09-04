Imports System.Data.SqlClient
Public Class frmProducts

    Private Sub ControlsInitialize()
        Me.SplitContainer2.Panel1Collapsed = False
        Me.SplitContainer2.Panel2Collapsed = True

    End Sub

    Private Sub EditMode()
        Me.SplitContainer2.Panel1Collapsed = True
        Me.SplitContainer2.Panel2Collapsed = False
    End Sub

    Private Sub Switch()

        Me.Validate()
        Me.CategoriesBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Try

      

        'If Me.Shops_DBDataSet.HasChanges = True Then
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()

        If Me.Shops_DBDataSet.HasChanges = True Then
            For Each row As DataRow In Me.Shops_DBDataSet.products.GetChanges.Rows
                If row.RowState = DataRowState.Modified Or row.RowState = DataRowState.Added Then
                    If Utils.ValueExist(Me.ProductsDataGridView, 2, CStr(row("productName"))) = True Then
                        Utils.showMessage("Please Duplicates are not accepted in the Product Name Column")
                        Me.ProductsBindingSource.CancelEdit()
                        Exit Sub
                    End If
                End If
            Next
        End If


        Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)
        'Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)


        'Using conn As SqlConnection = Me.ProductsTableAdapter.Connection
        '    conn.Open()
        '    Dim tran As SqlTransaction = Nothing
        '    Try
        '        tran = conn.BeginTransaction
        '        Me.ProductsTableAdapter.Transaction = tran
        '        Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)
        '        tran.Commit()
        '    Catch ex As Exception
        '        If Not tran Is Nothing Then
        '            tran.Rollback()
        '        End If
        '    End Try
        '    tran.Dispose()
        '    conn.Close()
        'End Using


        'Me.Validate()
        'Me.ProductsBindingSource.EndEdit()
        'Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)


        'End If

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try


    End Sub

    Private Sub frmProducts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Location' table. You can move, or remove it, as needed.
            Me.LocationTableAdapter.Fill(Me.Shops_DBDataSet.Location)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.categories' table. You can move, or remove it, as needed.
            Me.CategoriesTableAdapter.Fill(Me.Shops_DBDataSet.categories)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
            Me.ControlsInitialize()

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.ProductsBindingSource.EndEdit()
            EditMode()
        Catch ex As Exception
            Me.ProductsBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub ProductsDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ProductsDataGridView.DataError
        Try
            Utils.showException(e.Exception)
        Catch ex As Exception
            Me.ProductsBindingSource.CancelEdit()
        End Try
    End Sub

    Private Function getLocationByID(ByVal ID As Integer)
        Dim value As String = ""
        Dim row As Shops_DBDataSet.LocationRow
        For i As Integer = 0 To Me.Shops_DBDataSet.Location.Rows.Count - 1
            row = Me.Shops_DBDataSet.Location.Rows(i)
            If row.LocationID = ID Then
                value = row.LocationName
                Exit For
            End If
        Next
        Return value
    End Function

    Private Function getCategoryByID(ByVal ID As Integer)
        Dim value As String = ""
        Dim row As Shops_DBDataSet.categoriesRow
        For i As Integer = 0 To Me.Shops_DBDataSet.categories.Rows.Count - 1
            row = Me.Shops_DBDataSet.categories.Rows(i)
            If row.CategoryID = ID Then
                value = row.CateryName
                Exit For
            End If
        Next
        Return value
    End Function

    Private Sub btnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExporttoExcel.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.ProductsDataGridView
            Dim column As Integer = 2

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = " PRODUCTS INFORMATION "

            For col As Integer = column To dgrd.ColumnCount - 1
                With dtnew
                    .Columns.Add(dgrd.Columns(col).Name, System.Type.GetType("System.String")) 'SN
                    'COMMENTS
                End With

            Next

            'adding the column hearder as the first row
            dr = dtnew.NewRow()
            For col As Integer = column To dgrd.ColumnCount - 1

                With dtnew
                    dr(col - column) = dgrd.Columns(col).HeaderText
                End With

            Next
            dtnew.Rows.Add(dr)

            For i As Integer = 0 To dgrd.RowCount - 1
                dr = dtnew.NewRow()
                Dim count As Integer = 0
                For j As Integer = column To dgrd.ColumnCount - 1


                    If Not IsDBNull(dgrd.Rows(i).Cells(j).Value) Then

                        'If j = 3 Then
                        '    dr(count) = Me.getCategoryByID(CInt(dgrd.Rows(i).Cells(j).Value))

                        If j = 8 Then
                            dr(count) = Me.getLocationByID(CInt(dgrd.Rows(i).Cells(j).Value))
                        Else
                            dr(count) = dgrd.Rows(i).Cells(j).Value
                        End If

                    End If

                    count = count + 1
                Next
                dtnew.Rows.Add(dr)
            Next

            Utils.ExportToExcel(title, dtnew)
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try
    End Sub

    Private Sub EditToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles EditToolStripButton.Click
        EditMode()
    End Sub

    Private Sub SwitchToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles SwitchToolStripButton.Click
        Switch()
    End Sub

    Private Sub ProductsDataGridView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductsDataGridView.CellDoubleClick
        EditMode()
    End Sub

    Private Sub ProductsBindingSource_AddingNew(sender As System.Object, e As System.ComponentModel.AddingNewEventArgs) Handles ProductsBindingSource.AddingNew
        Me.Shops_DBDataSet.products.AvgCostColumn.DefaultValue = 0.0
    End Sub
End Class