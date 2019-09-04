Public Class frmPrompts

    Dim expiryPrompt As Integer = 0
    Dim productsTable As New Shops_DBDataSet.productsDataTable
    Dim productsAdapter As New Shops_DBDataSetTableAdapters.ProductsTableAdapter

    Dim purchaseTable As New Shops_DBDataSet.orderdetailsDataTable
    Dim purchaseAdapter As New Shops_DBDataSetTableAdapters.orderdetailsTableAdapter

    Dim expiryInfotable As New Shops_DBDataSet.ExpiryInfoDataTable
    Dim expiryInfoAdapter As New Shops_DBDataSetTableAdapters.ExpiryInfoTableAdapter


    Dim productsID() As Integer
    Dim productsQty() As Integer
   

    Private Sub frmPrompts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Shops_DBDataSet.categories' table. You can move, or remove it, as needed.
        Me.CategoriesTableAdapter.Fill(Me.Shops_DBDataSet.categories)
        'TODO: This line of code loads data into the 'Shops_DBDataSet.Location' table. You can move, or remove it, as needed.
        Me.LocationTableAdapter.Fill(Me.Shops_DBDataSet.Location)
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
            Me.expiryPrompt = My.Settings.expiryPrompt
            Me.purchaseAdapter.FillByExpiryDate(Me.purchaseTable, Me.expiryPrompt)

         

            Me.productsAdapter.Fill(Me.productsTable)

            Me.ProductsTableAdapter.FillByReorder(Me.Shops_DBDataSet.products)

            ReDim Me.productsID(Me.purchaseTable.Rows.Count - 1)
            ReDim Me.productsQty(Me.purchaseTable.Rows.Count - 1)
            Dim index As Integer = 0
            Dim qty As Integer = 0
            Dim promptQty As Integer = 0

            Dim row As Shops_DBDataSet.orderdetailsRow
            For i As Integer = Me.purchaseTable.Rows.Count - 1 To 0 Step -1
                row = Me.purchaseTable.Rows(i)
                Dim j As Integer = Array.IndexOf(Me.productsID, row.ProductID)

                If j = -1 Then
                    qty = getProductsUnitsinStockByID(row.ProductID)
                    If qty > 0 Then
                        If row.Quantity >= qty Then
                            promptQty = qty
                            qty = 0
                            Me.productsID(index) = row.ProductID
                            Me.productsQty(index) = qty
                            index = index + 1
                        Else
                            promptQty = row.Quantity
                            qty = qty - row.Quantity

                            Me.productsID(index) = row.ProductID
                            Me.productsQty(index) = qty
                            index = index + 1
                        End If
                        Me.expiryInfoAdapter.FillByOrderID(Me.expiryInfotable, row.OrderID)
                        Me.dgrdExpiry.Rows.Add(New Object() {Me.expiryInfotable.Rows(0)(0).ToString, Me.expiryInfotable.Rows(0)(1), Me.getProductsNameByID(row.ProductID), promptQty, row.ExpiryDate})

                    End If


                Else
                    qty = Me.productsQty(j)

                    If qty > 0 Then

                        If row.Quantity >= qty Then
                            promptQty = qty
                            qty = 0
                            Me.productsID(index) = row.ProductID
                            Me.productsQty(index) = qty
                            index = index + 1
                        Else
                            promptQty = row.Quantity
                            qty = qty - row.Quantity
                            Me.productsID(index) = row.ProductID
                            Me.productsQty(index) = qty
                            index = index + 1
                        End If

                        'Me.dgrdExpiry.Rows.Add(New Object() {Me.getProductsNameByID(row.ProductID), promptQty, row.ExpiryDate})

                        Me.expiryInfoAdapter.FillByOrderID(Me.expiryInfotable, row.OrderID)
                        Me.dgrdExpiry.Rows.Add(New Object() {Me.expiryInfotable.Rows(0)(0).ToString, Me.expiryInfotable.Rows(0)(1), Me.getProductsNameByID(row.ProductID), promptQty, row.ExpiryDate})

                    End If


                End If

            Next
            Me.Label2.Text = "The  follwing products has " & Me.expiryPrompt & " days to Expire"
            If Me.ProductsDataGridView.RowCount <= 0 Then
                Me.SplitContainer1.Panel2Collapsed = True
                Me.ReoToolStripMenuItem.Visible = False
            End If

            If Me.dgrdExpiry.RowCount <= 0 Then
                Me.SplitContainer1.Panel1Collapsed = True
                Me.ExpiryDatesInformationToolStripMenuItem.Visible = False
            End If

        Catch ex As Exception
            Utils.showException(ex)
        End Try

    End Sub

    Private Function getProductsUnitsinStockByID(ByVal ID As Integer) As Integer
        Dim value As Integer = 0
        Dim row As Shops_DBDataSet.productsRow
        For i As Integer = 0 To Me.productsTable.Rows.Count - 1
            row = Me.productsTable.Rows(i)
            If row.ProductID = ID Then
                value = row.UnitsInStock
                Exit For
            End If
        Next
        Return value
    End Function


    Private Function getProductsNameByID(ByVal ID As Integer) As String
        Dim value As String = ""
        Dim row As Shops_DBDataSet.productsRow
        For i As Integer = 0 To Me.productsTable.Rows.Count - 1
            row = Me.productsTable.Rows(i)
            If row.ProductID = ID Then
                value = row.ProductName
                Exit For
            End If
        Next
        Return value
    End Function

    Private Sub ExpiryDatesInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryDatesInformationToolStripMenuItem.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.dgrdExpiry
            Dim column As Integer = 0

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = Me.Label2.Text.ToUpper

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
                        ElseIf j = 4 Then
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

    Private Sub ReoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReoToolStripMenuItem.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.ProductsDataGridView
            Dim column As Integer = 2

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = Me.Label1.Text.ToUpper

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

                        If j = 3 Then
                            dr(count) = Me.getCategoryByID(CInt(dgrd.Rows(i).Cells(j).Value))

                        ElseIf j = 8 Then
                            dr(count) = Me.getLocationByID(CInt(dgrd.Rows(i).Cells(j).Value))
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


    Private Function getLocationByID(ByVal ID As Integer)
        Dim value As String = ""
        Dim row As Shops_DBDataSet.LocationRow
        For i As Integer = 0 To Me.Shops_DBDataSet.Location.Rows.Count - 1
            row = Me.Shops_DBDataSet.Location.Rows(i)
            If row.LocationID = ID Then
                value = row.LocationName
                Exit For
            End If
        Next
        Return value
    End Function

    Private Function getCategoryByID(ByVal ID As Integer)
        Dim value As String = ""
        Dim row As Shops_DBDataSet.categoriesRow
        For i As Integer = 0 To Me.Shops_DBDataSet.categories.Rows.Count - 1
            row = Me.Shops_DBDataSet.categories.Rows(i)
            If row.CategoryID = ID Then
                value = row.CateryName
                Exit For
            End If
        Next
        Return value
    End Function
End Class