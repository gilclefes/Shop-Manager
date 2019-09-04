Imports CrystalDecisions.CrystalReports.Engine
Public Class frmProductReports
    Private reportTitle As String
    Private Sub frmProductReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Shops_DBDataSet.ProductsReports' table. You can move, or remove it, as needed.
        'Me.ProductsReportsTableAdapter.Fill(Me.Shops_DBDataSet.ProductsReports)
        Me.cmbOperators.SelectedIndex = 0
        Me.cmbSearchBy.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Me.cmbSearchBy.SelectedIndex = 1 Then
            If Me.cmbOperators.SelectedIndex = 0 Then
                If Not IsNumeric(Me.txtValue.Text) Then
                    Utils.showMessage("Please Value Enter Should Numeric")
                    Exit Sub
                Else
                    reportTitle = "Report of Products Showing Unit Price Greater than : " & Me.txtValue.Text
                    Me.ProductsReportsTableAdapter.FillByPriceGreater(Me.Shops_DBDataSet.ProductsReports, CDbl(Me.txtValue.Text))
                End If
            ElseIf Me.cmbOperators.SelectedIndex = 1 Then
                If Not IsNumeric(Me.txtValue.Text) Then
                    Utils.showMessage("Please Value Enter Should Numeric")
                    Exit Sub
                Else
                    reportTitle = "Report of Products Showing Unit Price Less than : " & Me.txtValue.Text
                    Me.ProductsReportsTableAdapter.FillByPriceLess(Me.Shops_DBDataSet.ProductsReports, CDbl(Me.txtValue.Text))
                End If

            ElseIf Me.cmbOperators.SelectedIndex = 2 Then
                If Not IsNumeric(Me.txtValue.Text) Then
                    Utils.showMessage("Please Value Enter Should Numeric")
                    Exit Sub
                Else
                    reportTitle = "Report of Products Showing Unit Price Equal to : " & Me.txtValue.Text
                    Me.ProductsReportsTableAdapter.FillByPriceEqual(Me.Shops_DBDataSet.ProductsReports, CDbl(Me.txtValue.Text))
                End If

            ElseIf Me.cmbOperators.SelectedIndex = 3 Then
                Dim values() As String
                If Me.txtValue.Text = "" Then
                    Utils.showMessage("Please Value Enter two numbers separated by comma:")
                    Exit Sub
                Else
                    values = Me.txtValue.Text.Split(",")
                End If
                If values.Length <> 2 Then
                    Utils.showMessage("Please Value Enter two numbers separated by comma:")
                    Exit Sub
                End If

                If values(0) > values(1) Then
                    Utils.showMessage("Please Value Enter two numbers separated by comma: the Smaller Number First")
                    Exit Sub
                End If

                reportTitle = "Report of Products Showing Unit Price between : " & values(0) & "  and  " & values(1)
                Me.ProductsReportsTableAdapter.FillByPriceBetween(Me.Shops_DBDataSet.ProductsReports, CDbl(values(0)), CDbl(values(1)))
            End If

        Else
            If Me.cmbOperators.SelectedIndex = 0 Then
                If Not IsNumeric(Me.txtValue.Text) Then
                    Utils.showMessage("Please Value Enter Should Numeric")
                    Exit Sub
                Else
                    reportTitle = "Report of Products Showing Units in Stock Greater than : " & Me.txtValue.Text
                    Me.ProductsReportsTableAdapter.FillByStockGreater(Me.Shops_DBDataSet.ProductsReports, CDbl(Me.txtValue.Text))
                End If
            ElseIf Me.cmbOperators.SelectedIndex = 1 Then
                If Not IsNumeric(Me.txtValue.Text) Then
                    Utils.showMessage("Please Value Enter Should Numeric")
                    Exit Sub
                Else
                    reportTitle = "Report of Products Showing Units in Stock Less than : " & Me.txtValue.Text
                    Me.ProductsReportsTableAdapter.FillByStockLess(Me.Shops_DBDataSet.ProductsReports, CDbl(Me.txtValue.Text))
                End If

            ElseIf Me.cmbOperators.SelectedIndex = 2 Then
                If Not IsNumeric(Me.txtValue.Text) Then
                    Utils.showMessage("Please Value Enter Should Numeric")
                    Exit Sub
                Else
                    reportTitle = "Report of Products Showing Units in Stock Equal to : " & Me.txtValue.Text
                    Me.ProductsReportsTableAdapter.FillByStockEqual(Me.Shops_DBDataSet.ProductsReports, CDbl(Me.txtValue.Text))
                End If

            ElseIf Me.cmbOperators.SelectedIndex = 3 Then
                Dim values() As String = {}
                If Me.txtValue.Text = "" Then
                    Utils.showMessage("Please Value Enter two numbers separated by comma: ")
                    Exit Sub
                Else
                    values = Me.txtValue.Text.Split(",")
                End If

                If values.Length <> 2 Then
                    Utils.showMessage("Please Value Enter two numbers separated by comma:")
                    Exit Sub
                End If

                If values(0) > values(1) Then
                    Utils.showMessage("Please Value Enter two numbers separated by comma: the Smaller Number First")
                    Exit Sub
                End If

                reportTitle = "Report of Products Showing Units in Stock between : " & values(0) & "  and  " & values(1)
                Me.ProductsReportsTableAdapter.FillByStockBetween(Me.Shops_DBDataSet.ProductsReports, CDbl(values(0)), CDbl(values(1)))

            End If

        End If
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If Me.ProductsReportsDataGridView.RowCount > 0 Then

                Try
                    Dim rpd As New ReportDocument
                    rpd.Load(Application.StartupPath & "\Reports\productsReports.rpt")
                    rpd.SetDataSource(Me.Shops_DBDataSet)
                    rpd.SetParameterValue("title", reportTitle)
                    Dim frm As New frmReportFace
                    frm.crv1.ReportSource = rpd
                    frm.Show()
                Catch ex As Exception
                    Utils.showMessage(ex.ToString)
                End Try

            Else
                Utils.showMessage("No Records to Print")
            End If

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.ProductsReportsDataGridView
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

                        'If j = 5 Then
                        '    dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
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