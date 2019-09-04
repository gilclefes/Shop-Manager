Public Class frmExpenseType

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
        Me.ExpenseTypeBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub



    Private Function ValidateControls() As Boolean
        If Me.TypeNameTextBox.Text = "" Then
            Utils.showMessage("Please Enter the Expense Type Name")
            Return False
        End If

        If Utils.ValueExist_New(Me.ExpenseTypeDataGridView, 1, Me.TypeNameTextBox.Text) = True Then
            Utils.showMessage("Please Expense Type Name Already Exists")
            Return False
        End If

        Return True
    End Function

    Private Sub ExpenseTypeBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpenseTypeBindingNavigatorSaveItem.Click
       

        Try
            ' If Me.Shops_DBDataSet.HasChanges Then
            Me.Validate()

            If Me.ValidateControls = False Then
                Exit Sub
            End If
            Me.ExpenseTypeBindingSource.EndEdit()
            Me.ExpenseTypeTableAdapter.Update(Me.Shops_DBDataSet.ExpenseType)
            Me.ExpenseTypeTableAdapter.Fill(Me.Shops_DBDataSet.ExpenseType)
            ' End If
            'me.CategoriesTableAdapter .
        Catch ex As Exception
            Utils.showException(ex)
        End Try

    End Sub

    Private Sub frmExpenseType_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Shops_DBDataSet.ExpenseType' table. You can move, or remove it, as needed.

        Try
               Me.ExpenseTypeTableAdapter.Fill(Me.Shops_DBDataSet.ExpenseType)
            Me.ControlsInitialize()
        Catch ex As Exception
            Utils.showMessage(ex.ToString)

        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.ExpenseTypeBindingSource.EndEdit()
            Me.EditMode()
        Catch ex As Exception
            Me.ExpenseTypeBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub EditToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles EditToolStripButton.Click
        EditMode()
    End Sub

    Private Sub SwitchToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles SwitchToolStripButton.Click
        Switch()
    End Sub

    Private Sub ExpenseTypeDataGridView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ExpenseTypeDataGridView.CellDoubleClick
        EditMode()
    End Sub

    Private Sub ExpenseTypeDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ExpenseTypeDataGridView.DataError
        Try
            Utils.showException(e.Exception)
        Catch ex As Exception
            Me.ExpenseTypeBindingSource.CancelEdit()
        End Try
    End Sub
End Class