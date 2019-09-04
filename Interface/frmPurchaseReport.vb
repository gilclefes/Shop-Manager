Public Class frmPurchaseReport
    Private reportTitle As String

    Private Sub rbtRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtRange.CheckedChanged
        Me.lblEnd.Visible = Me.rbtRange.Checked
        Me.dtpEnd.Visible = Me.rbtRange.Checked
    End Sub

    Private Sub frmSalesReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.suppliers' table. You can move, or remove it, as needed.
            Me.SuppliersTableAdapter.Fill(Me.Shops_DBDataSet.suppliers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.PurchasesReport' table. You can move, or remove it, as needed.
            'Me.PurchasesReportTableAdapter.Fill(Me.Shops_DBDataSet.PurchasesReport)
            'DO: This line of code loads data into the 'Shops_DBDataSet.categories' table. You can move, or remove it, as needed.
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
        If Me.rbtRange.Checked = True Then
            If Me.dtpStart.Value > Me.dtpEnd.Value Then
                Utils.showMessage("Please start date can not be after end date")
                Exit Sub
            End If
        End If


        If Me.chkCustomer.Checked = False Then



            If Me.cmbReportType.SelectedIndex = 0 Then
                If Me.rbtDaily.Checked Then
                    reportTitle = "Purchases Report For All Products Bought On:  " & Me.dtpStart.Value.ToShortDateString

                    Me.PurchasesReportTableAdapter.FillByDateEqualAll(Me.Shops_DBDataSet.PurchasesReport, Me.dtpStart.Value.Day, Me.dtpStart.Value.Month, Me.dtpStart.Value.Year)
                Else
                    reportTitle = "Purchases Report For All Products Bought Between :  " & Me.dtpStart.Value.ToShortDateString & "  and  " & Me.dtpEnd.Value.ToShortDateString

                    Me.PurchasesReportTableAdapter.FillByDatesBetweenAll(Me.Shops_DBDataSet.PurchasesReport, CDate(Me.dtpStart.Value.ToShortDateString), CDate(Me.dtpEnd.Value.ToShortDateString))
                End If

            ElseIf Me.cmbReportType.SelectedIndex = 1 Then
                Dim pid As Integer = CInt(Me.Shops_DBDataSet.products.Rows(Me.cmbProducts.SelectedIndex)(0).ToString)
                Dim pname As String = Me.Shops_DBDataSet.products.Rows(Me.cmbProducts.SelectedIndex)(2).ToString.ToUpper
                If Me.rbtDaily.Checked Then
                    reportTitle = "Purchases Report For Product: " & pname & " : Bought On:  " & Me.dtpStart.Value.ToShortDateString
                    Me.PurchasesReportTableAdapter.FillByProductEqual(Me.Shops_DBDataSet.PurchasesReport, pid, Me.dtpStart.Value.Day, Me.dtpStart.Value.Month, Me.dtpStart.Value.Year)
                Else
                    reportTitle = "Purchases Report For Product: " & pname & " : Bought Between :  " & Me.dtpStart.Value.ToShortDateString & "  and  " & Me.dtpEnd.Value.ToShortDateString
                    Me.PurchasesReportTableAdapter.FillByProductsBetween(Me.Shops_DBDataSet.PurchasesReport, CDate(Me.dtpStart.Value.ToShortDateString), CDate(Me.dtpEnd.Value.ToShortDateString), pid)

                End If
            ElseIf Me.cmbReportType.SelectedIndex = 2 Then
                Dim cid As Integer = CInt(Me.Shops_DBDataSet.categories.Rows(Me.cmbProducts.SelectedIndex)(0).ToString)
                Dim cname As String = Me.Shops_DBDataSet.categories.Rows(Me.cmbProducts.SelectedIndex)(1).ToString

                If Me.rbtDaily.Checked Then
                    reportTitle = "Purchases Report For Product Category: " & cname & " : Bought On:  " & Me.dtpStart.Value.ToShortDateString
                    Me.PurchasesReportTableAdapter.FillByCategoryEqual(Me.Shops_DBDataSet.PurchasesReport, cid, Me.dtpStart.Value.Day, Me.dtpStart.Value.Month, Me.dtpStart.Value.Year)
                Else
                    reportTitle = "Purchases Report For Product Category: " & cname & " : Bought On:  " & Me.dtpStart.Value.ToShortDateString
                    Me.PurchasesReportTableAdapter.FillByCategoryBetween(Me.Shops_DBDataSet.PurchasesReport, CDate(Me.dtpStart.Value.ToShortDateString), CDate(Me.dtpEnd.Value.ToShortDateString), cid)
                End If
            End If
        Else
            If Me.cmbSupplier.SelectedIndex = -1 Then
                Utils.showMessage("Please select the Supplier")
                Exit Sub
            End If

            Dim cid As Integer = Me.Shops_DBDataSet.suppliers(Me.cmbSupplier.SelectedIndex).SupplierID
            Dim customerName As String = Me.Shops_DBDataSet.suppliers(Me.cmbSupplier.SelectedIndex).CompanyName.ToString

            If Me.rbtDaily.Checked Then
                reportTitle = "Purchases Report For Supplier: " & customerName & " : Bought On:  " & Me.dtpStart.Value.ToShortDateString
                Me.PurchasesReportTableAdapter.FillBySupplierEqual(Me.Shops_DBDataSet.PurchasesReport, cid, Me.dtpStart.Value.Day, Me.dtpStart.Value.Month, Me.dtpStart.Value.Year)
            Else
                reportTitle = "Purchases Report For Supplier: " & customerName & " : Bought Between :  " & Me.dtpStart.Value.ToShortDateString & " and " & Me.dtpEnd.Value.ToShortDateString()
                Me.PurchasesReportTableAdapter.FillBySupplierBetween(Me.Shops_DBDataSet.PurchasesReport, CDate(Me.dtpStart.Value.ToShortDateString), CDate(Me.dtpEnd.Value.ToShortDateString), cid)
            End If
        End If
    End Sub

    Private Sub cmbReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReportType.SelectedIndexChanged
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
        If Me.Shops_DBDataSet.PurchasesReport.Rows.Count > 0 Then
            Try
                Dim rpd As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                rpd.Load(Application.StartupPath & "\Reports\purchasesReport.rpt")
                rpd.SetDataSource(Me.Shops_DBDataSet)
                rpd.SetParameterValue("title", reportTitle)

                'rpd.ReportDefinition .
                Dim frm As New frmReportFace
                frm.crv1.ReportSource = rpd
                frm.Show()
            Catch ex As Exception
                Utils.showMessage(ex.ToString)
            End Try

        Else
            Utils.showMessage("Please there is nothing to print")
        End If
    End Sub


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.PurchasesReportDataGridView
            Dim column As Integer = 1

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

                        If j = 5 Then
                            dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
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
End Class