Public Class frmCreditors

    Private Sub CreditorsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Validate()
            Me.CreditorsBindingSource.EndEdit()
            Me.CreditorsTableAdapter.Update(Me.Shops_DBDataSet.creditors)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub frmCreditors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
   
        Try

            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.orderdetails' table. You can move, or remove it, as needed.

            'TODO: This line of code loads data into the 'Shops_DBDataSet.Employees' table. You can move, or remove it, as needed.
            Me.EmployeesTableAdapter.Fill(Me.Shops_DBDataSet.Employees)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.suppliers' table. You can move, or remove it, as needed.
            Me.SuppliersTableAdapter.Fill(Me.Shops_DBDataSet.suppliers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.creditors' table. You can move, or remove it, as needed.
            Me.CreditorsTableAdapter.Fill(Me.Shops_DBDataSet.creditors)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Function getSupplierByID(ByVal ID As Integer)
        Dim membername As String = ""
        Dim row As Shops_DBDataSet.suppliersRow
        For i As Integer = 0 To Me.Shops_DBDataSet.suppliers.Rows.Count - 1
            row = Me.Shops_DBDataSet.suppliers.Rows(i)
            If row.SupplierID = ID Then
                membername = row.CompanyName
                Exit For
            End If
        Next
        Return membername
    End Function

    Private Function getEmployeeByID(ByVal ID As Integer)
        Dim membername As String = ""
        Dim row As Shops_DBDataSet.EmployeesRow
        For i As Integer = 0 To Me.Shops_DBDataSet.Employees.Rows.Count - 1
            row = Me.Shops_DBDataSet.Employees.Rows(i)
            If row.EmployeeID = ID Then
                membername = row.FirstName + "  " + row.LastName
                Exit For
            End If
        Next
        Return membername
    End Function

    Private Sub btnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExporttoExcel.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.CreditorsDataGridView
            Dim column As Integer = 0

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = " CREDITORS INFORMATION "

            For col As Integer = column To dgrd.ColumnCount - 2
                With dtnew
                    .Columns.Add(dgrd.Columns(col).Name, System.Type.GetType("System.String")) 'SN
                    'COMMENTS
                End With

            Next

            'adding the column hearder as the first row
            dr = dtnew.NewRow()
            For col As Integer = column To dgrd.ColumnCount - 2

                With dtnew
                    dr(col - column) = dgrd.Columns(col).HeaderText
                End With

            Next
            dtnew.Rows.Add(dr)

            For i As Integer = 0 To dgrd.RowCount - 1
                dr = dtnew.NewRow()
                Dim count As Integer = 0
                For j As Integer = column To dgrd.ColumnCount - 2


                    If Not IsDBNull(dgrd.Rows(i).Cells(j).Value) Then
                        'If IsNumeric(Me.dGrd.Rows(i).Cells(j).Value.ToString.Trim) Then
                        If j = 1 Then
                            dr(count) = Me.getSupplierByID(CInt(dgrd.Rows(i).Cells(j).Value))
                            ' 
                        ElseIf j = 2 Then
                            dr(count) = Me.getEmployeeByID(CInt(dgrd.Rows(i).Cells(j).Value))
                            'dr(count) = Me.getMaritalStatusByID(CInt(dgrd.Rows(i).Cells(j).Value))
                            'ElseIf j = 9 Then
                            '    dr(count) = Me.getMemberLevelByID(CInt(dgrd.Rows(i).Cells(j).Value))
                            'ElseIf j = 10 Then
                            '    dr(count) = Me.getMemberStatusByID(CInt(dgrd.Rows(i).Cells(j).Value))
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

    Private Sub CreditorsDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles CreditorsDataGridView.DataError
        Try

        Catch ex As Exception
            Me.CreditorsBindingSource.CancelEdit()
        End Try
    End Sub

    
    Private Sub CreditorsDataGridView_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditorsDataGridView.CurrentCellChanged
        Try
            If Not Me.CreditorsDataGridView.CurrentRow Is Nothing Then
                Dim orderid As Integer = CInt(Me.CreditorsDataGridView.CurrentRow.Cells(0).Value)
              
                Me.OrderdetailsTableAdapter.FillByOrderID(Me.Shops_DBDataSet.orderdetails, orderid)
            End If
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub
End Class