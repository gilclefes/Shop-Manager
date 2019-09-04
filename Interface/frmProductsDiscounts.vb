Public Class frmProductsDiscounts

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
       
    End Sub

    Private Sub frmProductsDiscounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
            Me.cmbDiscount.SelectedIndex = 0
        Catch ex As Exception
            Utils.showException(ex)
        End Try

    End Sub

    Private Sub txtProductName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductName.TextChanged
        Try
            Me.ProductsTableAdapter.FillByproductname(Me.Shops_DBDataSet.products, "%" & Me.txtProductName.Text & "%")

        Catch ex As Exception
            Utils.showException(ex)
        End Try

    End Sub

    Private Sub btnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscount.Click
        Try
            Dim discount As Double = 0.0
            Dim productDiscount As Double = 0.0
            If Not IsNumeric(Me.txtDiscount.Text) Then
                Utils.showMessage("Please Enter the Discount Value")
                Exit Sub
            End If


            If CDbl(Me.txtDiscount.Text) < 0 Then
                Utils.showMessage("Please negative values are not accepted")
                Exit Sub
            End If

            If Me.cmbDiscount.SelectedIndex = 1 And CDbl(Me.txtDiscount.Text) > 100 Then
                Utils.showMessage("Please Discount Value cannot be greater than 100%")
                Exit Sub
            End If
            If Me.cmbDiscount.SelectedIndex = 0 Then
                productDiscount = CDbl(Me.txtDiscount.Text)
            Else
                productDiscount = CDbl(Me.txtDiscount.Text) / 100
            End If

            Dim row As Shops_DBDataSet.productsRow
            Dim selected As Boolean = False
            For i As Integer = 0 To Me.ProductsDataGridView.RowCount - 1
                If CBool(Me.ProductsDataGridView.Rows(i).Cells(11).Value) = True Then
                    selected = True
                    discount = productDiscount

                    row = Me.Shops_DBDataSet.products.Rows(i)
                    If Me.cmbDiscount.SelectedIndex = 0 Then
                        If discount > row.UnitPrice Then
                            Utils.showMessage("Discount Cannot be greater than unit price @ row " & (i + 1))
                            Exit Sub
                        End If
                    Else
                        discount = productDiscount * row.UnitPrice
                    End If
                    Me.ProductsDataGridView.Rows(i).Cells(5).Value = discount
                    'row.Discount = discount
                End If
            Next

            If selected = False Then
                Utils.showMessage("No product selected")
                Exit Sub
            End If
            Me.ProductsBindingSource.EndEdit()
            Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)

            Me.txtDiscount.Text = ""
            For i As Integer = 0 To Me.ProductsDataGridView.RowCount - 1
                Me.ProductsDataGridView.Rows(i).Cells(11).Value = False
            Next
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub
End Class