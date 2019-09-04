Public Class frmLogin

    Private userid As String = ""
    Private groupID As Integer
    Private userFullName As String = ""
    Private password As String = ""
    Private roles As String = ""
    Private daUsers As New Shops_DBDataSetTableAdapters.userstblTableAdapter
    Private dtUsers As New Shops_DBDataSet.userstblDataTable

    Private daGroups As New Shops_DBDataSetTableAdapters.usergroupsTableAdapter
    Private dtGroup As New Shops_DBDataSet.usergroupsDataTable




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            If Me.txtUsername.Text = "" Then
                Utils.showMessage("Please Enter Your Username")
                Exit Sub
            End If

            If Me.txtPassword.Text = "" Then
                Utils.showMessage("Please Enter Your Password")
                Exit Sub
            End If

            Me.daUsers.FillByUser(Me.dtUsers, Me.txtUsername.Text)
            If Me.dtUsers.Rows.Count <= 0 Then
                Utils.showMessage("Please Enter Your Correct Username")
            Else
                Dim row As Shops_DBDataSet.userstblRow = Me.dtUsers.Rows(0)
                Me.userid = row.Userid
                Me.userFullName = row.EmployeeID
                Me.password = Utils.decrypt(row.Passwd)

                If String.Compare(Me.password, Me.txtPassword.Text.Trim) = 0 Then
                    If String.Compare("user", Me.txtPassword.Text.Trim) = 0 Then

                        Utils.showMessage("Please your password is : " & Me.txtPassword.Text.Trim & vbCrLf & " And is known so Change it")
                        Dim f As New frmChangePassword
                        f.userid = Me.txtUsername.Text

                        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.txtUsername.Text = ""
                            Me.txtPassword.Text = ""
                            Me.txtUsername.Focus()
                        End If
                    Else
                        Me.groupID = CInt(row.GroupID)
                        Me.daGroups.FillByID(Me.dtGroup, Me.groupID)
                        Me.roles = Me.dtGroup.Rows(0)(2).ToString

                        Dim frmStart As New frmStartPage

                        frmStart.username = row.Userid
                        frmStart.roles = roles
                        frmStart.groupid = row.GroupID
                        frmStart.empid = row.EmployeeID
                        Me.txtPassword.Text = ""
                        Me.Visible = False
                        frmStart.Show()

                    End If

                Else
                    Utils.showMessage("Please Enter Your Correct Password")
                End If

            End If


        Catch ex As Exception
            Utils.showException(ex)
        End Try      
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.daUsers.Fill(Me.dtUsers)
    End Sub
End Class