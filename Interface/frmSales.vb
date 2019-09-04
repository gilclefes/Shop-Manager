Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.Text
Imports Shop_Manager.Classes

Public Class frmSales
    Public empID As Integer = 0
    Dim pro As Integer = 0
    Dim salesid As Integer = 0
    Public username As String
    Dim shopAdapter As New Shops_DBDataSetTableAdapters.ShopInfoTableAdapter
    Dim shopDatatable As New Shops_DBDataSet.ShopInfoDataTable
    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Validate()
            Me.ProductsBindingSource.EndEdit()
            Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try


    End Sub

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Debtors' table. You can move, or remove it, as needed.
            Me.DebtorsTableAdapter.Fill(Me.Shops_DBDataSet.Debtors)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Debtors' table. You can move, or remove it, as needed.
            Me.DebtorsTableAdapter.Fill(Me.Shops_DBDataSet.Debtors)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.customers' table. You can move, or remove it, as needed.
            Me.CustomersTableAdapter.Fill(Me.Shops_DBDataSet.customers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.sales' table. You can move, or remove it, as needed.

            Me.dgrdBasket.DataSource = Nothing
            Me.SalesdetailsTableAdapter.Fill(Me.Shops_DBDataSet.salesdetails)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)

            shopAdapter.Fill(shopDatatable)
            'set the payment to the first index
            Me.cmbPaymentType.SelectedIndex = 0
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub txtProductName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductName.TextChanged
        Using conn As SqlConnection = Me.ProductsTableAdapter.Connection
            conn.ConnectionString = Global.Shop_Manager.My.MySettings.Default.Shops_DBConnectionString
            conn.Open()
            Try
                Me.ProductsTableAdapter.Connection = conn
                Me.ProductsTableAdapter.FillByproductname(Me.Shops_DBDataSet.products, "%" & Me.txtProductName.Text & "%")

            Catch ex As Exception
                Utils.showException(ex)
            End Try
        End Using



    End Sub


    Private Sub ProductsDataGridView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProductsDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.ProductsDataGridView.CurrentRow.Index >= 0 Then
                Dim index As Integer = Me.ProductsDataGridView.CurrentRow.Index
                addToBasket(index)
            End If
        ElseIf e.KeyCode = Keys.ControlKey Then
            Me.txtProductName.Focus()
            Me.txtProductName.SelectionStart = 0
        ElseIf e.KeyCode = Keys.A Then
            Me.txtProductName.Focus()
            Me.txtProductName.SelectionStart = 0
        End If
    End Sub

    Private Sub addToBasket(ByVal index As Integer)
        Dim val As String = ""
        Dim row As Shops_DBDataSet.productsRow = Me.Shops_DBDataSet.products.Rows(index)

        If Me.productExists(row.ProductID) = True Then
            Utils.showMessage("Product Already Added to Basket")
            Exit Sub
        End If

        Do
            val = InputBox("Enter the Quantity Bought", "Shop Manager", 1, 300, 200)
        Loop Until IsNumeric(val) = True

        Dim qty As Integer = CInt(val)

        If qty > row.UnitsInStock Then
            Utils.showMessage("Quantity bought can not be greater than Quantity in Stock")
            Exit Sub
        Else
            row.UnitsInStock = row.UnitsInStock - qty
            Me.ProductsBindingSource.EndEdit()
        End If
        If chkWholesale.Checked = True Then
            Me.dgrdBasket.Rows.Add(New Object() {999, row.ProductID, row.ProductName, row.WHUnitPrice, qty, row.Discount, qty * (row.WHUnitPrice - row.Discount)})

        Else
            Me.dgrdBasket.Rows.Add(New Object() {999, row.ProductID, row.ProductName, row.UnitPrice, qty, row.Discount, qty * (row.UnitPrice - row.Discount)})

        End If
       
        Me.lblCost.Text = String.Format("{0:GH ¢ #,##0.00}", getTotalCost)
        'Me.getTotalCost.ToString("C2")
    End Sub

    Private Sub updateProduct(ByVal pid As Integer, ByVal qty As Integer)
        For i As Integer = 0 To Me.Shops_DBDataSet.products.Rows.Count - 1
            Dim row As Shops_DBDataSet.productsRow = Me.Shops_DBDataSet.products.Rows(i)
            If pid = row.ProductID Then
                row.UnitsInStock = row.UnitsInStock + qty
                Me.ProductsBindingSource.EndEdit()
            End If
        Next
    End Sub

    Private Function isProductQuantityEnough(ByVal pid As Integer, ByVal qty As Integer) As Boolean
        For i As Integer = 0 To Me.Shops_DBDataSet.products.Rows.Count - 1
            Dim row As Shops_DBDataSet.productsRow = Me.Shops_DBDataSet.products.Rows(i)
            If pid = row.ProductID Then
                If qty > row.UnitsInStock Then
                    Utils.showMessage("Quantity Bought is higher than Quantity in Stock")
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function productExists(ByVal pid As Integer) As Boolean
        For i As Integer = 0 To Me.dgrdBasket.Rows.Count - 1
            If pid = CInt(Me.dgrdBasket.Rows(i).Cells(1).Value.ToString) Then
                Return True
            End If
        Next
        Return False
    End Function




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.dgrdBasket.DataSource = Nothing

        'Me.SalesTableAdapter.InsertQuery(12, 12, Now.Date, Now.Date, 1, 56)
        'Dim val As Integer = Me.SalesTableAdapter.getMax
        'Utils.showMessage("i deywork " & val)
    End Sub

    Private Sub ProductsDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductsDataGridView.CellDoubleClick
        If Me.ProductsDataGridView.CurrentRow.Index >= 0 Then
            Dim index As Integer = Me.ProductsDataGridView.CurrentRow.Index
            addToBasket(index)
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim index As Integer = -1
        If dgrdBasket.CurrentRow Is Nothing Then
            Utils.showMessage("Please Select Product to remove")
            Exit Sub
        Else
            index = Me.dgrdBasket.CurrentRow.Index
        End If

        If Utils.QuestionPrompt("Are you Sure to remove item from Basket") = Windows.Forms.DialogResult.Yes Then
            Dim pid As Integer = CInt(Me.dgrdBasket.Rows(index).Cells(1).Value)
            Dim qty As Integer = CInt(Me.dgrdBasket.Rows(index).Cells(4).Value)
            Me.updateProduct(pid, qty)
            Me.dgrdBasket.Rows.RemoveAt(index)
            Me.lblCost.Text = String.Format("{0:GH ¢ #,##0.00}", getTotalCost)
            'Me.getTotalCost.ToString("C2")
        End If
    End Sub

    Private Sub UpdateSales(ByVal index As Integer)
        Dim val As String = ""
        Dim inintQty As Integer = CInt(Me.dgrdBasket.Rows(index).Cells("Column5").Value)
        Dim pid As Integer = CInt(Me.dgrdBasket.Rows(index).Cells(1).Value)
        Dim newQty As Integer = 0
        Do
            val = InputBox("Enter the Quantity Bought", "Shop Manager", inintQty, 400, 150)
        Loop Until IsNumeric(val) = True
        newQty = CInt(val)

        Dim qty As Integer = inintQty - newQty
        If Me.isProductQuantityEnough(pid, (newQty - inintQty)) = True Then
            Me.dgrdBasket.Rows(index).Cells("Column5").Value = newQty
            Me.dgrdBasket.Rows(index).Cells("TotalCost").Value = newQty * CDbl(Me.dgrdBasket.Rows(index).Cells("Column4").Value)
            Me.updateProduct(pid, qty)
            Me.lblCost.Text = String.Format("{0:GH ¢ #,##0.00}", getTotalCost)
            'Me.getTotalCost.ToString("C2")

        Else
            Exit Sub
        End If
    End Sub

    Private Sub dgrdBasket_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrdBasket.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim index = Me.dgrdBasket.CurrentRow.Index
            Me.UpdateSales(e.RowIndex)
        End If
    End Sub

    Private Sub dgrdBasket_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrdBasket.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not Me.dgrdBasket.CurrentRow Is Nothing Then
                Dim index = Me.dgrdBasket.CurrentRow.Index
                Me.UpdateSales(index)
            Else
                Utils.showMessage("Select the Product to delete")
            End If
        End If
    End Sub

    Private Sub clearSales()
        For i As Integer = Me.dgrdBasket.Rows.Count - 1 To 0 Step -1
            Me.dgrdBasket.Rows.RemoveAt(i)
        Next
        Me.lblCost.Text = "0.0"
        Me.txtAmountPaid.Text = ""
        Me.chkIsCustomer.Checked = False
    End Sub

    Private Function getTotalCost() As Decimal
        Dim total As Decimal = 0.0
        For i As Integer = Me.dgrdBasket.Rows.Count - 1 To 0 Step -1
            total = total + CDec(dgrdBasket.Rows(i).Cells(6).Value)
        Next
        Return total
    End Function
    Private Sub addDebtors(ByVal amtpd As Double)
        Try
            Dim salesid As Integer = Me.SalesTableAdapter.getMax

            'If Me.Shops_DBDataSet.customers.Rows.Count > 0 Then
            Dim row As Shops_DBDataSet.customersRow = Me.Shops_DBDataSet.customers.Rows(Me.cmbCustomer.SelectedIndex)
            'End If

            Me.DebtorsTableAdapter.Insert(salesid, row.CustomerID, empID, amtpd, False)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub addSalesDetails()
        Dim cid As Integer = 0
        Dim saleType As String = ""

        If chkWholesale.Checked = True Then
            saleType = "WholeSale"
        Else
            saleType = "Retail"
        End If

        If Me.chkIsCustomer.Checked = True Then
            Dim row As Shops_DBDataSet.customersRow = Me.Shops_DBDataSet.customers.Rows(Me.cmbCustomer.SelectedIndex)
            cid = row.CustomerID
        End If

        Me.SalesTableAdapter.InsertQuery(cid, empID, CDate(Date.Now.ToShortDateString), Date.Now, 1, getTotalCost(), CDbl(Me.txtOffsetAmount.Text), saleType)
        salesid = Me.SalesTableAdapter.getMax

        Dim dtSales As New Shops_DBDataSet.salesdetailsDataTable
        For i As Integer = 0 To Me.dgrdBasket.Rows.Count - 1
            Dim row As Shops_DBDataSet.salesdetailsRow
            row = Me.Shops_DBDataSet.salesdetails.NewsalesdetailsRow
            row.SalesID = salesid
            row.ProductID = CInt(Me.dgrdBasket.Rows(i).Cells(1).Value)
            row.UnitPrice = CDbl(Me.dgrdBasket.Rows(i).Cells(3).Value)
            row.Quantity = CInt(Me.dgrdBasket.Rows(i).Cells(4).Value)
            row.Discount = CDbl(Me.dgrdBasket.Rows(i).Cells(5).Value)
            'dtSales.Rows.Add(row)
            dtSales.Rows.Add(New Object() {salesid, row.ProductID, row.UnitPrice, row.Quantity, row.Discount})
        Next

        Me.SalesdetailsBindingSource.EndEdit()
        Me.SalesdetailsTableAdapter.Update(dtSales)
        Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)

    End Sub

    Private Sub btnBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuy.Click

        Try
            pro = 0
            Dim amountPaid As Double = 0.0
            Dim offSetAmount As Double = 0.0
            Dim cid As Integer = 0
            If Utils.QuestionPrompt("Are you sure to SELL") = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If


            If Me.dgrdBasket.Rows.Count > 0 Then

                If IsNumeric(Me.txtAmountPaid.Text) Then
                    amountPaid = CDbl(Me.txtAmountPaid.Text)
                    If amountPaid < 0 Then
                        Utils.showMessage("Please amount paid  should not be less than zero")
                        Exit Sub
                    End If
                Else
                    Utils.showMessage("Please amount paid should be numeric")
                    Exit Sub
                End If

                If IsNumeric(Me.txtOffsetAmount.Text) Then
                    offSetAmount = CDbl(Me.txtOffsetAmount.Text)
                    If offSetAmount < 0 Then
                        Utils.showMessage("Please amount to Offset should not be less than zero")
                        Exit Sub
                    End If
                Else
                    Utils.showMessage("Please amount to Offset should be numeric")
                    Exit Sub
                End If

                'check if full payment was not done
                If Me.chkIsCustomer.Checked = True Then

                    If Me.cmbCustomer.Items.Count <= 0 Then
                        Utils.showMessage("Please Make sure Customer Information has already been entered")
                        Exit Sub
                    End If



                    If Me.cmbPaymentType.SelectedIndex = 0 Then
                        If (amountPaid + offSetAmount) < getTotalCost() Then
                            Utils.showMessage("Please Amount Paid is less than the Full Amount")
                            Exit Sub
                        End If
                    End If

                    'If Me.cmbPaymentType.SelectedIndex = 1 Then
                    '    If amountPaid > CDbl(Me.lblCost.Text) Then
                    '        Utils.showMessage("Please Amount Paid should not be greate than the Full Amount")
                    '        Exit Sub
                    '    End If
                    'End If

                End If

                If Me.chkIsCustomer.Checked = False Then
                    If (amountPaid + offSetAmount) < getTotalCost() Then
                        Utils.showMessage("Please Amount Paid is less than the Full Amount")
                        Exit Sub
                    End If
                End If


                If (amountPaid + offSetAmount) > getTotalCost() Then
                    Utils.showMessage("Please Give the Customer a Change of : " & ((amountPaid + offSetAmount) - getTotalCost()).ToString("N"))
                End If

                Using conn As SqlConnection = Me.ProductsTableAdapter.Connection
                    conn.ConnectionString = Global.Shop_Manager.My.MySettings.Default.Shops_DBConnectionString
                    conn.Open()
                    Dim tran As SqlTransaction = Nothing
                    Try
                        tran = conn.BeginTransaction
                        Me.ProductsTableAdapter.Transaction = tran
                        Me.SalesdetailsTableAdapter.Transaction = tran
                        Me.SalesTableAdapter.Transaction = tran
                        Me.DebtorsTableAdapter.Transaction = tran

                        'add debtors
                        If getTotalCost() - amountPaid > 0 Then
                            Me.addDebtors(getTotalCost() - amountPaid)
                        End If

                        'add sales info
                        Me.addSalesDetails()

                        tran.Commit()
                    Catch ex As Exception
                        If Not tran Is Nothing Then
                            tran.Rollback()
                        End If
                        Utils.showException(ex)
                    End Try
                    tran.Dispose()
                    conn.Close()
                End Using




                'end check
                'Dim pd As New PrintDocument()

                'AddHandler pd.PrintPage, AddressOf receipt_PrintPage
                'pd.DefaultPageSettings.PaperSize = New PaperSize("PaperA4", 840, 1180)
                'PrintPreview1.Document = pd
                'PrintPreview1.Document.DefaultPageSettings.PaperSize = New PaperSize("PaperA4", 840, 1180)
                'PrintPreview1.ShowDialog()
                If My.Settings.PrintReceipts = True Then
                    ' My.Printer.Print(Me.getReceipt)

                    printFormatedReceipt()
                End If


                Me.clearSales()
            Else
                Utils.showMessage("No item in Customer's Basket")
            End If
        Catch ex As Exception
            Utils.showException(ex)
        End Try


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not Me.dgrdBasket.CurrentRow Is Nothing Then
            Dim index = Me.dgrdBasket.CurrentRow.Index
            Me.UpdateSales(index)
        Else
            Utils.showMessage("Select the Product to delete")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsCustomer.CheckedChanged
        Me.gpCustomer.Enabled = Me.chkIsCustomer.Checked
    End Sub

    Private Sub receipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Static count As Integer = 0
        Dim x, y, c, i As Integer
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top

        'Dim customPaperSize As New Printing.PaperSize("8x10", 105, 200)
        'If e.PageSettings.PaperSource.Kind = PaperSourceKind.Custom Then
        '    e.PageSettings.PaperSize = customPaperSize
        'End If
        'Dim printfont As Font

        Dim backFont As New Font("Arial", 10, FontStyle.Italic)
        Dim HeaderFont As New Font("Arial", 14, FontStyle.Regular)
        Dim normfont As New Font("Times New Roman", 18, FontStyle.Regular)
        ' Calculate the number of lines per page.
        linesPerPage = e.MarginBounds.Height / normfont.GetHeight(e.Graphics)


        ' draws file studio logo

        linesPerPage = e.MarginBounds.Height / normfont.GetHeight(e.Graphics)
        linesPerPage = linesPerPage - 5
        'MsgBox(linesPerPage & "   " & Me.LsvCDs.Items.Count)

        x = 160
        y += 20
        e.Graphics.DrawString("THE SHOP MANAGER", HeaderFont, Brushes.Black, x, y)
        y += 30

        e.Graphics.DrawString("PACIFIC MART", HeaderFont, Brushes.Black, x, y)
        y += 30
        e.Graphics.DrawString("Top Herbal - Agboba", HeaderFont, Brushes.Black, x, y)
        y += 30
        e.Graphics.DrawString("Tel: 020 7346201", HeaderFont, Brushes.Black, x, y)
        y += 80
        x = 10
        e.Graphics.DrawString("SALES RECEIPT :  ", HeaderFont, Brushes.Black, x, y)
        y += 30

        e.Graphics.DrawString("RECEIPT ON " & Now.ToLongDateString.ToUpper, HeaderFont, Brushes.Black, x, y)
        y += 30

        If pro = 0 Then
        Else
            e.Graphics.DrawString("PROFORMA", HeaderFont, Brushes.Black, x, y)
        End If
        y += 10
        x = 5
        ' e.Graphics.DrawLine(Pens.Black, 5, 5, e.PageBounds.Width, 5) '(CompanyPhone, HeaderFont, Brushes.Blue, x, y)
        e.Graphics.DrawLine(Pens.Black, 5, y + 30, 820, y + 30)
        x = 10
        y += 60
        c = y
        ' e.Graphics.DrawImage(Me.Image.Images(0), 5, y + 2)
        e.Graphics.DrawString("PRODUCT NAME", HeaderFont, Brushes.Blue, x, y)
        x += 200
        'e.Graphics.DrawImage(Me.Image.Images(1), 5, y + 2)
        e.Graphics.DrawString("UNIT PRICE", HeaderFont, Brushes.Blue, x, y)
        x += 200
        ' e.Graphics.DrawImage(Me.Image.Images(2), 5, y + 2)
        e.Graphics.DrawString("QUANTITY", HeaderFont, Brushes.Blue, x, y)
        x += 200
        e.Graphics.DrawString("COST PRICE", HeaderFont, Brushes.Blue, x, y)
        e.Graphics.DrawLine(Pens.Black, 5, y + 30, 820, y + 30)

        x = 33
        y = c + 40

        ' Iterate over the file, printing each line.
        i = 0
        ' While count < linesPerPage And count < Me.LsvCDs.Items.Count

        For i = count To Me.dgrdBasket.Rows.Count - 1
            e.Graphics.DrawString(Me.dgrdBasket.Rows(i).Cells(2).Value.ToString, normfont, Brushes.Blue, x, y)
            x += 200

            e.Graphics.DrawString(Me.dgrdBasket.Rows(i).Cells(3).Value.ToString, normfont, Brushes.Blue, x, y)
            x += 200
            e.Graphics.DrawString(Me.dgrdBasket.Rows(i).Cells(4).Value.ToString, normfont, Brushes.Blue, x, y)
            x += 200
            e.Graphics.DrawString(Me.dgrdBasket.Rows(i).Cells(5).Value.ToString, normfont, Brushes.Blue, x, y)
            x += 200

            If y + normfont.Height > e.PageSettings.PaperSize.Height Then
                count = i + 1
                e.HasMorePages = True
                Return

            End If
            y += 40
            x = 33
        Next

        y += 50
        e.Graphics.DrawString("Total Cost " + Me.lblCost.Text, normfont, Brushes.Blue, x, y)

        y += 60
        e.Graphics.DrawString("Thanks For Coming, Come Again ", normfont, Brushes.Blue, x, y)

        count = 0
        e.HasMorePages = False
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Dim productList As New List(Of ProformaData)

            Dim shopName As String
            Dim shopTel As String
            Dim shopLocation As String
            Dim customerName As String = "--"
            Dim customerTel As String = "--"
            Dim customerAddress As String = "--"

            If shopDatatable.Rows.Count > 0 Then
                shopName = shopDatatable(0).ShopName.ToUpper()
                shopTel = shopDatatable(0).Telephone.ToUpper()
                shopLocation = shopDatatable(0).Location.ToUpper()
            Else

                shopName = "The Shop"
                shopTel = "--"
                shopLocation = "--"
                customerAddress = "--"
                customerName = "--"
                customerTel = "--"
            End If

            If Me.chkIsCustomer.Checked = True Then
                If Me.cmbCustomer.SelectedIndex >= 0 Then


                    If Me.Shops_DBDataSet.customers(cmbCustomer.SelectedIndex).IsAddressNull() = False Then
                        customerAddress = Me.Shops_DBDataSet.customers(cmbCustomer.SelectedIndex).Address
                    End If

                    If Me.Shops_DBDataSet.customers(cmbCustomer.SelectedIndex).IsPhoneNoNull() = False Then
                        customerTel = Me.Shops_DBDataSet.customers(cmbCustomer.SelectedIndex).PhoneNo
                    End If


                    customerName = Me.Shops_DBDataSet.customers(cmbCustomer.SelectedIndex).CompanyName

                End If
            End If
            For i As Integer = 0 To Me.dgrdBasket.Rows.Count - 1


                Dim data As New ProformaData()
                data.ProductName = Me.dgrdBasket.Rows(i).Cells(2).Value.ToString()
                data.UnitPrice = CDec(Me.dgrdBasket.Rows(i).Cells(3).Value.ToString())
                data.Quantity = CInt(Me.dgrdBasket.Rows(i).Cells(4).Value.ToString())
                data.CostPrice = CDec(Me.dgrdBasket.Rows(i).Cells(6).Value.ToString())
                productList.Add(data)
            Next

            If productList.Count > 0 Then
                Dim rpd As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                rpd.Load(Application.StartupPath & "\Reports\Proforma.rpt")
                rpd.SetDataSource(productList)

                rpd.SetParameterValue("shopname", shopName)
                rpd.SetParameterValue("telephone", shopTel)
                rpd.SetParameterValue("location", shopLocation)

                rpd.SetParameterValue("customerName", customerName)
                rpd.SetParameterValue("CustomerTel", customerTel)
                rpd.SetParameterValue("customerAddress", customerAddress)
                Dim frm As New frmReportFace
                frm.Crv1.ReportSource = rpd
                frm.Show()
            End If

            'pro = 1
            'If Me.dgrdBasket.Rows.Count > 0 Then

            '    My.Printer.Print(Me.getReceipt)
            '    'Dim pd As New PrintDocument()

            '    'AddHandler pd.PrintPage, AddressOf receipt_PrintPage
            '    'pd.DefaultPageSettings.PaperSize = New PaperSize("PaperA4", 840, 1180)
            '    'PrintPreview1.Document = pd
            '    'PrintPreview1.Document.DefaultPageSettings.PaperSize = New PaperSize("PaperA4", 840, 1180)
            '    'PrintPreview1.ShowDialog()
            'Else
            '    Utils.showMessage("Please add Items to Basket")
            '    Exit Sub
            'End If
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Function getReceipt() As String
        Dim receipt As New StringBuilder


        'receipt.Append("COSTAL WAVES VENTURES").AppendLine()
        'receipt.Append("TEL.0332091313, 0208577700, 0243633038").AppendLine()
        'receipt.Append("NANA-BAKROM, CAPE COAST").AppendLine()
        'receipt.Append("VAT NO:-----------------------").AppendLine()
        'receipt.Append("------------------------------").AppendLine()


        Dim shopName As String
        Dim shopTel As String
        Dim shopLocation As String
        Dim customerName As String = "--"
        Dim customerTel As String = "--"
        Dim customerAddress As String = "--"

        If shopDatatable.Rows.Count > 0 Then
            shopName = shopDatatable(0).ShopName.ToUpper()
            shopTel = shopDatatable(0).Telephone.ToUpper()
            shopLocation = shopDatatable(0).Location.ToUpper()
        Else

            shopName = "The Shop"
            shopTel = "--"
            shopLocation = "--"
            customerAddress = "--"
            customerName = "--"
            customerTel = "--"
        End If

        'receipt.Append("NKUNIM PHARMACY").AppendLine()
        'receipt.Append("Tel: 0544350132").AppendLine()
        'receipt.Append("BREMEN-ASIKUMA").AppendLine()
        receipt.Append(shopName).AppendLine()
        receipt.Append(shopTel).AppendLine()
        receipt.Append(shopLocation).AppendLine()
        receipt.Append("VAT NO:-----------------------").AppendLine()




        If pro = 0 Then
            receipt.Append("------------------------------").AppendLine()
            receipt.Append("RECEIPT").AppendLine()
            receipt.Append("RECEIPT ID :" & Me.salesid).AppendLine()
        Else
            receipt.Append("------------------------------").AppendLine()
            receipt.Append("Customer Name:-----------------------").AppendLine()
            receipt.Append("Customer Address:-----------------------").AppendLine()
            receipt.Append("Customer Tel:-----------------------").AppendLine()
            receipt.Append("------------------------------").AppendLine()
            receipt.Append("PROFORMA").AppendLine()
        End If

        receipt.Append("RECEIPT ON " & Now.ToString("ddd, dd-MMM-yyyy")).AppendLine()

        If chkIsCustomer.Checked = True Then
            receipt.Append("CUSTOMER :" & Me.Shops_DBDataSet.customers(Me.cmbCustomer.SelectedIndex).ContactName).AppendLine()
        End If

        receipt.Append("------------------------------").AppendLine()

        Dim header As String = "PRODUCT".PadRight(20) & "U.P.".PadLeft(6) & "QTY".PadLeft(6) & "C.P".PadLeft(6)
        'Dim header As String = String.Format("{0,-25} |     {1,-6}  |  {2,-6} |  {3,-6}", "PRODUCT", "U.P.", "QTY", "C.P")
        receipt.Append(header).AppendLine()

        Dim details As String = ""
        For i As Integer = 0 To Me.dgrdBasket.Rows.Count - 1
            details = Me.dgrdBasket.Rows(i).Cells(2).Value.ToString().PadRight(20) & Me.dgrdBasket.Rows(i).Cells(3).Value.ToString().PadLeft(6) & _
            Me.dgrdBasket.Rows(i).Cells(4).Value.ToString().PadLeft(6) & Me.dgrdBasket.Rows(i).Cells(6).Value.ToString().PadLeft(6)

            ' details = String.Format("{0,-25} |     {1,-6}  |  {2,-6} |  {3,-6}", Me.dgrdBasket.Rows(i).Cells(2).Value.ToString(), Me.dgrdBasket.Rows(i).Cells(3).Value.ToString(), Me.dgrdBasket.Rows(i).Cells(4).Value.ToString(), Me.dgrdBasket.Rows(i).Cells(6).Value.ToString())

            receipt.Append(details).AppendLine()
        Next
        receipt.AppendLine()
        receipt.Append("------------------------------").AppendLine()
        receipt.Append("VAT        : " & CDec(My.Settings.VAT) * 0.01 * getTotalCost()).AppendLine()
        receipt.Append("COST       : " & (getTotalCost() - (CDec(My.Settings.VAT) * 0.01 * getTotalCost()))).AppendLine()
        receipt.Append("TOTAL COST : " & Me.lblCost.Text).AppendLine()
        receipt.Append("Excellent Quality Expert Care").AppendLine()
        Return receipt.ToString

    End Function

    Private Sub printFormatedReceipt()
        Dim shopName As String
        Dim shopTel As String
        Dim shopLocation As String
        Dim customerName As String = "--"
        Dim customerTel As String = "--"
        Dim customerAddress As String = "--"

        If shopDatatable.Rows.Count > 0 Then
            shopName = shopDatatable(0).ShopName.ToUpper()
            shopTel = shopDatatable(0).Telephone.ToUpper()
            shopLocation = shopDatatable(0).Location.ToUpper()
        Else

            shopName = "The Shop"
            shopTel = "--"
            shopLocation = "--"
            customerAddress = "--"
            customerName = "--"
            customerTel = "--"
        End If

        Dim salesData As New Shops_DBDataSet.SaleReceiptDataTable
        For i As Integer = 0 To Me.dgrdBasket.Rows.Count - 1
            salesData.AddSaleReceiptRow(Me.dgrdBasket.Rows(i).Cells(2).Value.ToString(), CDec(Me.dgrdBasket.Rows(i).Cells(4).Value.ToString()), Me.dgrdBasket.Rows(i).Cells(3).Value.ToString(), Me.dgrdBasket.Rows(i).Cells(6).Value.ToString())
        Next

        Dim print As New PrintSaleRecipt
        print.Run(username.ToString(), customerName, DateTime.Now.ToShortDateString(), getTotalCost(), CDec(_txtAmountPaid.Text), salesData)

        ' details = Me.dgrdBasket.Rows(i).Cells(2).Value.ToString().PadRight(20) & Me.dgrdBasket.Rows(i).Cells(3).Value.ToString().PadLeft(6) & _
        ' Me.dgrdBasket.Rows(i).Cells(4).Value.ToString().PadLeft(6) & Me.dgrdBasket.Rows(i).Cells(6).Value.ToString().PadLeft(6)

    End Sub

End Class