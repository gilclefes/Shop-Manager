
Imports System.Data.SqlClient
Public Class frmProductStockWithPriceSetup
    Public empID As Integer = 0
    Dim dtexpiry As New Shops_DBDataSet.ExpiryDatesDataTable
    Dim daExpiry As New Shops_DBDataSetTableAdapters.ExpiryDatesTableAdapter

    'Dim daProduct As New Shops_DBDataSetTableAdapters.ProductsTableAdapter
    'Dim dtProduct As New Shops_DBDataSet.productsDataTable

    Dim productIds As String = ""

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
            'TODO: This line of code loads data into the 'Shops_DBDataSet.creditors' table. You can move, or remove it, as needed.
            Me.CreditorsTableAdapter.Fill(Me.Shops_DBDataSet.creditors)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.suppliers' table. You can move, or remove it, as needed.
            Me.SuppliersTableAdapter.Fill(Me.Shops_DBDataSet.suppliers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.suppliers' table. You can move, or remove it, as needed.
            Me.SuppliersTableAdapter.Fill(Me.Shops_DBDataSet.suppliers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.categories' table. You can move, or remove it, as needed.
            Me.CategoriesTableAdapter.Fill(Me.Shops_DBDataSet.categories)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.orderdetails' table. You can move, or remove it, as needed.
            Me.OrderdetailsTableAdapter.Fill(Me.Shops_DBDataSet.orderdetails)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.company_orders' table. You can move, or remove it, as needed.
            Me.Company_ordersTableAdapter.Fill(Me.Shops_DBDataSet.company_orders)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.sales' table. You can move, or remove it, as needed.

            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
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

        'Me.ProductsTableAdapter.FillByproductname(Me.Shops_DBDataSet.products, "%" & Me.txtProductName.Text & "%")
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
        Dim price As Double = 0.0
        Dim discount As Double = 0.0
        Dim qty As Integer = 0

        Dim row As Shops_DBDataSet.productsRow = Me.Shops_DBDataSet.products.Rows(index)

        If Me.productExists(row.ProductID) = True Then
            Utils.showMessage("Product Already Added to Basket")
            Exit Sub
        End If

        If IsNumeric(Me.UnitPriceTextBox.Text) Then
            price = CDbl(Me.UnitPriceTextBox.Text.ToString)
        Else
            Utils.showMessage("Unit price should be numeric")
            Exit Sub
        End If

        If IsNumeric(Me.QuantityTextBox.Text) Then
            qty = CInt(Me.QuantityTextBox.Text)
        Else
            Utils.showMessage("Quantity to buy should be numeric")
            Exit Sub
        End If

        If CDate(Me.dtpExpiryDate.Value) < Now.Date Then
            Utils.showMessage("Please date can not be earlier than today")
            Exit Sub
        End If

        If IsNumeric(Me.DiscountTextBox.Text) Then
            discount = CDbl(Me.DiscountTextBox.Text)
        Else
            Utils.showMessage("Discount given should be numeric")
            Exit Sub
        End If

        If discount >= price Then
            Utils.showMessage("Please Discount cannot be greater or equal to unit Price")
            Exit Sub
        End If

        'updates products table with quatity
        row.UnitsInStock = row.UnitsInStock + qty
        Me.ProductsBindingSource.EndEdit()

        Me.dgrdBasket.Rows.Add(New Object() {999, row.ProductID, row.ProductName, price, qty, discount, qty * (price - discount), CDate(Me.dtpExpiryDate.Value)})
        Me.lblCost.Text = Me.getTotalCost()

    End Sub

    Private Sub clear()
        Me.txtAmountpaid.Text = ""
        Me.txtProductName.Text = ""
        Me.dtpExpiryDate.Value = Now.Date
        Me.QuantityTextBox.Text = ""
        Me.DiscountTextBox.Text = ""
        Me.UnitPriceTextBox.Text = ""
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


    'Private Sub ProductsDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductsDataGridView.CellDoubleClick
    '    If Me.ProductsDataGridView.CurrentRow.Index >= 0 Then
    '        Dim index As Integer = Me.ProductsDataGridView.CurrentRow.Index
    '        addToBasket(index)
    '    End If
    'End Sub

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
            Me.updateProduct(pid, qty * -1)
            Me.dgrdBasket.Rows.RemoveAt(index)
            Me.lblCost.Text = Me.getTotalCost
        End If
    End Sub

    Private Sub UpdateSales(ByVal index As Integer)
        Dim val As String = ""
        Dim inintQty As Integer = CInt(Me.dgrdBasket.Rows(index).Cells(4).Value)
        Dim pid As Integer = CInt(Me.dgrdBasket.Rows(index).Cells(1).Value)
        Dim newQty As Integer = 0
        Do
            val = InputBox("Enter the Quantity Bought", "Shop Manager", inintQty, 400, 150)
        Loop Until IsNumeric(val) = True
        newQty = CInt(val)

        Dim qty As Integer = newQty - inintQty

        'update values when quantity to purchase changes

        Me.dgrdBasket.Rows(index).Cells(4).Value = newQty
        Me.dgrdBasket.Rows(index).Cells(6).Value = newQty * (CDbl(Me.dgrdBasket.Rows(index).Cells(3).Value) - CDbl(Me.dgrdBasket.Rows(index).Cells(5).Value))
        Me.updateProduct(pid, qty)
        Me.lblCost.Text = Me.getTotalCost

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
    End Sub

    Private Function getTotalCost() As Decimal
        Dim total As Decimal = 0.0
        For i As Integer = Me.dgrdBasket.Rows.Count - 1 To 0 Step -1
            total = total + CDec(dgrdBasket.Rows(i).Cells(6).Value)
        Next
        Return total
    End Function

    Private Sub addCreditors(ByVal amountdue As Double)
        Try
            Dim orderid As Integer = Me.Company_ordersTableAdapter.getMax
            Dim row As Shops_DBDataSet.suppliersRow = Me.Shops_DBDataSet.suppliers.Rows(Me.cmbSupplier.SelectedIndex)

            Me.CreditorsTableAdapter.Insert(orderid, row.SupplierID, empID, amountdue, False)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub addSalesDetails()

        Try

            Me.productIds = ""
            'insert company orders row

            Dim rows As Shops_DBDataSet.suppliersRow = Me.Shops_DBDataSet.suppliers.Rows(Me.cmbSupplier.SelectedIndex)

            Me.Company_ordersTableAdapter.InsertQuery(rows.SupplierID, empID, CDate(Date.Now.ToShortDateString), Date.Now, CDbl(lblCost.Text))
            Dim orderid As Integer = Me.Company_ordersTableAdapter.getMax


            'insert order details rows as well as keeping record of when each 
            Dim dtSales As New Shops_DBDataSet.orderdetailsDataTable

            Dim daOrderDetail As New Shops_DBDataSetTableAdapters.orderdetailsTableAdapter
            Dim totalPrice As Decimal = 0.0
            Dim totalQuantity As Integer = 0
            For i As Integer = 0 To Me.dgrdBasket.Rows.Count - 1
                'initializing new expiury dates row
                Dim expiryRow As Shops_DBDataSet.ExpiryDatesRow
                expiryRow = Shops_DBDataSet.ExpiryDates.NewExpiryDatesRow

                'initializing a new orderdetails rows
                Dim row As Shops_DBDataSet.orderdetailsRow
                row = Me.Shops_DBDataSet.orderdetails.NeworderdetailsRow

                'assigning values (oderdetails)
                row.OrderID = orderid
                row.ProductID = CInt(Me.dgrdBasket.Rows(i).Cells(1).Value)
                row.UnitPrice = CDbl(Me.dgrdBasket.Rows(i).Cells(3).Value)
                row.Quantity = CInt(Me.dgrdBasket.Rows(i).Cells(4).Value)
                row.Discount = CInt(Me.dgrdBasket.Rows(i).Cells(5).Value)
                row.ExpiryDate = CDate(Me.dgrdBasket.Rows(i).Cells(7).Value)

                'get a list of products separated by ,

                If Me.productIds = "" Then
                    Me.productIds = Me.productIds & CInt(Me.dgrdBasket.Rows(i).Cells(1).Value) & ""
                Else
                    Me.productIds = Me.productIds & "," & CInt(Me.dgrdBasket.Rows(i).Cells(1).Value)
                End If


                'assigning values (expiriy dates)
                expiryRow.OrderDetailsID = row.OrderID
                expiryRow.ExpiryDate = row.ExpiryDate
                expiryRow.Quantity = row.Quantity
                expiryRow.ProductID = row.ProductID

                dtSales.Rows.Add(New Object() {orderid, row.ProductID, row.UnitPrice, row.Quantity, row.Discount, row.ExpiryDate})
                'dtexpiry.Rows.Add(New Object() {
                Me.dtexpiry.AddExpiryDatesRow(expiryRow.ProductID, expiryRow.Quantity, expiryRow.ExpiryDate, expiryRow.OrderDetailsID)

                totalPrice = daOrderDetail.GetProductTotalUnitPrice(CInt(Me.dgrdBasket.Rows(i).Cells(1).Value))
                totalPrice = totalPrice + CDbl(Me.dgrdBasket.Rows(i).Cells(3).Value)

                totalQuantity = daOrderDetail.GetProductTotalCount(CInt(Me.dgrdBasket.Rows(i).Cells(1).Value))
                totalQuantity = totalQuantity + 1

                Me.ProductsTableAdapter.UpdateProductAvgCost((totalPrice / CDec(totalQuantity)), CInt(Me.dgrdBasket.Rows(i).Cells(1).Value))
                Me.ProductsTableAdapter.UpdateQuery(CInt(Me.dgrdBasket.Rows(i).Cells(4).Value), CInt(Me.dgrdBasket.Rows(i).Cells(1).Value))

                'updating the price based on the value given.
                If Me.chkPriceSetup.Checked = True Then
                    Dim productId As Integer = CInt(Me.dgrdBasket.Rows(i).Cells(1).Value)
                    Dim profitMargin As Double = CDbl(Me.txtProfitMargin.Text)
                    Dim cost As Double = CDbl(Me.dgrdBasket.Rows(i).Cells(3).Value)

                    Dim newPrice As Double = cost + ((profitMargin / 100) * cost)

                    Dim oldPrice As Double = Me.ProductsTableAdapter.GetProductUnitPrice(productId)

                    If oldPrice < newPrice Then
                        Me.ProductsTableAdapter.UpdateUnitPrice(newPrice, productId)
                    End If

                End If

            Next

            Me.OrderdetailsBindingSource.EndEdit()
            'updating 
            daExpiry.Update(dtexpiry)
            Me.OrderdetailsTableAdapter.Update(dtSales)
            ' Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub CalculateProductsUnitPrices()
        If productIds <> "" Then

            'Me.daProduct.SelectCommand(0).CommandText = "SELECT ProductID, ProductCode, ProductName, CategoryID, UnitPrice, " & _
            '" UnitsInStock, ReorderLevel, Discontinued, Description, LocationID, Discount, WHUnitPrice, AvgCost FROM   products "

            'Dim query As String = " ProductID IN ( " & Me.productIds & ")"

            'Me.daProduct.FillByWhere(Me.dtProduct, query)

            'For Each row As Shops_DBDataSet.productsRow In dtProduct

            'Next

        End If


    End Sub

    Private Sub btnBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuy.Click

        Dim amountPaid As Double = 0.0
        If Utils.QuestionPrompt("Are you sure to BUY") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If Me.cmbSupplier.Items.Count <= 0 Then
            Utils.showMessage("Please Enter the Suppliers Information before continuing")
            Exit Sub
        End If

        If IsNumeric(Me.txtAmountpaid.Text) Then
            amountPaid = CDbl(Me.txtAmountpaid.Text)
        Else
            Utils.showMessage("Amount Paid Should be Numeric")
            Exit Sub
        End If

        If amountPaid > CDbl(Me.lblCost.Text) Then
            Utils.showMessage("Amount Paid Can not be greater than Total Cost")
            Exit Sub
        End If

        If chkPriceSetup.Checked Then
            If IsNumeric(Me.txtProfitMargin.Text) Then
                If CDbl(Me.txtProfitMargin.Text) <= 0 Or CDbl(Me.txtProfitMargin.Text) > 100 Then
                    Utils.showMessage("Profit Margin Value cannot be greater than 100 or less than Zero")
                    Exit Sub                 
                End If     
            End If
        End If


        Using conn As SqlConnection = Me.ProductsTableAdapter.Connection
            conn.ConnectionString = Global.Shop_Manager.My.MySettings.Default.Shops_DBConnectionString
            conn.Open()
            Dim tran As SqlTransaction = Nothing
            Try
                tran = conn.BeginTransaction
                Me.ProductsTableAdapter.Transaction = tran
                Me.OrderdetailsTableAdapter.Transaction = tran
                Me.Company_ordersTableAdapter.Transaction = tran
                Me.CreditorsTableAdapter.Transaction = tran
                Me.daExpiry.Transaction = tran

                If Me.dgrdBasket.Rows.Count > 0 Then

                    Me.addSalesDetails()
                    ' check if amount paid is less, if less insert a row in the creditors table
                    If amountPaid < CDbl(Me.lblCost.Text) Then
                        Me.addCreditors(CDbl(Me.lblCost.Text) - amountPaid)
                    End If

                    Me.clearSales()

                Else
                    Utils.showMessage("No item in Customer's Basket")
                End If

                tran.Commit()
            Catch ex As Exception
                Utils.showException(ex)
                If Not tran Is Nothing Then
                    tran.Rollback()
                End If
            End Try
            tran.Dispose()
            conn.Close()
        End Using





    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not Me.dgrdBasket.CurrentRow Is Nothing Then
            Dim index = Me.dgrdBasket.CurrentRow.Index
            Me.UpdateSales(index)
        Else
            Utils.showMessage("Select the Product to delete")
        End If
    End Sub

    Private Sub btnStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStock.Click
        If Me.ProductsDataGridView.CurrentRow.Index >= 0 Then
            Dim index As Integer = Me.ProductsDataGridView.CurrentRow.Index
            addToBasket(index)
            Me.clear()
        End If
    End Sub


End Class