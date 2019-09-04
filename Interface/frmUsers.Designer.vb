<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsers))
        Me.UserstblBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.UserstblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Shops_DBDataSet = New Shop_Manager.Shops_DBDataSet
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.UserstblBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbResetPassword = New System.Windows.Forms.ToolStripButton
        Me.UserstblDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.EmployeesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.UsergroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UserstblTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.userstblTableAdapter
        Me.EmployeesTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.EmployeesTableAdapter
        Me.UsergroupsTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.usergroupsTableAdapter
        CType(Me.UserstblBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserstblBindingNavigator.SuspendLayout()
        CType(Me.UserstblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserstblDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsergroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserstblBindingNavigator
        '
        Me.UserstblBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.UserstblBindingNavigator.BindingSource = Me.UserstblBindingSource
        Me.UserstblBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.UserstblBindingNavigator.DeleteItem = Nothing
        Me.UserstblBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.UserstblBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.tsbResetPassword})
        Me.UserstblBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.UserstblBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.UserstblBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.UserstblBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.UserstblBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.UserstblBindingNavigator.Name = "UserstblBindingNavigator"
        Me.UserstblBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.UserstblBindingNavigator.Size = New System.Drawing.Size(595, 25)
        Me.UserstblBindingNavigator.TabIndex = 0
        Me.UserstblBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(74, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'UserstblBindingSource
        '
        Me.UserstblBindingSource.DataMember = "userstbl"
        Me.UserstblBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'Shops_DBDataSet
        '
        Me.Shops_DBDataSet.DataSetName = "Shops_DBDataSet"
        Me.Shops_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(60, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'UserstblBindingNavigatorSaveItem
        '
        Me.UserstblBindingNavigatorSaveItem.Image = CType(resources.GetObject("UserstblBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.UserstblBindingNavigatorSaveItem.Name = "UserstblBindingNavigatorSaveItem"
        Me.UserstblBindingNavigatorSaveItem.Size = New System.Drawing.Size(78, 22)
        Me.UserstblBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbResetPassword
        '
        Me.tsbResetPassword.Image = CType(resources.GetObject("tsbResetPassword.Image"), System.Drawing.Image)
        Me.tsbResetPassword.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbResetPassword.Name = "tsbResetPassword"
        Me.tsbResetPassword.Size = New System.Drawing.Size(108, 22)
        Me.tsbResetPassword.Text = "Reset Password"
        '
        'UserstblDataGridView
        '
        Me.UserstblDataGridView.AllowUserToAddRows = False
        Me.UserstblDataGridView.AutoGenerateColumns = False
        Me.UserstblDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.UserstblDataGridView.DataSource = Me.UserstblBindingSource
        Me.UserstblDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserstblDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.UserstblDataGridView.Name = "UserstblDataGridView"
        Me.UserstblDataGridView.Size = New System.Drawing.Size(595, 315)
        Me.UserstblDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Userid"
        Me.DataGridViewTextBoxColumn1.HeaderText = "User Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.DataPropertyName = "Passwd"
        Me.DataGridViewImageColumn1.HeaderText = "Passwd"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "EmployeeID"
        Me.DataGridViewTextBoxColumn2.DataSource = Me.EmployeesBindingSource
        Me.DataGridViewTextBoxColumn2.DisplayMember = "LastName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Employee"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn2.ValueMember = "EmployeeID"
        '
        'EmployeesBindingSource
        '
        Me.EmployeesBindingSource.DataMember = "Employees"
        Me.EmployeesBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "GroupID"
        Me.DataGridViewTextBoxColumn3.DataSource = Me.UsergroupsBindingSource
        Me.DataGridViewTextBoxColumn3.DisplayMember = "GroupName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Group Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn3.ValueMember = "GroupID"
        '
        'UsergroupsBindingSource
        '
        Me.UsergroupsBindingSource.DataMember = "usergroups"
        Me.UsergroupsBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'UserstblTableAdapter
        '
        Me.UserstblTableAdapter.ClearBeforeFill = True
        '
        'EmployeesTableAdapter
        '
        Me.EmployeesTableAdapter.ClearBeforeFill = True
        '
        'UsergroupsTableAdapter
        '
        Me.UsergroupsTableAdapter.ClearBeforeFill = True
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 340)
        Me.Controls.Add(Me.UserstblDataGridView)
        Me.Controls.Add(Me.UserstblBindingNavigator)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Users"
        CType(Me.UserstblBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserstblBindingNavigator.ResumeLayout(False)
        Me.UserstblBindingNavigator.PerformLayout()
        CType(Me.UserstblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserstblDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsergroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Shops_DBDataSet As Shop_Manager.Shops_DBDataSet
    Friend WithEvents UserstblBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UserstblTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.userstblTableAdapter
    Friend WithEvents UserstblBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UserstblBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents UserstblDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents EmployeesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeesTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.EmployeesTableAdapter
    Friend WithEvents tsbResetPassword As System.Windows.Forms.ToolStripButton
    Friend WithEvents UsergroupsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsergroupsTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.usergroupsTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
