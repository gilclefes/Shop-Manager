Public Class frmExpenses


    Private Sub ControlsInitialize()
        Me.SplitContainer2.Panel1Collapsed = False
        Me.SplitContainer2.Panel2Collapsed = True

    End Sub

    Private Sub EditMode()
        Me.SplitContainer2.Panel1Collapsed = True
        Me.SplitContainer2.Panel2Collapsed = False
    End Sub

    Private Sub Switch()

        Me.Validate()
        Me.ExpensesBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub



    Private Function validateControls() As Boolean

        If Me.ExpenseTypeIdComboBox.SelectedIndex = -1 Then
            Utils.showMessage("Please select the Expense Type")
            Return False
        End If

        If Not IsNumeric(Me.AmountSpentTextBox.Text) Then
            Utils.showMessage("Please Amount Spent should be a number")
            Return False
        End If

        If CDate(Me.DateSpentDateTimePicker.Value.ToShortDateString()) > Now Then
            Utils.showMessage("Please Date Selected cannot be later than today")
            Return False
        End If

        If Me.ExpenseDetailTextBox.Text = "" Then
            Utils.showMessage("Please Enter the Expense Detail")
            Return False
        End If

        If Me.ApprovedByTextBox.Text = "" Then
            Utils.showMessage("Please Enter who approved it")
            Return False
        End If

        If Me.ReceiptDetailTextBox.Text = "" Then
            Utils.showMessage("Please Enter the receipt detail")
            Return False
        End If

        If Me.PaidToTextBox.Text = "" Then
            Utils.showMessage("Please Enter the name of who made the payment")
            Return False
        End If

        Return True
    End Function

    Private Sub ExpensesBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpensesBindingNavigatorSaveItem.Click
        'Me.Validate()
        'Me.ExpensesBindingSource.EndEdit()
        'Me.ExpensesTableAdapter.Update(Me.Shops_DBDataSet.Expenses)


        Try
            ' If Me.Shops_DBDataSet.HasChanges Then
            Me.Validate()

            If Me.validateControls = False Then
                Exit Sub
            End If
        
            Me.ExpensesBindingSource.EndEdit()
            Me.ExpensesTableAdapter.Update(Me.Shops_DBDataSet.Expenses)
            Me.ExpensesTableAdapter.Fill(Me.Shops_DBDataSet.Expenses)
            ' End If
            'me.CategoriesTableAdapter .
        Catch ex As Exception
            Utils.showException(ex)
        End Try

    End Sub

    Private Sub frmExpenses_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       


        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.ExpenseType' table. You can move, or remove it, as needed.
            Me.ExpenseTypeTableAdapter.Fill(Me.Shops_DBDataSet.ExpenseType)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Expenses' table. You can move, or remove it, as needed.
            Me.ExpensesTableAdapter.Fill(Me.Shops_DBDataSet.Expenses)
            Me.ControlsInitialize()
        Catch ex As Exception
            Utils.showMessage(ex.ToString)

        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.ExpensesBindingSource.EndEdit()
            Me.EditMode()
        Catch ex As Exception
            Me.ExpensesBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub EditToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles EditToolStripButton.Click
        EditMode()
    End Sub

    Private Sub SwitchToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles SwitchToolStripButton.Click
        Switch()
    End Sub

    Private Sub ExpensesDataGridView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ExpensesDataGridView.CellDoubleClick
        EditMode()
    End Sub

    Private Sub btnExporttoExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcel.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.ExpensesDataGridView
            Dim column As Integer = 1

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = " Expenses Details "

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
                        'If IsNumeric(Me.dGrd.Rows(i).Cells(j).Value.ToString.Trim) Then
                        If j = 1 Then
                            dr(count) = Me.getExpenseByID(CInt(dgrd.Rows(i).Cells(j).Value))

                        ElseIf j = 3 Then
                            dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("dd-MMM-yyyy")

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

    Private Function getExpenseByID(ByVal ID As Integer)
        Dim membername As String = ""
        Dim row As Shops_DBDataSet.ExpenseTypeRow
        For i As Integer = 0 To Me.Shops_DBDataSet.ExpenseType.Rows.Count - 1
            row = Me.Shops_DBDataSet.ExpenseType.Rows(i)
            If row.Id = ID Then
                membername = row.TypeName
                Exit For
            End If
        Next
        Return membername
    End Function

    Private Sub ExpensesBindingSource_AddingNew(sender As System.Object, e As System.ComponentModel.AddingNewEventArgs) Handles ExpensesBindingSource.AddingNew
        Me.Shops_DBDataSet.Expenses.DateSpentColumn.DefaultValue = DateSpentDateTimePicker.Value
    End Sub
End Class