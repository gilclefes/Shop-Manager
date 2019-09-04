Public Class frmUserGroups

    Private daMenus As New Shops_DBDataSetTableAdapters.tblMenuTableAdapter
    Private dtMenus As New Shops_DBDataSet.tblMenuDataTable

    Private groupdID As Integer
    Private daUserGroup As New Shops_DBDataSetTableAdapters.usergroupsTableAdapter
    Private dtUserGroups As New Shops_DBDataSet.usergroupsDataTable


    Private Sub FillData()
        Me.daUserGroup.Fill(Me.dtUserGroups)
        Me.UsergroupsDataGridView.DataSource = Me.dtUserGroups
        Me.UsergroupsDataGridView.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.UsergroupsDataGridView.Columns(0).Visible = False
    End Sub
    
    Private Function getSelctedMenus() As String
        Dim menus As String = ""

       
        Dim i As Integer = 0
        For i = 0 To Me.chkMenus.CheckedItems.Count - 1

            menus = menus & Me.chkMenus.CheckedItems(i).ToString & ","

        Next
        'MsgBox(menus)
        Return menus
    End Function


    Private Sub frmUserGroups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'ChurchAdminDB.usergroups' table. You can move, or remove it, as needed.
            FillData()
            Me.daMenus.Fill(Me.dtMenus)
            If Me.dtMenus.Rows.Count > 0 Then
                For i As Integer = 0 To Me.dtMenus.Rows.Count - 1
                    Me.chkMenus.Items.Add(Me.dtMenus.Rows(i)(2).ToString)
                Next
            End If

        Catch ex As Exception
            Utils.showException(ex)
        End Try


    End Sub
    Private Sub clear()
        Me.txtGroupName.Text = ""
        Me.txtGroupDescription.Text = ""
        
        For i As Integer = 0 To Me.chkMenus.Items.Count - 1
            Me.chkMenus.SetItemChecked(i, False)        
        Next

    End Sub
    

  
    Private Sub UsergroupsDataGridView_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsergroupsDataGridView.CurrentCellChanged
        Try
            clear()

            If Not Me.UsergroupsDataGridView.CurrentRow Is Nothing Then
                Dim pos As Integer = Me.UsergroupsDataGridView.CurrentRow.Index
                Dim menus As String = Me.dtUserGroups.Rows(pos)(2).ToString

                Me.txtGroupName.Text = Me.dtUserGroups.Rows(pos)(1).ToString
                Me.txtGroupDescription.Text = Me.dtUserGroups.Rows(pos)(3).ToString


                For i As Integer = 0 To Me.chkMenus.Items.Count - 1
                    If menus.Contains(Me.chkMenus.Items.Item(i).ToString) Then
                        Me.chkMenus.SetItemChecked(i, True)

                    End If

                Next
            End If


        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddnew.Click
        Try
            If Me.btnAddnew.Text = "Add new" Then

                clear()
                Me.btnAddnew.Text = "Cancel"
            Else
                Me.btnAddnew.Text = "Add new"
            End If


        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If Me.txtGroupName.Text = "" Then
                Utils.showMessage("Please enter the group name")
                Exit Sub
            End If

            If Me.chkMenus.CheckedItems.Count <= 0 Then
                Utils.showMessage("Please choose menus that should be accessible to the Group")
                Exit Sub
            End If

            If Utils.ValueExist(Me.UsergroupsDataGridView, 1, Me.txtGroupName.Text) = True Then
                Utils.showMessage("Please Duplicates are not accepted in the Group Name Column")

                Exit Sub
            End If

            If Me.btnAddnew.Text = "Cancel" Then
                Me.daUserGroup.Insert(Me.txtGroupName.Text, Me.txtGroupDescription.Text, Me.getSelctedMenus)

                FillData()
                Me.btnAddnew.Text = "Add new"
            Else
                If Me.UsergroupsDataGridView.CurrentRow.Index < 0 Then
                    Utils.showMessage("Please select row to update")

                Else
                    Dim row As Integer = Me.UsergroupsDataGridView.CurrentRow.Index
                    Dim grpID As Integer = CInt(Me.dtUserGroups.Rows(row)(0).ToString)
                    Me.daUserGroup.UpdateQuery(Me.txtGroupName.Text, Me.txtGroupDescription.Text, Me.getSelctedMenus, grpID)
                    FillData()
                End If
            End If


        Catch ex As Exception
            Utils.showException(ex)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Utils.deletePrompt = Windows.Forms.DialogResult.Yes Then
            If Me.UsergroupsDataGridView.CurrentRow.Index < 0 Then
                Utils.showMessage("Please select row to delete")

            Else

                Dim row As Integer = Me.UsergroupsDataGridView.CurrentRow.Index
                Dim grpID As Integer = CInt(Me.dtUserGroups.Rows(row)(0).ToString)
                Me.daUserGroup.DeleteQuery(grpID)
                FillData()
            End If
        End If

    End Sub
End Class