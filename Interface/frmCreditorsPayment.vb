Public Class frmCreditorsPayment

  

    Private Sub frmDebtorsPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.payment_creditors' table. You can move, or remove it, as needed.
            Me.Payment_creditorsTableAdapter.Fill(Me.Shops_DBDataSet.payment_creditors)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.suppliers' table. You can move, or remove it, as needed.
            Me.SuppliersTableAdapter.Fill(Me.Shops_DBDataSet.suppliers)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.creditors' table. You can move, or remove it, as needed.
            Me.CreditorsTableAdapter.Fill(Me.Shops_DBDataSet.creditors)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.payment_creditors' table. You can move, or remove it, as needed.
            Me.Payment_creditorsTableAdapter.Fill(Me.Shops_DBDataSet.payment_creditors)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try


    End Sub



    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        If Utils.QuestionPrompt("Are you sure to make payments") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If Not Me.CreditorsDataGridView.CurrentRow Is Nothing Then
            Dim index As Integer = Me.CreditorsDataGridView.CurrentRow.Index
            Dim row As Shops_DBDataSet.creditorsRow = Me.Shops_DBDataSet.creditors.Rows(index)
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
            cnt = row.OrderID
            Me.Payment_creditorsTableAdapter.Insert(cnt, Me.DatePaidDateTimePicker.Value, Date.Now, amtpaid, Me.ReceiptNoTextBox.Text)
            ' Me.DebtorsBindingSource.EndEdit()
            Me.CreditorsTableAdapter.Update(Me.Shops_DBDataSet.creditors)
            Me.CreditorsTableAdapter.Fill(Me.Shops_DBDataSet.creditors)
            Me.Payment_creditorsTableAdapter.FillByOrderID(Me.Shops_DBDataSet.payment_creditors, cnt)
        End If
    End Sub

    Private Sub CreditorsDataGridView_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditorsDataGridView.CurrentCellChanged
        If Not Me.CreditorsDataGridView.CurrentRow Is Nothing Then
            Dim index As Integer = Me.CreditorsDataGridView.CurrentRow.Index
            Dim row As Shops_DBDataSet.creditorsRow = Me.Shops_DBDataSet.creditors.Rows(index)
            'Me.Payment_debtorsBindingSource.
            Me.Payment_creditorsTableAdapter.FillByOrderID(Me.Shops_DBDataSet.payment_creditors, row.OrderID)
        End If
    End Sub

    Private Sub CreditorsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Validate()
            Me.CreditorsBindingSource.EndEdit()
            Me.CreditorsTableAdapter.Update(Me.Shops_DBDataSet.creditors)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub
End Class