Public Class frmWhSalesReport
    Private reportTitle As String
    Private query As String
    Private totalSales As Decimal = 0.0
    Private totalCost As Decimal = 0.0
    Private Profit As Decimal = 0.0

    Dim daSalesReport As New Shops_DBDataSetTableAdapters.SalesReportsTableAdapter
    Dim dtSalesReport As New Shops_DBDataSet.salesReportsDataTable
    'Dim daPurchases As New Shops_DBDataSetTableAdapters.PurchasesReportTableAdapter

    Private Sub rbtRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rbtRange.CheckedChanged
        Me.lblEnd.Visible = Me.rbtRange.Checked
        Me.dtpEnd.Visible = Me.rbtRange.Checked
    End Sub

    Private Sub frmSalesReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Shops_DBDataSet.customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.Shops_DBDataSet.customers)
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.categories' table. You can move, or remove it, as needed.
            Me.CategoriesTableAdapter.Fill(Me.Shops_DBDataSet.categories)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.salesReports' table. You can move, or remove it, as needed.
            'Me.SalesReportsTableAdapter.Fill(Me.Shops_DBDataSet.salesReports)
            Me.cmbReportType.SelectedIndex = 0
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim startDate As DateTime
        Dim endDate As DateTime
        Me.query = ""


        If Me.rbtRange.Checked = True Then
            If Me.dtpStart.Value > Me.dtpEnd.Value Then
                Utils.showMessage("Please start date can not be after end date")
                Exit Sub
            End If

            endDate = CDate(Me.dtpEnd.Value.ToShortDateString & " 23:55:00")
            startDate = CDate(Me.dtpStart.Value.ToShortDateString & " 0:00:00")
        Else
            endDate = CDate(Me.dtpStart.Value.ToShortDateString & " 23:55:00")
            startDate = CDate(Me.dtpStart.Value.ToShortDateString & " 0:00:00")
        End If

        Me.lblCost.Text = ""
        Me.lblProfit.Text = ""
        Me.lblSales.Text = ""

        ' Utils.showMessage("Start Date " + startDate)
        'Utils.showMessage("end Date " + endDate)

        Me.SalesReportsTableAdapter.SelectCommand(0).CommandText =
            "SELECT sales.SalesID, salesdetails.ProductID, products.CategoryID, products.ProductName, salesdetails.UnitPrice, salesdetails.Quantity, salesdetails.Discount, sales.SalesDate, sales.SalesTime, sales.TotalAmount, products.AvgCost, sales.SaleType" &
            " FROM   sales INNER JOIN salesdetails ON sales.SalesID = salesdetails.SalesID INNER JOIN" &
            " products ON salesdetails.ProductID = products.ProductID"

        If rbtRetail.Checked = True Then
            query = " sales.SaleType = 'retail' "
        Else
            query = " sales.SaleType = 'wholesale' "
        End If


        If Me.chkCustomer.Checked = False Then


            If Me.cmbReportType.SelectedIndex = 0 Then
                If Me.rbtDaily.Checked Then
                    reportTitle = "Sales Report For All Products Sold On:  " & Me.dtpStart.Value.ToShortDateString

                    ' Me.SalesReportsTableAdapter.FillByAllEqual(Me.Shops_DBDataSet.salesReports, Me.dtpStart.Value.Day,
                    ' Me.dtpStart.Value.Month, Me.dtpStart.Value.Year)
                    query = query & " and sales.SalesDate >= '" & _
                                 startDate & _
                                 "' and sales.SalesDate <= '" & _
                                 endDate & "'"
                Else
                    reportTitle = "Sales Report For All Products Sold Between :  " & Me.dtpStart.Value.ToShortDateString &
                                  "  and  " & Me.dtpEnd.Value.ToShortDateString

                    ' Me.SalesReportsTableAdapter.FillByAllBetween(Me.Shops_DBDataSet.salesReports,
                    '  CDate(Me.dtpStart.Value.ToShortDateString),
                    ' CDate(Me.dtpEnd.Value.ToShortDateString))
                    query = query & " and sales.SalesDate >= '" & _
                                startDate & _
                                "' and sales.SalesDate <= '" & _
                                endDate & "'"
                End If

            ElseIf Me.cmbReportType.SelectedIndex = 1 Then
                Dim pid As Integer = CInt(Me.Shops_DBDataSet.products.Rows(Me.cmbProducts.SelectedIndex)(0).ToString)
                Dim pname As String = Me.Shops_DBDataSet.products.Rows(Me.cmbProducts.SelectedIndex)(2).ToString.ToUpper
                If Me.rbtDaily.Checked Then
                    reportTitle = "Sales Report For Product: " & pname & " : Sold On:  " &
                                  Me.dtpStart.Value.ToShortDateString
                    'Me.SalesReportsTableAdapter.FillByProductEqual(Me.Shops_DBDataSet.salesReports, pid,
                    '    Me.dtpStart.Value.Day, Me.dtpStart.Value.Month,
                    '  Me.dtpStart.Value.Year)

                    query = query & " and salesdetails.ProductID =" & pid & " and sales.SalesDate >= '" & _
                               startDate & _
                               "' and sales.SalesDate <= '" & _
                               endDate & "'"
                Else
                    reportTitle = "Sales Report For Product: " & pname & " : Sold Between :  " &
                                  Me.dtpStart.Value.ToShortDateString & "  and  " & Me.dtpEnd.Value.ToShortDateString
                    'Me.SalesReportsTableAdapter.FillByProductBetween(Me.Shop's_DBDataSet.salesReports,
                    '     CDate(Me.dtpStart.Value.ToShortDateString),
                    '   CDate(Me.dtpEnd.Value.ToShortDateString), pid)

                    query = query & " and salesdetails.ProductID =" & pid & " and sales.SalesDate >= '" & _
                               startDate & _
                               "' and sales.SalesDate <= '" & _
                               endDate & "'"

                End If
            ElseIf Me.cmbReportType.SelectedIndex = 2 Then
                Dim cid As Integer = CInt(Me.Shops_DBDataSet.categories.Rows(Me.cmbProducts.SelectedIndex)(0).ToString)
                Dim cname As String = Me.Shops_DBDataSet.categories.Rows(Me.cmbProducts.SelectedIndex)(1).ToString

                If Me.rbtDaily.Checked Then
                    reportTitle = "Sales Report For Product Category: " & cname & " : Sold On:  " &
                                  Me.dtpStart.Value.ToShortDateString
                    'Me.SalesReportsTableAdapter.FillByCategoryEqual(Me.Shops_DBDataSet.salesReports, cid,
                    ' Me.dtpStart.Value.Day, Me.dtpStart.Value.Month,
                    '  Me.dtpStart.Value.Year)

                    query = query & " and products.CategoryID =" & cid & " and sales.SalesDate >= '" & _
                           startDate & _
                           "' and sales.SalesDate <= '" & _
                           endDate & "'"

                Else
                    reportTitle = "Sales Report For Product Category: " & cname & " : Sold On:  " &
                                  Me.dtpStart.Value.ToShortDateString
                    'Me.SalesReportsTableAdapter.FillByCategoryBetween(Me.Shops_DBDataSet.salesReports,
                    '    CDate(Me.dtpStart.Value.ToShortDateString),
                    '   CDate(Me.dtpEnd.Value.ToShortDateString), cid)

                    query = query & " and products.CategoryID =" & cid & " and sales.SalesDate >= '" & _
                        startDate & _
                        "' and sales.SalesDate <= '" & _
                        endDate & "'"
                End If
            End If
        Else
            If Me.cmbCustomer.SelectedIndex = -1 Then
                Utils.showMessage("Please select the customer")
                Exit Sub
            End If

            Dim cid As Integer = Me.Shops_DBDataSet.customers(Me.cmbCustomer.SelectedIndex).CustomerID
            Dim customerName As String = Me.Shops_DBDataSet.customers(Me.cmbCustomer.SelectedIndex).CompanyName.ToString

            If Me.rbtDaily.Checked Then
                reportTitle = "Sales Report For Customer: " & customerName & " : Sold On:  " &
                              Me.dtpStart.Value.ToShortDateString

                'Me.SalesReportsTableAdapter.FillByCustomerEqual(Me.Shops_DBDataSet.salesReports, cid,
                '                                                Me.dtpStart.Value.Day, Me.dtpStart.Value.Month,
                '                                                Me.dtpStart.Value.Year)

                query = query & " and sales.CustomerID =" & cid & " and sales.SalesDate >= '" & _
                      startDate & _
                      "' and sales.SalesDate <= '" & _
                      endDate & "'"
            Else
                reportTitle = "Sales Report For Customer: " & customerName & " : Sold Between :  " &
                              Me.dtpStart.Value.ToShortDateString & "  and  " & Me.dtpEnd.Value.ToShortDateString
                'Me.SalesReportsTableAdapter.FillByCustomerBetween(Me.Shops_DBDataSet.salesReports,
                '                                                  CDate(Me.dtpStart.Value.ToShortDateString),
                '                                                  CDate(Me.dtpEnd.Value.ToShortDateString), cid)

                query = query & " and sales.CustomerID =" & cid & " and sales.SalesDate >= '" & _
                   startDate & _
                   "' and sales.SalesDate <= '" & _
                   endDate & "'"

                ' Utils.showMessage("customer query " + query)
            End If

        End If

        Me.SalesReportsTableAdapter.FillByWhere(Me.Shops_DBDataSet.salesReports, Me.query)


        If Me.SalesReportsDataGridView.RowCount <= 0 Then
            Utils.showMessage("No Record Found")
        Else
            Me.totalCost = 0.0
            Me.totalSales = 0.0
            Dim unitcost As Decimal = 0.0
            Dim unitprice As Decimal = 0.0
            Dim qty As Double = 0
            Dim pid As Integer = 0.0

            For i As Integer = 0 To Me.SalesReportsDataGridView.RowCount - 1
                pid = CInt(Me.SalesReportsDataGridView.Rows(i).Cells(1).Value.ToString)
                unitprice = CDec(Me.SalesReportsDataGridView.Rows(i).Cells(5).Value.ToString)
                qty = CDbl(Me.SalesReportsDataGridView.Rows(i).Cells(6).Value.ToString)


                If Not IsDBNull(Me.SalesReportsDataGridView.Rows(i).Cells("AvgCost").Value) Then
                    unitcost = CDec(Me.SalesReportsDataGridView.Rows(i).Cells("AvgCost").Value.ToString)
                Else
                    unitcost = 0.0
                End If

                'If Me.daPurchases.getUnitCost(pid, Me.dtpEnd.Value).HasValue Then
                '    unitcost = Me.daPurchases.getUnitCost(pid, Me.dtpEnd.Value)
                'Else
                '    unitcost = 0.0
                'End If


                Me.totalSales = Me.totalSales + (unitprice * qty)
                Me.totalCost = Me.totalCost + (unitcost * qty)
            Next

            Me.lblSales.Text = String.Format("Total Sales Made for the Selected Date(s)  = {0}", Me.totalSales)
            Me.lblCost.Text = String.Format("Total Purchases Made for the Selected Date(s)  = {0}", Me.totalCost)

            Me.lblProfit.Text = String.Format("Total Profit Made for the Slected Date(s)  = {0}",
                                              (Me.totalSales - Me.totalCost))
        End If
    End Sub

    Private Sub cmbReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmbReportType.SelectedIndexChanged
        If Me.cmbReportType.SelectedIndex = 1 Then
            Me.cmbProducts.Visible = True
            Me.cmbProducts.DataSource = Me.Shops_DBDataSet.products
            Me.cmbProducts.DisplayMember = Me.Shops_DBDataSet.products.ProductNameColumn.ToString
            ' Me.cmbProducts.ValueMember = Me.Shops_DBDataSet.products.Columns(0).ToString
        ElseIf Me.cmbReportType.SelectedIndex = 2 Then
            Me.cmbProducts.Visible = True
            Me.cmbProducts.DataSource = Me.Shops_DBDataSet.categories
            Me.cmbProducts.DisplayMember = Me.Shops_DBDataSet.categories.CateryNameColumn.ToString
            'Me.cmbProducts.ValueMember = Me.Shops_DBDataSet.productsDataTable .
        Else
            Me.cmbProducts.Visible = False
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If Me.Shops_DBDataSet.salesReports.Rows.Count > 0 Then
                Dim rpd As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                rpd.Load(Application.StartupPath & "\Reports\salesReports.rpt")
                rpd.SetDataSource(Me.Shops_DBDataSet)

                rpd.SetParameterValue("title", reportTitle)
                Dim frm As New frmReportFace
                frm.Crv1.ReportSource = rpd
                frm.Show()
            Else
                Utils.showMessage("Please there is nothing to print")
            End If
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try
    End Sub


    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.SalesReportsDataGridView
            Dim column As Integer = 3

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = Me.reportTitle.ToUpper

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

                        If j = 7 Then
                            dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
                        ElseIf j = 8 Then
                            dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToLongTimeString
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Not Me.SalesReportsDataGridView.CurrentRow Is Nothing Then
                Dim index As Integer = Me.SalesReportsDataGridView.CurrentRow.Index
                Dim custId As Integer = 0
                Dim salesId As Integer = CInt(Me.SalesReportsDataGridView.CurrentRow.Cells(0).Value)
                Utils.showMessage("sales id " & salesId)
                If chkCustomer.Checked = True Then
                    custId = Me.Shops_DBDataSet.customers(cmbCustomer.SelectedIndex).CustomerID
                End If
              
                Dim custName As String = Me.getCustomerByID(custId)

                Me.daSalesReport.FillBySalesId(Me.dtSalesReport, salesId)
                '  Me.dtSalesReport(

                Dim rpd As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                rpd.Load(Application.StartupPath & "\Reports\SalesReceipt.rpt")
                rpd.SetDataSource(dtSalesReport.CopyToDataTable())

                rpd.SetParameterValue("custName", custName)
                '  rpd.SetParameterValue("AmountLeft", amountDue)
                Dim frm As New frmReportFace
                frm.Crv1.ReportSource = rpd
                frm.Show()

            End If
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub
End Class