Public Class frmStartPage
    'Dim da As New HospitalDataSetTableAdapters.DiagnosisSelectByDoctorTableAdapter
    Public empid As Integer
    Public groupid As Integer
    Public username As String
    Public roles As String
    Private logoff As Boolean = False

    Private Sub showForm(ByVal frm As Form)
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If

    End Sub

    Function frmexist(ByVal text As String) As Boolean
        Dim frm As Form
        ' Dim found As Boolean = False
        For Each frm In Me.MdiChildren
            With frm
                If .Text = text Then
                    .Activate()
                    Return True
                End If
            End With
        Next
        Return False
    End Function


    Private Sub AddProductsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddProductsToolStripMenuItem.Click
        Dim frm As New frmProducts
        'Dim vals As String = ""
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()

        End If

        'Do
        '    vals = InputBox("Enter the val")
        'Loop Until IsNumeric(vals) = False
    End Sub

    

    Private Sub ProductCategoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductCategoriesToolStripMenuItem.Click
        Dim frm As New frmCategories
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub ProductsStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsStockToolStripMenuItem.Click
        Dim frm As New frmProductStock
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.empID = Me.empid
            frm.Show()
        End If
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppliersToolStripMenuItem.Click
        Dim frm As New frmSuppliers
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub CreditorsPaymentsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditorsPaymentsToolStripMenuItem1.Click
        Dim frm As New frmCreditorsPayment
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub CreditorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditorsToolStripMenuItem.Click
        Dim frm As New frmCreditors
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub EmployeesInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesInfoToolStripMenuItem.Click
        Dim frm As New frmEmployees
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub JobTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobTypesToolStripMenuItem.Click
        Dim frm As New frmJobs
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        Dim frm As New frmUsers
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub UserGroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserGroupsToolStripMenuItem.Click
        Dim frm As New frmUserGroups
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    
    Private Sub DebtorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebtorsToolStripMenuItem.Click
        Dim frm As New frmDebtors
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)

    End Sub

    Private Sub TileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)

    End Sub

    Private Sub DebtorsPaymentsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebtorsPaymentsToolStripMenuItem1.Click
        Dim frm As New frmDebtorsPayment
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersToolStripMenuItem.Click
        Dim frm As New frmCustomers
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub frmStartPage_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim prompt As String = ""
        If Me.logoff = True Then
            prompt = "Are you Sure Yo want To Log Off"
        Else
            prompt = "Are you Sure Yo want To Exit"
        End If

        If Utils.QuestionPrompt(prompt) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
            Exit Sub
        End If

        If Me.logoff = True Then
            If My.Forms.frmLogin.Created = True Then
                My.Forms.frmLogin.Visible = True
            Else

            End If
        Else
            End
        End If

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim f As New frmChangePassword
        f.userid = Me.username
        If f.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Dim da As New Shops_DBDataSetTableAdapters.userstblTableAdapter
            'da.UpdateQuery(Utils.encrypt(f.password), Me.username)
            'Me.WorkersSelectAllTableAdapter.Fill(Me.HospitalDataSet.WorkersSelectAll)
        End If
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        Me.logoff = True
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.logoff = False
        Me.Close()
    End Sub

    Private Sub DatabaseConnectionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseConnectionsToolStripMenuItem.Click
        Dim frm As New frmDbaseConnector
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frm As New frmAboutBox
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ToolStripStatusLabel1.Text = "Current Date           " & Date.Now.ToLongDateString & "          " & Date.Now.ToLongTimeString

    End Sub

   
    Private Sub ProductsReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsReportsToolStripMenuItem.Click
        Dim frm As New frmProductReports
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub btnSalesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmSalesReport
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub SalesReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportsToolStripMenuItem.Click
        Dim frm As New frmSalesReport
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub ProductLocationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductLocationsToolStripMenuItem.Click
        Dim frm As New frmLocations
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub frmStartPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

        If String.Compare(Me.username, "admin", True) <> 0 Then
            For Each t As ToolStripMenuItem In Me.MenuStrip1.Items
                For i As Integer = 0 To t.DropDownItems.Count - 1
                    If TypeOf t.DropDownItems.Item(i) Is ToolStripMenuItem Then
                        Dim m As New menusClass

                        If roles.Contains(t.DropDownItems.Item(i).Text) = False Then
                            t.DropDownItems.Item(i).Visible = False

                        End If
                        Me.enableMenus()
                    End If
                Next
            Next
        End If


    End Sub

    Private Sub enableMenus()
        Me.WindowsToolStripMenuItem.Visible = True
        Me.CascadeToolStripMenuItem.Visible = True
        Me.LogOffToolStripMenuItem.Visible = True
        Me.CloseToolStripMenuItem.Visible = True
        Me.ChangePasswordToolStripMenuItem.Visible = True
        Me.AboutToolStripMenuItem.Visible = True
        Me.HelpToolStripMenuItem1.Visible = True
        Me.TileToolStripMenuItem.Visible = True
        Me.ToolStripMenuItem1.Visible = True
        Me.ChangePasswordToolStripMenuItem.Visible = True

    End Sub

    Private Sub disableMenus()
        For Each mm As ToolStripMenuItem In Me.MenuStrip1.Items
            mm.Enabled = False
        Next

        'For Each ctr As Control In Me.gpControls.Controls
        '    If TypeOf ctr Is Button Then
        '        ctr.Enabled = False
        '    End If
        'Next

        Me.FileToolStripMenuItem.Enabled = True
        Me.HelpToolStripMenuItem.Enabled = True
        Me.WindowsToolStripMenuItem.Enabled = True
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem1.Click
        Dim frm As New frmAboutBox
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmPurchaseReport
        If Me.frmexist(frm.Text) = False Then
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub UserMenusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserMenusToolStripMenuItem.Click
        Dim menus As New List(Of menusClass)
       
        For Each t As ToolStripMenuItem In Me.MenuStrip1.Items
            For i As Integer = 0 To t.DropDownItems.Count - 1
                If TypeOf t.DropDownItems.Item(i) Is ToolStripMenuItem Then
                    Dim m As New menusClass
                    m.MenuName = t.DropDownItems.Item(i).Name
                    m.MenuText = t.DropDownItems.Item(i).Text
                    menus.Add(m)
                End If
            Next
        Next


        Dim frm As New frmMenus
        frm.menus = menus
        Me.showForm(frm)
    End Sub

    Private Sub PurchaseReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReportsToolStripMenuItem.Click
        Dim frm As New frmPurchaseReport
        Me.showForm(frm)
    End Sub

    Private Sub ProductDiscountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductDiscountsToolStripMenuItem.Click
        Dim frm As New frmProductsDiscounts
        Me.showForm(frm)
    End Sub

    Private Sub ProductSalesCompareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductSalesCompareToolStripMenuItem.Click
        Dim frm As New frmProductsCompare
        Me.showForm(frm)
    End Sub

    Private Sub ReturnedGoodsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnedGoodsToolStripMenuItem.Click
        Dim frm As New frmReturnedGoods
        Me.showForm(frm)
    End Sub

    Private Sub ProductsProfitsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsProfitsToolStripMenuItem.Click
        Dim frm As New frmProfits
        Me.showForm(frm)
    End Sub

    Private Sub PromptSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromptSettingsToolStripMenuItem.Click
        Dim frm As New frmPromptSettings
        Me.showForm(frm)
    End Sub

    Private Sub PromptsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromptsToolStripMenuItem.Click
        Dim frm As New frmPrompts
        Me.showForm(frm)
    End Sub

    Private Sub ProductSalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductSalesToolStripMenuItem1.Click
        Dim frm As New frmSales
        frm.empID = Me.empid
        frm.username = Me.username
        Me.showForm(frm)
        
    End Sub

 
    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmSales
        frm.empID = Me.empid
        frm.username = Me.username
        Me.showForm(frm)

    End Sub

    Private Sub EmployeeSalesReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeeSalesReportToolStripMenuItem.Click
        Dim frm As New frmEmployeeSalesReport
        '  frm.empID = Me.empid
        Me.showForm(frm)
    End Sub

    Private Sub ExpenseTypeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpenseTypeToolStripMenuItem.Click
        Dim frm As New frmExpenseType

        Me.showForm(frm)
    End Sub

    Private Sub ExpensesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ExpensesToolStripMenuItem1.Click
        Dim frm As New frmExpenses
        Me.showForm(frm)
    End Sub

    Private Sub ShopInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShopInfoToolStripMenuItem.Click
        Dim frm As New frmShopDetails
        Me.showForm(frm)
    End Sub

    Private Sub DebtorsReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DebtorsReportToolStripMenuItem.Click
        Dim frm As New frmDebtorsReport
        Me.showForm(frm)
    End Sub

    Private Sub ExpensesReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpensesReportToolStripMenuItem.Click
        Dim frm As New ExpenseReport
        Me.showForm(frm)
    End Sub

    Private Sub PriceSetupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PriceSetupToolStripMenuItem.Click
        Dim frm As New frmPriceSetups
        Me.showForm(frm)
    End Sub

    Private Sub WholeSaleReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WholeSaleReportToolStripMenuItem.Click
        Dim frm As New frmWhSalesReport
        Me.showForm(frm)
    End Sub

    Private Sub ProductPurchaseWithPriceSetupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductPurchaseWithPriceSetupToolStripMenuItem.Click
        Dim frm As New frmProductStockWithPriceSetup
        Me.showForm(frm)
    End Sub
End Class