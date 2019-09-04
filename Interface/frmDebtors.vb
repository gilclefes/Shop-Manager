Public Class frmDebtors
    Dim daSalesReport As New Shops_DBDataSetTableAdapters.salesReportsTableAdapter
    Dim dtSalesReport As New Shops_DBDataSet.salesReportsDataTable


    Private Sub DebtorsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Validate()
            Me.DebtorsBindingSource.EndEdit()
            Me.DebtorsTableAdapter.Update(Me.Shops_DBDataSet.Debtors)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub frmDebtors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        Try
            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Employees' table. You can move, or remove it, as needed.
            Me.EmployeesTableAdapter.Fill(Me.Shops_DBDataSet.Employees)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.customers' table. You can move, or remove it, as needed.
            Me.CustomersTableAdapter.Fill(Me.Shops_DBDataSet.customers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Debtors' table. You can move, or remove it, as needed.
            Me.DebtorsTableAdapter.Fill(Me.Shops_DBDataSet.Debtors)

            Me.DebtorsReportTableAdapter.Fill(Me.Shops_DBDataSet.DebtorsReport)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub DebtorsDataGridView_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Me.DebtorsReportDataGridView.Columns(1).ToolTipText = "werwer"

        End If
    End Sub


    Private Function getCustomerByID(ByVal ID As Integer)
        Dim membername As String = ""
        Dim row As Shops_DBDataSet.customersRow
        For i As Integer = 0 To Me.Shops_DBDataSet.customers.Rows.Count - 1
            row = Me.Shops_DBDataSet.customers.Rows(i)
            If row.CustomerID = ID Then
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
            Dim dgrd As DataGridView = Me.DebtorsReportDataGridView
            Dim column As Integer = 0

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = " DEBTORS INFORMATION "

            For col As Integer = column To dgrd.ColumnCount - 4
                With dtnew
                    .Columns.Add(dgrd.Columns(col).Name, System.Type.GetType("System.String")) 'SN
                    'COMMENTS
                End With

            Next

            'adding the column hearder as the first row
            dr = dtnew.NewRow()
            For col As Integer = column To dgrd.ColumnCount - 4

                With dtnew
                    dr(col - column) = dgrd.Columns(col).HeaderText
                End With

            Next
            dtnew.Rows.Add(dr)

            For i As Integer = 0 To dgrd.RowCount - 1
                dr = dtnew.NewRow()
                Dim count As Integer = 0
                For j As Integer = column To dgrd.ColumnCount - 4


                    If Not IsDBNull(dgrd.Rows(i).Cells(j).Value) Then
                        'If IsNumeric(Me.dGrd.Rows(i).Cells(j).Value.ToString.Trim) Then
                        If j = 1 Then
                            ' dr(count) = Me.getCustomerByID(CInt(dgrd.Rows(i).Cells(j).Value))
                            dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
                            'ElseIf j = 2 Then
                            '    dr(count) = Me.getEmployeeByID(CInt(dgrd.Rows(i).Cells(j).Value))
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

    Private Sub DebtorsDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Try

        Catch ex As Exception
            Me.DebtorsBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub DebtorsDataGridView_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If Not Me.DebtorsReportDataGridView.CurrentRow Is Nothing Then
                Dim index As Integer = Me.DebtorsReportDataGridView.CurrentRow.Index
                Dim custId As Integer = CInt(Me.DebtorsReportDataGridView.CurrentRow.Cells("DataGridViewTextBoxColumn11").Value)
                Dim salesId As Integer = CInt(Me.DebtorsReportDataGridView.CurrentRow.Cells("DataGridViewTextBoxColumn12").Value)
                Dim amountDue As Decimal = CDec(Me.DebtorsReportDataGridView.CurrentRow.Cells("DataGridViewTextBoxColumn4").Value)

                Dim custName As String = Me.getCustomerByID(custId)

                Me.daSalesReport.FillBySalesId(Me.Shops_DBDataSet.salesReports, salesId)

                Dim rpd As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                rpd.Load(Application.StartupPath & "\Reports\SalesInvoice.rpt")
                rpd.SetDataSource(Me.Shops_DBDataSet)

                rpd.SetParameterValue("custName", custName)
                rpd.SetParameterValue("AmountLeft", amountDue)
                Dim frm As New frmReportFace
                frm.Crv1.ReportSource = rpd
                frm.Show()

            End If
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub DebtorsReportDataGridView_CurrentCellChanged(sender As System.Object, e As System.EventArgs) Handles DebtorsReportDataGridView.CurrentCellChanged
        Try
            If Not Me.DebtorsReportDataGridView.CurrentRow Is Nothing Then
                Dim orderid As Integer = CInt(Me.DebtorsReportDataGridView.CurrentRow.Cells("DataGridViewTextBoxColumn12").Value)

                Me.SalesdetailsTableAdapter.FillBySalesID(Me.Shops_DBDataSet.salesdetails, orderid)
            End If
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub
End Class