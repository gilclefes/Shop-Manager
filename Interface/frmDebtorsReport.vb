Public Class frmDebtorsReport
    Private reportTitle As String

    Private Sub frmDebtorsReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.customers' table. You can move, or remove it, as needed.
            Me.CustomersTableAdapter.Fill(Me.Shops_DBDataSet.customers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.DebtorsReport' table. You can move, or remove it, as needed.
            '  Me.DebtorsReportTableAdapter.Fill(Me.Shops_DBDataSet.DebtorsReport)

        Catch ex As Exception
            Utils.showException(ex)
        End Try
     
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try
            If Me.dtpStart.Value > Me.dtpEnd.Value Then
                Utils.showMessage("Please start date can not be after end date")
                Exit Sub
            End If
            If Me.chkCustomer.Checked = False Then
                reportTitle = "Debtors Report  Between :  " & Me.dtpStart.Value.ToShortDateString & "  and  " & Me.dtpEnd.Value.ToShortDateString
                Me.DebtorsReportTableAdapter.FillByDateRange(Me.Shops_DBDataSet.DebtorsReport, CDate(Me.dtpStart.Value.ToShortDateString), CDate(Me.dtpEnd.Value.ToShortDateString))

            Else
                If Me.cmbCustomer.SelectedIndex = -1 Then
                    Utils.showMessage("Please select the customer")
                    Exit Sub
                End If

                Dim cid As Integer = Me.Shops_DBDataSet.customers(Me.cmbCustomer.SelectedIndex).CustomerID
                Dim customerName As String = Me.Shops_DBDataSet.customers(Me.cmbCustomer.SelectedIndex).CompanyName.ToString

            
                reportTitle = "Debtors Report For Customer: " & customerName & " : Between :  " & Me.dtpStart.Value.ToShortDateString & "  and  " & Me.dtpEnd.Value.ToShortDateString
                Me.DebtorsReportTableAdapter.FillByCustomerDateRange(Me.Shops_DBDataSet.DebtorsReport, CDate(Me.dtpStart.Value.ToShortDateString), CDate(Me.dtpEnd.Value.ToShortDateString), cid)


            End If

        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.DebtorsReportDataGridView
            Dim column As Integer = 0

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

                        If j = 1 Then
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

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            If Me.Shops_DBDataSet.DebtorsReport.Rows.Count > 0 Then
                Dim rpd As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                rpd.Load(Application.StartupPath & "\Reports\rptDebtors.rpt")
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
End Class