Imports System.Data.SqlClient
Public Class frmReturnedGoods
    Dim salesID As Integer = 0
    Dim salesTable As New Shops_DBDataSet.salesDataTable
    Dim salesAdapter As New Shops_DBDataSetTableAdapters.salesTableAdapter

    Private Sub clearFields()
        Me.lblSalesDate.Text = ""
        Me.lblSalestime.Text = ""
        Me.lblTotalAmt.Text = ""
        Me.SalesdetailsTableAdapter.FillBySalesID(Me.Shops_DBDataSet.salesdetails, -1)
    End Sub

    Private Sub SalesdetailsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.SalesdetailsBindingSource.EndEdit()
        Me.SalesdetailsTableAdapter.Update(Me.Shops_DBDataSet.salesdetails)

    End Sub

    Private Sub frmReturnedGoods_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''TODO: This line of code loads data into the 'Shops_DBDataSet.products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.Shops_DBDataSet.products)
        ''TODO: This line of code loads data into the 'Shops_DBDataSet.salesdetails' table. You can move, or remove it, as needed.
        'Me.SalesdetailsTableAdapter.Fill(Me.Shops_DBDataSet.salesdetails)

        ' create a text box to enter new quantity. on row select, user enter new quatity. new total amount is calulated,
        'dategrid is updated and products as well updated, either added or deleted from the product quatity depend
        'Printing of receipts to be done again from this end

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Using conn As SqlConnection = Me.ProductsTableAdapter.Connection
            conn.ConnectionString = Global.Shop_Manager.My.MySettings.Default.Shops_DBConnectionString
            conn.Open()

            Try


                Me.SalesdetailsTableAdapter.Connection = conn


                Me.clearFields()
                If Not IsNumeric(Me.txtSalesID.Text) Then
                    Utils.showMessage("Please SalesID should be numeric")
                    Exit Sub
                Else
                    salesID = CInt(Me.txtSalesID.Text)
                End If

                Me.salesAdapter.FillBySalesID(Me.salesTable, Me.salesID)
                If Me.salesTable.Rows.Count <= 0 Then
                    Utils.showMessage("Please enter a valid SalesID")
                    Exit Sub
                Else
                    Me.lblTotalAmt.Text = Me.salesTable.Rows(0)("totalamount").ToString
                    Me.lblSalestime.Text = CDate(Me.salesTable.Rows(0)("salestime")).ToShortTimeString
                    Me.lblSalesDate.Text = CDate(Me.salesTable.Rows(0)("salesdate")).ToShortDateString

                    Me.SalesdetailsTableAdapter.FillBySalesID(Me.Shops_DBDataSet.salesdetails, Me.salesID)
                End If


            Catch ex As Exception
                Utils.showException(ex)
            End Try
         
        End Using

       

    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If Not Me.SalesdetailsDataGridView.CurrentRow Is Nothing Then
            'Utils.showMessage(Me.SalesdetailsDataGridView.CurrentRow.Index)
            Dim index As Integer = Me.SalesdetailsDataGridView.CurrentRow.Index
            Dim oldQty As Integer = CInt(Me.SalesdetailsDataGridView.Rows(index).Cells(3).Value)
            Dim pid As Integer = CInt(Me.SalesdetailsDataGridView.Rows(index).Cells(1).Value)
            Dim newQty As Integer = 0

            If IsNumeric(Me.txtQty.Text) Then
                newQty = CInt(Me.txtQty.Text)
            Else
                Utils.showMessage("Please Quantity returned should be numeric")
                Exit Sub
            End If

            If newQty > oldQty Then
                Utils.showMessage("Quantity Returned can not be greater than the Quantity Bought")
                Exit Sub
            End If

            Me.Shops_DBDataSet.salesdetails.Rows(index)(3) = oldQty - newQty
            'Me.SalesdetailsDataGridView.Rows(index).Cells(3).Value = oldQty - newQty
            Me.lblTotalAmt.Text = Me.getTotalCost

            'updating records using transactions

            Using conn As SqlConnection = Me.ProductsTableAdapter.Connection
                conn.ConnectionString = Global.Shop_Manager.My.MySettings.Default.Shops_DBConnectionString
                conn.Open()
                Dim tran As SqlTransaction = Nothing
                Try
                    tran = conn.BeginTransaction

                    Me.ProductsTableAdapter.Transaction = tran
                    Me.SalesdetailsTableAdapter.Transaction = tran
                    Me.salesAdapter.Transaction = tran


                    Me.SalesdetailsTableAdapter.Update(Me.Shops_DBDataSet.salesdetails)
                    Me.salesAdapter.UpdateQuery(CDbl(Me.lblTotalAmt.Text), Me.salesID)
                    Me.ProductsTableAdapter.UpdateQuery(oldQty, pid)


                    tran.Commit()
                Catch ex As Exception
                    If Not tran Is Nothing Then
                        tran.Rollback()
                    End If
                End Try
                tran.Dispose()
                conn.Close()
            End Using






            Me.txtQty.Text = ""

        Else
            Utils.showMessage("Please Select Sales Record")
        End If
    End Sub

    Private Function getTotalCost() As Decimal
        Dim total As Decimal = 0.0
        For i As Integer = SalesdetailsDataGridView.Rows.Count - 1 To 0 Step -1
            total = total + (CDec(SalesdetailsDataGridView.Rows(i).Cells(2).Value) * CInt(SalesdetailsDataGridView.Rows(i).Cells(3).Value))
        Next
        Return total
    End Function
End Class