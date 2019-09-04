Public Class frmCustomers


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
        Me.CustomersBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub

    Private Function validateControls() As Boolean
        If Me.txtCompany.Text = "" Then
            Utils.showMessage("Please Enter Company Name")
            Return False
        End If

        If Me.txtContactName.Text = "" Then
            Utils.showMessage("Please Enter Contact Name")
            Return False
        End If


        If Me.txtContactTitle.Text = "" Then
            Utils.showMessage("Please Enter Contact Title")
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

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            If Me.validateControls = False Then
                Exit Sub
            End If
            Me.CustomersBindingSource.EndEdit()
            Me.CustomersTableAdapter.Update(Me.Shops_DBDataSet.customers)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub frmCustomers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.customers' table. You can move, or remove it, as needed.
            Me.CustomersTableAdapter.Fill(Me.Shops_DBDataSet.customers)
            Me.ControlsInitialize()
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub CustomersDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles CustomersDataGridView.DataError
        Try
            'If e.Exception.GetType().Equals(New NoNullAllowedException().GetType()) Then
            '    Utils.showMessage(e.Exception.Message)
            '    'MessageBox.Show(String.Format("Error: {0}", e.Exception.Message))
            '    'Utils.showMessage(e.Exception.Message)
            '    e.Cancel = False
            'End If
        Catch ex As Exception
            Me.CustomersBindingSource.CancelEdit()
        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.EditMode()
            Me.CustomersBindingSource.EndEdit()
        Catch ex As Exception
            Me.CustomersBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub btnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExporttoExcel.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.CustomersDataGridView
            Dim column As Integer = 1

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = " CUSTOMERS INFORMATION "

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

                        dr(count) = dgrd.Rows(i).Cells(j).Value
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

    Private Sub switchToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles switchToolStripButton.Click
        Me.Switch()
    End Sub

    Private Sub CustomersDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CustomersDataGridView.CellDoubleClick
        Me.EditMode()
    End Sub
End Class