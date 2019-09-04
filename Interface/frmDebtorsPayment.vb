Public Class frmDebtorsPayment

    Private Sub DebtorsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Validate()
            Me.DebtorsBindingSource.EndEdit()
            Me.DebtorsTableAdapter.Update(Me.Shops_DBDataSet.Debtors)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub frmDebtorsPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.CustomersTableAdapter.Fill(Me.Shops_DBDataSet.customers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Debtors' table. You can move, or remove it, as needed.
            Me.DebtorsTableAdapter.Fill(Me.Shops_DBDataSet.Debtors)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

   

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        If Utils.QuestionPrompt("Are you sure to make payments") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If Not Me.DebtorsDataGridView.CurrentRow Is Nothing Then
            Dim index As Integer = Me.DebtorsDataGridView.CurrentRow.Index
            Dim row As Shops_DBDataSet.DebtorsRow = Me.Shops_DBDataSet.Debtors.Rows(index)
            Dim amtpaid As Double = 0.0
            Dim cnt As Integer = 0
            'validation date and amountpaid
            If CDate(Me.DatePaidDateTimePicker.Value.ToShortDateString) > CDate(Now.Date.ToShortDateString) Then
                Utils.showMessage("Please Date paid can not be after today")
                Exit Sub
            End If

            If IsNumeric(Me.AmountpaidTextBox.Text) Then
                amtpaid = CDbl(Me.AmountpaidTextBox.Text)
            Else
                Utils.showMessage("Please amount paid should be numeric")
                Exit Sub
            End If

            If amtpaid > row.AmountDue Then
                Utils.showMessage("Amount paid can not than amount due")
                Exit Sub
            End If

            row.AmountDue = row.AmountDue - amtpaid
            If row.AmountDue = 0 Then
                row.CompletePayments = True
            End If
            cnt = row.SalesID
            Me.Payment_debtorsTableAdapter.Insert(row.SalesID, Me.DatePaidDateTimePicker.Value, Date.Now, amtpaid, Me.ReceiptNoTextBox.Text)
            ' Me.DebtorsBindingSource.EndEdit()
            Me.DebtorsTableAdapter.Update(Me.Shops_DBDataSet.Debtors)
            Me.DebtorsTableAdapter.Fill(Me.Shops_DBDataSet.Debtors)
            Me.Payment_debtorsTableAdapter.FillBySalesID(Me.Shops_DBDataSet.payment_debtors, cnt)
        End If
    End Sub

    Private Sub DebtorsDataGridView_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebtorsDataGridView.CurrentCellChanged
        If Not Me.DebtorsDataGridView.CurrentRow Is Nothing Then
            Dim index As Integer = Me.DebtorsDataGridView.CurrentRow.Index
            Dim row As Shops_DBDataSet.DebtorsRow = Me.Shops_DBDataSet.Debtors.Rows(index)
            'Me.Payment_debtorsBindingSource.
            Me.Payment_debtorsTableAdapter.FillBySalesID(Me.Shops_DBDataSet.payment_debtors, row.SalesID)
        End If
    End Sub
End Class