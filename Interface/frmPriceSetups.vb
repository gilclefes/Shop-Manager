Public Class frmPriceSetups

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()

    End Sub

    Private Sub frmProductsDiscounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
            Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
            Me.cmbChangeType.SelectedIndex = 0
            Me.cmbPriceType.SelectedIndex = 0
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

            If Utils.QuestionPrompt("Are you sure to change prices") = DialogResult.No Then
                Exit Sub
            End If

            Dim discount As Double = 0.0
            Dim productDiscount As Double = 0.0
            If Not IsNumeric(Me.txtPriceValue.Text) Then
                Utils.showMessage("Please Enter the Price Value")
                Exit Sub
            End If


            If CDbl(Me.txtPriceValue.Text) < 0 Then
                Utils.showMessage("Please negative values are not accepted")
                Exit Sub
            End If

            If Me.cmbChangeType.SelectedIndex = 1 And CDbl(Me.txtPriceValue.Text) > 100 Then
                Utils.showMessage("Please Price Value cannot be greater than 100%")
                Exit Sub
            End If
            If Me.cmbChangeType.SelectedIndex = 0 Then
                productDiscount = CDbl(Me.txtPriceValue.Text)
            ElseIf Me.cmbChangeType.SelectedIndex = 1 Then
                productDiscount = CDbl(Me.txtPriceValue.Text)
            Else
                productDiscount = CDbl(Me.txtPriceValue.Text) / 100
            End If

            Dim row As Shops_DBDataSet.productsRow
            Dim selected As Boolean = False
            For i As Integer = 0 To Me.ProductsDataGridView.RowCount - 1
                If CBool(Me.ProductsDataGridView.Rows(i).Cells(12).Value) = True Then
                    If cmbPriceType.SelectedIndex = 0 Then
                        'checking for retail

                        selected = True
                        discount = productDiscount

                        row = Me.Shops_DBDataSet.products.Rows(i)
                        If Me.cmbChangeType.SelectedIndex = 0 Then
                            discount = row.UnitPrice + productDiscount
                        ElseIf Me.cmbChangeType.SelectedIndex = 1 Then
                            If discount > row.UnitPrice Then
                                Utils.showMessage("Price Cannot be greater than unit price @ row " & (i + 1))
                                Exit Sub
                            End If
                            discount = row.UnitPrice - productDiscount
                        ElseIf Me.cmbChangeType.SelectedIndex = 2 Then
                            discount = row.UnitPrice + (productDiscount * row.UnitPrice)
                        ElseIf Me.cmbChangeType.SelectedIndex = 3 Then
                            discount = row.UnitPrice - (productDiscount * row.UnitPrice)
                        End If
                        Me.ProductsDataGridView.Rows(i).Cells(4).Value = discount

                        'row.Discount = discount
                    Else
                        'checking for wholesale
                        selected = True
                        discount = productDiscount

                        row = Me.Shops_DBDataSet.products.Rows(i)
                        If Me.cmbChangeType.SelectedIndex = 0 Then
                            discount = row.WHUnitPrice + productDiscount
                        ElseIf Me.cmbChangeType.SelectedIndex = 1 Then
                            If discount > row.WHUnitPrice Then
                                Utils.showMessage("Price Cannot be greater than unit price @ row " & (i + 1))
                                Exit Sub
                            End If
                            discount = row.WHUnitPrice - productDiscount
                        ElseIf Me.cmbChangeType.SelectedIndex = 2 Then
                            discount = row.WHUnitPrice + (productDiscount * row.WHUnitPrice)
                        ElseIf Me.cmbChangeType.SelectedIndex = 3 Then
                            discount = row.WHUnitPrice - (productDiscount * row.WHUnitPrice)
                        End If
                        Me.ProductsDataGridView.Rows(i).Cells(5).Value = discount
                    End If
                End If

            Next

            If selected = False Then
                Utils.showMessage("No product selected")
                Exit Sub
            End If
            Me.ProductsBindingSource.EndEdit()
            Me.ProductsTableAdapter.Update(Me.Shops_DBDataSet.products)

            Me.txtPriceValue.Text = ""
            For i As Integer = 0 To Me.ProductsDataGridView.RowCount - 1
                Me.ProductsDataGridView.Rows(i).Cells(12).Value = False
            Next
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        For i As Integer = 0 To Me.ProductsDataGridView.RowCount - 1
            Me.ProductsDataGridView.Rows(i).Cells(12).Value = True
        Next
    End Sub

    Private Sub btnUnselect_Click(sender As System.Object, e As System.EventArgs) Handles btnUnselect.Click
        For i As Integer = 0 To Me.ProductsDataGridView.RowCount - 1
            Me.ProductsDataGridView.Rows(i).Cells(12).Value = False
        Next
    End Sub
End Class