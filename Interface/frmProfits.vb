Public Class frmProfits
    Dim productsTable As New Shops_DBDataSet.productsDataTable
    Dim productsAdapter As New Shops_DBDataSetTableAdapters.ProductsTableAdapter


    Private Sub frmProfits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.productsAdapter.Fill(Me.productsTable)
            Me.cmbProducts.DataSource = Me.productsTable
            Me.cmbProducts.DisplayMember = Me.productsTable.Columns(2).ToString
            Me.cmbProducts.ValueMember = Me.productsTable.Columns(0).ToString

            ''TODO: This line of code loads data into the 'Shops_DBDataSet.PurchasesReport' table. You can move, or remove it, as needed.
            'Me.PurchasesReportTableAdapter.Fill(Me.Shops_DBDataSet.PurchasesReport)
            ''TODO: This line of code loads data into the 'Shops_DBDataSet.salesReports' table. You can move, or remove it, as needed.
            'Me.SalesReportsTableAdapter.Fill(Me.Shops_DBDataSet.salesReports)

        Catch ex As Exception
            Utils.showException(ex)
        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            'checking if the start date 
            Me.clearFields()

            Dim pid As Integer = CInt(Me.cmbProducts.SelectedValue.ToString)

            If CDate(Me.dtpStartDate.Value.ToShortDateString) > CDate(Now.Date.ToShortDateString) Then
                Utils.showMessage("Start Date can not be greater than today")
                Exit Sub
            End If

            If CDate(Me.dtpStartDate.Value.ToShortDateString) > CDate(Me.dtpEndDate.Value.ToShortDateString) Then
                Utils.showMessage("Start Date can not be greater than End Date")
                Exit Sub
            End If

            Dim date1 As Date = CDate(Me.dtpStartDate.Value.ToShortDateString)
            Dim date2 As Date = CDate(Me.dtpEndDate.Value.ToShortDateString)

            If chkALL.Checked = True Then
                Me.PurchasesReportTableAdapter.FillByDatesBetweenAll(Me.Shops_DBDataSet.PurchasesReport, date1, date2)
                Me.SalesReportsTableAdapter.FillByAllBetween(Me.Shops_DBDataSet.salesReports, date1, date2)

            Else
                Me.PurchasesReportTableAdapter.FillByProducts(Me.Shops_DBDataSet.PurchasesReport, pid, date1, date2)
                Me.SalesReportsTableAdapter.FillByProducts(Me.Shops_DBDataSet.salesReports, pid, date1, date2)

            End If

            Me.getResults()

        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub clearFields()
        Me.lblMessage.Text = ""
        Me.lblPurchases.Text = ""
        Me.lblSales.Text = ""
        Me.PurchasesReportTableAdapter.FillByProducts(Me.Shops_DBDataSet.PurchasesReport, -1, CDate(Me.dtpStartDate.Value), CDate(Me.dtpStartDate.Value))
        Me.SalesReportsTableAdapter.FillByProducts(Me.Shops_DBDataSet.salesReports, -1, CDate(Me.dtpStartDate.Value), CDate(Me.dtpStartDate.Value))

    End Sub

    Private Sub getResults()
        Dim totalPurchase As Double = 0.0
        Dim totalSales As Double = 0.0

        Dim pRow As Shops_DBDataSet.PurchasesReportRow
        For i As Integer = 0 To Me.Shops_DBDataSet.PurchasesReport.Rows.Count - 1
            pRow = Me.Shops_DBDataSet.PurchasesReport.Rows(i)
            totalPurchase = totalPurchase + (pRow.Quantity * (pRow.UnitPrice - pRow.Discount))
        Next

        Dim sRow As Shops_DBDataSet.salesReportsRow
        For i As Integer = 0 To Me.Shops_DBDataSet.salesReports.Rows.Count - 1
            sRow = Me.Shops_DBDataSet.salesReports.Rows(i)
            totalSales = totalSales + (sRow.Quantity * (sRow.UnitPrice - sRow.Discount))
        Next


        If Me.chkALL.Checked = True Then
            Me.lblMessage.Text = "Sales and Purchases Summary between " & Me.dtpStartDate.Value.ToString("ddd, MMM dd yyyy") & " and " & Me.dtpEndDate.Value.ToString("ddd, MMM dd yyyy") & " For ALL Products: "

        Else
            Me.lblMessage.Text = "Sales and Purchases Summary between " & Me.dtpStartDate.Value.ToString("ddd, MMM dd yyyy") & " and " & Me.dtpEndDate.Value.ToString("ddd, MMM dd yyyy") & " For : " & Me.productsTable.Rows(Me.cmbProducts.SelectedIndex)(2).ToString

        End If
        
        Me.lblSales.Text = "Total Sales Made : " & totalSales
        Me.lblPurchases.Text = "Total Purchases Made : " & totalPurchase

    End Sub
End Class