Public Class frmProductsCompare

    Private date1 As Date
    Private date2 As Date
    Dim title As String = ""
    Dim daPurchases As New Shops_DBDataSetTableAdapters.PurchasesReportTableAdapter


    Private Sub frmProductsCompare_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.ProductsCompare' table. You can move, or remove it, as needed.
            'Me.ProductsCompareTableAdapter.Fill(Me.Shops_DBDataSet.ProductsCompare)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
            Me.cmbReportType.SelectedIndex = 0
        Catch ex As Exception
            Utils.showException(ex)
        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try


            Dim products As String = ""

            'checking if the start date 
            If CDate(Me.dtpStartDate.Value.ToShortDateString) > CDate(Now.Date.ToShortDateString) Then
                Utils.showMessage("Start Date can not be greater than today")
                Exit Sub
            End If

            If CDate(Me.dtpStartDate.Value.ToShortDateString) > CDate(Me.dtpEndDate.Value.ToShortDateString) Then
                Utils.showMessage("Start Date can not be greater than End Date")
                Exit Sub
            End If

            date1 = CDate(Me.dtpStartDate.Value.ToShortDateString)
            date2 = CDate(Me.dtpEndDate.Value.ToShortDateString)

            'get selected products to compare
            Dim selected As Boolean = False
            For i As Integer = 0 To Me.ProductsDataGridView.RowCount - 1
                If CBool(Me.ProductsDataGridView.Rows(i).Cells(11).Value) = True Then
                    selected = True

                    If products = "" Then
                        products = products & Me.ProductsDataGridView.Rows(i).Cells(0).Value & ""
                    Else
                        products = products & "," & Me.ProductsDataGridView.Rows(i).Cells(0).Value
                    End If

                End If
            Next

            If selected = False Then
                Utils.showMessage("No product selected for report")
                Exit Sub
            End If

           
            title = " PRODUCT COMPARISON REPORT BETWEEN THE DATE :  " & date1.ToLongDateString & "    " & date2.ToLongDateString
            Dim query As String = ""
          

            If Me.cmbReportType.SelectedIndex = 0 Then
                Me.ProductsCompareTableAdapter.SelectCommand(0).CommandText = "SELECT distinct products.ProductID, products.ProductName, SUM(salesdetails.UnitPrice) AS UnitPrice, SUM(salesdetails.Quantity) AS Quantity, CONVERT(varchar(20), sales.SalesDate, 107) AS SalesDate , SUM(salesdetails.Discount) AS Discount, SUM(sales.TotalAmount) AS TotalAmount " & _
                " FROM salesdetails INNER JOIN sales ON salesdetails.SalesID = sales.SalesID INNER JOIN " & _
                " products ON salesdetails.ProductID = products.ProductID "

                query = " products.ProductID IN ( " & products & ") AND (sales.SalesDate >=  '" & date1 & "') AND (sales.SalesDate <=  '" & date2 & "' )" & _
                            " GROUP BY products.ProductID, products.ProductName, CONVERT(varchar(20), sales.SalesDate, 107)"

                Me.ProductsCompareTableAdapter.FillByWhere(Me.Shops_DBDataSet.ProductsCompare, query)
                title = "DAILY " & title
            ElseIf Me.cmbReportType.SelectedIndex = 1 Then
                Me.ProductsCompareTableAdapter.SelectCommand(0).CommandText = "SELECT distinct products.ProductID, products.ProductName, SUM(salesdetails.UnitPrice) AS UnitPrice, SUM(salesdetails.Quantity) AS Quantity,  dbo.monthName(sales.SalesDate) AS SalesDate , SUM(salesdetails.Discount) AS Discount, SUM(sales.TotalAmount) AS TotalAmount " & _
                " FROM salesdetails INNER JOIN sales ON salesdetails.SalesID = sales.SalesID INNER JOIN " & _
                " products ON salesdetails.ProductID = products.ProductID "

                query = " products.ProductID IN ( " & products & ") AND (sales.SalesDate >=  '" & date1 & "') AND (sales.SalesDate <=  '" & date2 & "' )" & _
                            " GROUP BY products.ProductID, products.ProductName,  dbo.monthName(sales.SalesDate)"

                Me.ProductsCompareTableAdapter.FillByWhere(Me.Shops_DBDataSet.ProductsCompare, query)
                title = "MONTHLY " & title
            ElseIf Me.cmbReportType.SelectedIndex = 2 Then
                Me.ProductsCompareTableAdapter.SelectCommand(0).CommandText = "SELECT distinct products.ProductID, products.ProductName, SUM(salesdetails.UnitPrice) AS UnitPrice, SUM(salesdetails.Quantity) AS Quantity, dbo.quarterName(sales.SalesDate) AS SalesDate , SUM(salesdetails.Discount) AS Discount, SUM(sales.TotalAmount) AS TotalAmount " & _
                 " FROM salesdetails INNER JOIN sales ON salesdetails.SalesID = sales.SalesID INNER JOIN " & _
                " products ON salesdetails.ProductID = products.ProductID "

                query = " products.ProductID IN ( " & products & ") AND (sales.SalesDate >=  '" & date1 & "') AND (sales.SalesDate <=  '" & date2 & "' )" & _
                            " GROUP BY products.ProductID, products.ProductName, dbo.quarterName(sales.SalesDate)"

                Me.ProductsCompareTableAdapter.FillByWhere(Me.Shops_DBDataSet.ProductsCompare, query)
                title = "QUARTERLY " & title
            ElseIf Me.cmbReportType.SelectedIndex = 3 Then
                Me.ProductsCompareTableAdapter.SelectCommand(0).CommandText = "SELECT distinct products.ProductID, products.ProductName, SUM(salesdetails.UnitPrice) AS UnitPrice, SUM(salesdetails.Quantity) AS Quantity,  year(sales.SalesDate) AS SalesDate , SUM(salesdetails.Discount) AS Discount, SUM(sales.TotalAmount) AS TotalAmount " & _
                " FROM salesdetails INNER JOIN sales ON salesdetails.SalesID = sales.SalesID INNER JOIN " & _
                " products ON salesdetails.ProductID = products.ProductID "

                query = " products.ProductID IN ( " & products & ") AND (sales.SalesDate >=  '" & date1 & "') AND (sales.SalesDate <=  '" & date2 & "' )" & _
                           " GROUP BY products.ProductID, products.ProductName,  year(sales.SalesDate)"

                Me.ProductsCompareTableAdapter.FillByWhere(Me.Shops_DBDataSet.ProductsCompare, query)
                title = "YEARLY " & title
            End If

            If Me.ProductsCompareDataGridView.RowCount <= 0 Then
                Utils.showMessage("No record found for the selected date range, select new dates and search again")
            Else
                Dim pid As Integer = 0
                Dim costprice As Integer = 0
                For i As Integer = 0 To Me.ProductsCompareDataGridView.RowCount - 1
                    pid = CInt(Me.ProductsCompareDataGridView.Rows(i).Cells(0).Value)

                    If Not IsDBNull(Me.daPurchases.getUnitCost(pid, date2)) Then
                        costprice = Me.daPurchases.getUnitCost(pid, date2)
                    Else
                        costprice = 0.0
                    End If

                    'costprice = Me.daPurchases.getUnitCost(pid, date2)
                    'Utils.showMessage(costprice.ToString)
                    'Utils.showMessage(Me.ProductsCompareDataGridView.Rows(i).Cells(3).Value.ToString)
                    Me.ProductsCompareDataGridView.Rows(i).Cells(7).Value = CInt(Me.ProductsCompareDataGridView.Rows(i).Cells(3).Value) * costprice
                    Me.ProductsCompareDataGridView.Rows(i).Cells(8).Value = CDec(Me.ProductsCompareDataGridView.Rows(i).Cells(6).Value) - (CInt(Me.ProductsCompareDataGridView.Rows(i).Cells(3).Value) * costprice)
                Next
            End If


        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Me.ProductsCompareDataGridView.RowCount > 0 Then
            Try
                Dim rpd As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                rpd.Load(Application.StartupPath & "\Reports\productsCompare.rpt")
                rpd.SetDataSource(Me.Shops_DBDataSet)
                rpd.SetParameterValue("title", title)
               


                Dim frm As New frmReportFace
                frm.crv1.ReportSource = rpd
                frm.Show()
            Catch ex As Exception
                Utils.showMessage(ex.ToString)
            End Try
        Else
            Utils.showMessage("NO DATA TO PRINT")
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.ProductsCompareDataGridView
            Dim column As Integer = 1

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = Me.title.ToUpper

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

                        'If j = 6 Then
                        '    dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
                        'ElseIf j = 7 Then
                        '    dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToLongTimeString
                        'Else
                        dr(count) = dgrd.Rows(i).Cells(j).Value
                        'End If

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
End Class