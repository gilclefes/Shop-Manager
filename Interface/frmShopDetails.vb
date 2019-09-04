Public Class frmShopDetails


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
        Me.ShopInfoBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub

    Private Function validateControls() As Boolean

        If Me.ShopNameTextBox.Text = "" Then
            Utils.showMessage("Please Enter Shop Name")
            Return False
        End If

        If Me.TelephoneTextBox.Text = "" Then
            Utils.showMessage("Please Enter Telephone Number")
            Return False
        End If


        If Me.OwnerNameTextBox.Text = "" Then
            Utils.showMessage("Please Enter Contact Person")
            Return False
        End If

        If Me.LocationTextBox.Text = "" Then
            Utils.showMessage("Please Enter the Location")
            Return False
        End If

     

        If Me.EmailTextBox.Text <> "" Then
            If Utils.ValidateEmail(Me.EmailTextBox.Text) = False Then
                Utils.showMessage("Please Enter a Valid Email Address")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ShopInfoBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles ShopInfoBindingNavigatorSaveItem.Click
       

        Try
            If Me.validateControls = False Then
                Exit Sub
            End If

            Me.Validate()
            Me.ShopInfoBindingSource.EndEdit()
            Me.ShopInfoTableAdapter.Update(Me.Shops_DBDataSet.ShopInfo)

            If Me.Shops_DBDataSet.ShopInfo.Rows.Count > 0 Then
                Me.BindingNavigatorAddNewItem.Visible = False
            End If

        Catch ex As Exception
            Utils.showError(ex.Message)
        End Try

    End Sub

    Private Sub frmShopDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Shops_DBDataSet.ShopInfo' table. You can move, or remove it, as needed.
        Me.ShopInfoTableAdapter.Fill(Me.Shops_DBDataSet.ShopInfo)
        Me.ControlsInitialize()
        If Me.Shops_DBDataSet.ShopInfo.Rows.Count > 0 Then
            Me.BindingNavigatorAddNewItem.Visible = False
        End If

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.ShopInfoBindingSource.EndEdit()
            Me.EditMode()
        Catch ex As Exception
            Me.ShopInfoBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub EditToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles EditToolStripButton.Click
        Me.EditMode()
    End Sub

    Private Sub SwitchToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles SwitchToolStripButton.Click
        Switch()
    End Sub

    Private Sub ShopInfoDataGridView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ShopInfoDataGridView.CellDoubleClick
        EditMode()
    End Sub
End Class