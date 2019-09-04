Public Class frmCategories

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
        Me.CategoriesBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub



    Private Function validateControls() As Boolean
        If Me.txtCategory.Text = "" Then
            Utils.showMessage("Please Enter the Category")
            Return False
        End If

        If Utils.ValueExist_New(Me.CategoriesDataGridView, 1, Me.txtCategory.Text) = True Then
            Utils.showMessage("Please Category Name Already Exists")
            Return False
        End If

        Return True
    End Function

    Private Sub CategoriesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriesBindingNavigatorSaveItem.Click
        Try
            If Me.Shops_DBDataSet.HasChanges Then
                Me.Validate()

                If Me.validateControls = False Then
                    Exit Sub
                End If
                Me.CategoriesBindingSource.EndEdit()
                Me.CategoriesTableAdapter.Update(Me.Shops_DBDataSet.categories)
                Me.CategoriesTableAdapter.Fill(Me.Shops_DBDataSet.categories)
            End If
            'me.CategoriesTableAdapter .
        Catch ex As Exception
            Utils.showException(ex)
        End Try


    End Sub

    Private Sub frmCategories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.categories' table. You can move, or remove it, as needed.
            Me.CategoriesTableAdapter.Fill(Me.Shops_DBDataSet.categories)
            Me.ControlsInitialize()
        Catch ex As Exception
            Utils.showMessage(ex.ToString)

        End Try

    End Sub

    Private Sub CategoriesDataGridView_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CategoriesDataGridView.CellClick
        'If e.ColumnIndex = 3 Then
        '    Dim pic As String = Utils.getpicturefromfile

        '    If pic <> "" Then
        '        Me.CategoriesDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Image.FromFile(pic)
        '    End If
        'End If
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.CategoriesBindingSource.EndEdit()
            Me.EditMode()
        Catch ex As Exception
            Me.CategoriesBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub CategoriesDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles CategoriesDataGridView.DataError
        Try
            Utils.showException(e.Exception)
        Catch ex As Exception
            Me.CategoriesBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.PictureBox1.Image = Me.PictureBox1.ErrorImage
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            Me.PictureBox1.Image = Image.FromFile(Utils.getpicturefromfile)
        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub EditToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripButton.Click
        Me.EditMode()
    End Sub

    Private Sub SwitchToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchToolStripButton.Click
        Me.Switch()
    End Sub

    Private Sub CategoriesDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CategoriesDataGridView.CellDoubleClick
        Me.EditMode()
    End Sub
End Class