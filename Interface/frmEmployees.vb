Public Class frmEmployees


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
        Me.EmployeesBindingSource.CancelEdit()
        If Me.SplitContainer2.Panel1Collapsed = True Then
            Me.SplitContainer2.Panel1Collapsed = False
            Me.SplitContainer2.Panel2Collapsed = True
        Else
            Me.SplitContainer2.Panel1Collapsed = True
            Me.SplitContainer2.Panel2Collapsed = False
        End If

    End Sub

    Private Function validateControls() As Boolean
        If Me.txtLastName.Text = "" Then
            Utils.showMessage("Please Enter Employee's Surname")
            Return False
        End If

        If Me.txtFirstName.Text = "" Then
            Utils.showMessage("Please Enter Employee's First Name")
            Return False
        End If


        If Me.cmbSex.SelectedIndex = -1 Then
            Utils.showMessage("Please select Sex")
            Return False
        End If

        If Me.cmbJobID.SelectedIndex = -1 Then
            Utils.showMessage("Please select Job")
            Return False
        End If

        If CDate(Me.dtpBirthDate.Value.ToShortDateString) > CDate(Now.ToShortDateString) Then
            Utils.showMessage("Please Date of Birth Cannot be greater than today")
            Return False
        End If

        If CDate(Me.dtpBirthDate.Value.ToShortDateString) > CDate(Me.dtpHireDate.Value.ToShortDateString) Then
            Utils.showMessage("Please Date of Birth can not be greater than Hire Date")
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

    Private Sub EmployeesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesBindingNavigatorSaveItem.Click
        Try
            If Me.validateControls = False Then
                Exit Sub
            End If

            Me.Validate()
            Me.EmployeesBindingSource.EndEdit()
            Me.EmployeesTableAdapter.Update(Me.Shops_DBDataSet.Employees)

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub frmEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Jobs' table. You can move, or remove it, as needed.
            Me.JobsTableAdapter.Fill(Me.Shops_DBDataSet.Jobs)
            'TODO: This line of code loads data into the 'Shops_DBDataSet.Employees' table. You can move, or remove it, as needed.
            Me.EmployeesTableAdapter.Fill(Me.Shops_DBDataSet.Employees)
            Me.ControlsInitialize()
            Me.cmbSex.SelectedIndex = 0
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Try
            Me.EmployeesBindingSource.EndEdit()
            Me.EditMode()
        Catch ex As Exception
            Me.EmployeesBindingSource.CancelEdit()
        End Try
    End Sub

    Private Function getJobByID(ByVal ID As Integer)
        Dim membername As String = ""
        Dim row As Shops_DBDataSet.JobsRow
        For i As Integer = 0 To Me.Shops_DBDataSet.Jobs.Rows.Count - 1
            row = Me.Shops_DBDataSet.Jobs.Rows(i)
            If row.JobID = ID Then
                membername = row.JobName
                Exit For
            End If
        Next
        Return membername
    End Function

    Private Sub btnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExporttoExcel.Click
        Try
            Dim dtnew As New DataTable()
            Dim dr As DataRow
            Dim dgrd As DataGridView = Me.EmployeesDataGridView
            Dim column As Integer = 0

            If dgrd.RowCount <= 0 Then
                Utils.showMessage("No record (s) to export")
                Exit Sub
            End If

            Dim title As String = " EMPLOYEES INFORMATION "

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
                     If j = 4 Then
                            dr(count) = Me.getJobByID(CInt(dgrd.Rows(i).Cells(j).Value))

                        ElseIf j = 5 Then
                            dr(count) = CDate((dgrd.Rows(i).Cells(j).Value)).ToString("ddd, dd-MMM-yyyy")
                        ElseIf j = 6 Then
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

    Private Sub EmployeesDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles EmployeesDataGridView.DataError
        Try

        Catch ex As Exception
            Me.EmployeesBindingSource.CancelEdit()
        End Try
    End Sub

    Private Sub EditToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripButton.Click
        Me.EditMode()
    End Sub

    Private Sub SwitchToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchToolStripButton.Click
        Me.Switch()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.PictureBox1.Image = Me.PictureBox1.ErrorImage
    End Sub

    
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Me.PictureBox1.Image = Image.FromFile(Utils.getpicturefromfile)
    End Sub

    Private Sub EmployeesDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EmployeesDataGridView.CellDoubleClick
        Me.EditMode()
    End Sub

    Private Sub EmployeesBindingSource_AddingNew(ByVal sender As System.Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles EmployeesBindingSource.AddingNew
        Try
            Me.Shops_DBDataSet.Employees.BirthDateColumn.DefaultValue = CDate(Me.dtpBirthDate.Value.ToShortDateString)
            Me.Shops_DBDataSet.Employees.HireDateColumn.DefaultValue = CDate(Now.ToShortDateString)

        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub
End Class