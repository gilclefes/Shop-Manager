Public Class frmSuppliers


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
        Me.SuppliersBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub

    Private Function validateControls() As Boolean
        If Me.txtCompanyName.Text = "" Then
            Utils.showMessage("Please Enter Company Name")
            Return False
        End If

        If Me.txtContactName.Text = "" Then
            Utils.showMessage("Please Enter Contact Name")
            Return False
        End If


        If Me.txtContactName.Text = "" Then
            Utils.showMessage("Please Enter Contact Title")
            Return False
        End If

        If Me.txtCountry.Text = "" Then
            Utils.showMessage("Please Enter the Country")
            Return False
        End If

        If Me.txtPhoneNo.Text = "" Then
            Utils.showMessage("Please Enter the Phone Number")
            Return False
        End If

        If Me.txtEmailAddress.Text <> "" Then
            If Utils.ValidateEmail(Me.txtEmailAddress.Text) = False Then
                Utils.showMessage("Please Enter a Valid Email Address")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SuppliersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppliersBindingNavigatorSaveItem.Click
        Try
            If Me.validateControls = False Then
                Exit Sub
            End If
            Me.Validate()
            Me.SuppliersBindingSource.EndEdit()
            Me.SuppliersTableAdapter.Update(Me.Shops_DBDataSet.suppliers)

        Catch ex As Exception
            Utils.showError(ex.Message)
        End Try

    End Sub

    Private Sub frmSuppliers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.suppliers' table. You can move, or remove it, as needed.
            Me.SuppliersTableAdapter.Fill(Me.Shops_DBDataSet.suppliers)
            Me.ControlsInitialize()
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.SuppliersBindingSource.EndEdit()
            Me.EditMode()
        Catch ex As Exception
            Me.SuppliersBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub btnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExporttoExcel.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.SuppliersDataGridView
            Dim column As Integer = 1

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = " SUPPLIERS INFORMATION "

            For col As Integer = column To dgrd.ColumnCount - 2
                With dtnew
                    .Columns.Add(dgrd.Columns(col).Name, System.Type.GetType("System.String")) 'SN
                    'COMMENTS
                End With

            Next

            'adding the column hearder as the first row
            dr = dtnew.NewRow()
            For col As Integer = column To dgrd.ColumnCount - 2

                With dtnew
                    dr(col - column) = dgrd.Columns(col).HeaderText
                End With

            Next
            dtnew.Rows.Add(dr)

            For i As Integer = 0 To dgrd.RowCount - 1
                dr = dtnew.NewRow()
                Dim count As Integer = 0
                For j As Integer = column To dgrd.ColumnCount - 2


                    If Not IsDBNull(dgrd.Rows(i).Cells(j).Value) Then
                        'If IsNumeric(Me.dGrd.Rows(i).Cells(j).Value.ToString.Trim) Then
                        'If j = 4 Then
                        '    dr(count) = Me.getJobByID(CInt(dgrd.Rows(i).Cells(j).Value))

                        'ElseIf j = 5 Then
                        '    dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
                        'ElseIf j = 6 Then
                        '    dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
                        'Else
                        dr(count) = dgrd.Rows(i).Cells(j).Value
                        'End If

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

    Private Sub EditToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripButton.Click
        Me.EditMode()
    End Sub

    Private Sub SwitchToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchToolStripButton.Click
        Me.Switch()
    End Sub

    Private Sub SuppliersDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SuppliersDataGridView.CellDoubleClick
        Me.EditMode()
    End Sub
End Class