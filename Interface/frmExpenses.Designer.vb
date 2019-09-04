<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpenses
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExpenseTypeIdLabel As System.Windows.Forms.Label
        Dim AmountSpentLabel As System.Windows.Forms.Label
        Dim DateSpentLabel As System.Windows.Forms.Label
        Dim ExpenseDetailLabel As System.Windows.Forms.Label
        Dim ApprovedByLabel As System.Windows.Forms.Label
        Dim ReceiptDetailLabel As System.Windows.Forms.Label
        Dim PaidToLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpenses))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ExpensesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.ExpensesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Shops_DBDataSet = New Shop_Manager.Shops_DBDataSet()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExpensesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SwitchToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExporttoExcel = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ExpensesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ExpenseTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New Shop_Manager.CalendarColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpenseTypeIdComboBox = New System.Windows.Forms.ComboBox()
        Me.AmountSpentTextBox = New System.Windows.Forms.TextBox()
        Me.DateSpentDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ExpenseDetailTextBox = New System.Windows.Forms.TextBox()
        Me.ApprovedByTextBox = New System.Windows.Forms.TextBox()
        Me.ReceiptDetailTextBox = New System.Windows.Forms.TextBox()
        Me.PaidToTextBox = New System.Windows.Forms.TextBox()
        Me.ExpensesTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.ExpensesTableAdapter()
        Me.ExpenseTypeTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.ExpenseTypeTableAdapter()
        ExpenseTypeIdLabel = New System.Windows.Forms.Label()
        AmountSpentLabel = New System.Windows.Forms.Label()
        DateSpentLabel = New System.Windows.Forms.Label()
        ExpenseDetailLabel = New System.Windows.Forms.Label()
        ApprovedByLabel = New System.Windows.Forms.Label()
        ReceiptDetailLabel = New System.Windows.Forms.Label()
        PaidToLabel = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ExpensesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpensesBindingNavigator.SuspendLayout()
        CType(Me.ExpensesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.ExpensesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpenseTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExpenseTypeIdLabel
        '
        ExpenseTypeIdLabel.AutoSize = True
        ExpenseTypeIdLabel.Location = New System.Drawing.Point(213, 45)
        ExpenseTypeIdLabel.Name = "ExpenseTypeIdLabel"
        ExpenseTypeIdLabel.Size = New System.Drawing.Size(113, 20)
        ExpenseTypeIdLabel.TabIndex = 0
        ExpenseTypeIdLabel.Text = "Expense Type:"
        '
        'AmountSpentLabel
        '
        AmountSpentLabel.AutoSize = True
        AmountSpentLabel.Location = New System.Drawing.Point(213, 99)
        AmountSpentLabel.Name = "AmountSpentLabel"
        AmountSpentLabel.Size = New System.Drawing.Size(116, 20)
        AmountSpentLabel.TabIndex = 2
        AmountSpentLabel.Text = "Amount Spent:"
        '
        'DateSpentLabel
        '
        DateSpentLabel.AutoSize = True
        DateSpentLabel.Location = New System.Drawing.Point(213, 153)
        DateSpentLabel.Name = "DateSpentLabel"
        DateSpentLabel.Size = New System.Drawing.Size(95, 20)
        DateSpentLabel.TabIndex = 4
        DateSpentLabel.Text = "Date Spent:"
        '
        'ExpenseDetailLabel
        '
        ExpenseDetailLabel.AutoSize = True
        ExpenseDetailLabel.Location = New System.Drawing.Point(213, 207)
        ExpenseDetailLabel.Name = "ExpenseDetailLabel"
        ExpenseDetailLabel.Size = New System.Drawing.Size(120, 20)
        ExpenseDetailLabel.TabIndex = 6
        ExpenseDetailLabel.Text = "Expense Detail:"
        '
        'ApprovedByLabel
        '
        ApprovedByLabel.AutoSize = True
        ApprovedByLabel.Location = New System.Drawing.Point(213, 261)
        ApprovedByLabel.Name = "ApprovedByLabel"
        ApprovedByLabel.Size = New System.Drawing.Size(103, 20)
        ApprovedByLabel.TabIndex = 8
        ApprovedByLabel.Text = "Approved By:"
        '
        'ReceiptDetailLabel
        '
        ReceiptDetailLabel.AutoSize = True
        ReceiptDetailLabel.Location = New System.Drawing.Point(213, 315)
        ReceiptDetailLabel.Name = "ReceiptDetailLabel"
        ReceiptDetailLabel.Size = New System.Drawing.Size(113, 20)
        ReceiptDetailLabel.TabIndex = 10
        ReceiptDetailLabel.Text = "Receipt Detail:"
        '
        'PaidToLabel
        '
        PaidToLabel.AutoSize = True
        PaidToLabel.Location = New System.Drawing.Point(213, 369)
        PaidToLabel.Name = "PaidToLabel"
        PaidToLabel.Size = New System.Drawing.Size(66, 20)
        PaidToLabel.TabIndex = 12
        PaidToLabel.Text = "Paid To:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ExpensesBindingNavigator)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1183, 672)
        Me.SplitContainer1.SplitterDistance = 55
        Me.SplitContainer1.TabIndex = 0
        '
        'ExpensesBindingNavigator
        '
        Me.ExpensesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ExpensesBindingNavigator.BindingSource = Me.ExpensesBindingSource
        Me.ExpensesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ExpensesBindingNavigator.DeleteItem = Nothing
        Me.ExpensesBindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpensesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.ExpensesBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.EditToolStripButton, Me.SwitchToolStripButton, Me.ToolStripSeparator2, Me.btnExporttoExcel})
        Me.ExpensesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ExpensesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ExpensesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ExpensesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ExpensesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ExpensesBindingNavigator.Name = "ExpensesBindingNavigator"
        Me.ExpensesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ExpensesBindingNavigator.Size = New System.Drawing.Size(1183, 55)
        Me.ExpensesBindingNavigator.TabIndex = 1
        Me.ExpensesBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(103, 52)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'ExpensesBindingSource
        '
        Me.ExpensesBindingSource.DataMember = "Expenses"
        Me.ExpensesBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'Shops_DBDataSet
        '
        Me.Shops_DBDataSet.DataSetName = "Shops_DBDataSet"
        Me.Shops_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(54, 52)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 52)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 52)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 55)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 31)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 52)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 52)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'ExpensesBindingNavigatorSaveItem
        '
        Me.ExpensesBindingNavigatorSaveItem.Image = CType(resources.GetObject("ExpensesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ExpensesBindingNavigatorSaveItem.Name = "ExpensesBindingNavigatorSaveItem"
        Me.ExpensesBindingNavigatorSaveItem.Size = New System.Drawing.Size(111, 52)
        Me.ExpensesBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'EditToolStripButton
        '
        Me.EditToolStripButton.Image = Global.Shop_Manager.My.Resources.Resources.edit_icon1
        Me.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditToolStripButton.Name = "EditToolStripButton"
        Me.EditToolStripButton.Size = New System.Drawing.Size(62, 52)
        Me.EditToolStripButton.Text = "Edit"
        '
        'SwitchToolStripButton
        '
        Me.SwitchToolStripButton.Image = Global.Shop_Manager.My.Resources.Resources.Refresh_icon
        Me.SwitchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SwitchToolStripButton.Name = "SwitchToolStripButton"
        Me.SwitchToolStripButton.Size = New System.Drawing.Size(125, 52)
        Me.SwitchToolStripButton.Text = "Switch View"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'btnExporttoExcel
        '
        Me.btnExporttoExcel.Image = Global.Shop_Manager.My.Resources.Resources.excelIcon
        Me.btnExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExporttoExcel.Name = "btnExporttoExcel"
        Me.btnExporttoExcel.Size = New System.Drawing.Size(148, 52)
        Me.btnExporttoExcel.Text = "Export to Excel"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.Controls.Add(Me.ExpensesDataGridView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(ExpenseTypeIdLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ExpenseTypeIdComboBox)
        Me.SplitContainer2.Panel2.Controls.Add(AmountSpentLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.AmountSpentTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(DateSpentLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.DateSpentDateTimePicker)
        Me.SplitContainer2.Panel2.Controls.Add(ExpenseDetailLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ExpenseDetailTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(ApprovedByLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ApprovedByTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(ReceiptDetailLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ReceiptDetailTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(PaidToLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.PaidToTextBox)
        Me.SplitContainer2.Size = New System.Drawing.Size(1183, 613)
        Me.SplitContainer2.SplitterDistance = 122
        Me.SplitContainer2.TabIndex = 0
        '
        'ExpensesDataGridView
        '
        Me.ExpensesDataGridView.AllowUserToAddRows = False
        Me.ExpensesDataGridView.AllowUserToDeleteRows = False
        Me.ExpensesDataGridView.AutoGenerateColumns = False
        Me.ExpensesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExpensesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.ExpensesDataGridView.DataSource = Me.ExpensesBindingSource
        Me.ExpensesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpensesDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.ExpensesDataGridView.Name = "ExpensesDataGridView"
        Me.ExpensesDataGridView.ReadOnly = True
        Me.ExpensesDataGridView.RowTemplate.Height = 28
        Me.ExpensesDataGridView.Size = New System.Drawing.Size(1183, 122)
        Me.ExpensesDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ExpenseTypeId"
        Me.DataGridViewTextBoxColumn2.DataSource = Me.ExpenseTypeBindingSource
        Me.DataGridViewTextBoxColumn2.DisplayMember = "TypeName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Expense Type"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn2.ValueMember = "Id"
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'ExpenseTypeBindingSource
        '
        Me.ExpenseTypeBindingSource.DataMember = "ExpenseType"
        Me.ExpenseTypeBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "AmountSpent"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Amount Spent"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DateSpent"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Date Spent"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ExpenseDetail"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Expense Detail"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ApprovedBy"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Approved By"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 120
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ReceiptDetail"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Receipt Detail"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 120
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PaidTo"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Paid To"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'ExpenseTypeIdComboBox
        '
        Me.ExpenseTypeIdComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ExpensesBindingSource, "ExpenseTypeId", True))
        Me.ExpenseTypeIdComboBox.DataSource = Me.ExpenseTypeBindingSource
        Me.ExpenseTypeIdComboBox.DisplayMember = "TypeName"
        Me.ExpenseTypeIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ExpenseTypeIdComboBox.FormattingEnabled = True
        Me.ExpenseTypeIdComboBox.Location = New System.Drawing.Point(387, 42)
        Me.ExpenseTypeIdComboBox.Name = "ExpenseTypeIdComboBox"
        Me.ExpenseTypeIdComboBox.Size = New System.Drawing.Size(342, 28)
        Me.ExpenseTypeIdComboBox.TabIndex = 1
        Me.ExpenseTypeIdComboBox.ValueMember = "Id"
        '
        'AmountSpentTextBox
        '
        Me.AmountSpentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "AmountSpent", True))
        Me.AmountSpentTextBox.Location = New System.Drawing.Point(387, 97)
        Me.AmountSpentTextBox.Name = "AmountSpentTextBox"
        Me.AmountSpentTextBox.Size = New System.Drawing.Size(342, 26)
        Me.AmountSpentTextBox.TabIndex = 3
        '
        'DateSpentDateTimePicker
        '
        Me.DateSpentDateTimePicker.CustomFormat = "dd-MMM-yyyy"
        Me.DateSpentDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ExpensesBindingSource, "DateSpent", True))
        Me.DateSpentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateSpentDateTimePicker.Location = New System.Drawing.Point(387, 150)
        Me.DateSpentDateTimePicker.Name = "DateSpentDateTimePicker"
        Me.DateSpentDateTimePicker.Size = New System.Drawing.Size(342, 26)
        Me.DateSpentDateTimePicker.TabIndex = 5
        '
        'ExpenseDetailTextBox
        '
        Me.ExpenseDetailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "ExpenseDetail", True))
        Me.ExpenseDetailTextBox.Location = New System.Drawing.Point(387, 203)
        Me.ExpenseDetailTextBox.Name = "ExpenseDetailTextBox"
        Me.ExpenseDetailTextBox.Size = New System.Drawing.Size(342, 26)
        Me.ExpenseDetailTextBox.TabIndex = 7
        '
        'ApprovedByTextBox
        '
        Me.ApprovedByTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "ApprovedBy", True))
        Me.ApprovedByTextBox.Location = New System.Drawing.Point(387, 256)
        Me.ApprovedByTextBox.Name = "ApprovedByTextBox"
        Me.ApprovedByTextBox.Size = New System.Drawing.Size(342, 26)
        Me.ApprovedByTextBox.TabIndex = 9
        '
        'ReceiptDetailTextBox
        '
        Me.ReceiptDetailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "ReceiptDetail", True))
        Me.ReceiptDetailTextBox.Location = New System.Drawing.Point(387, 309)
        Me.ReceiptDetailTextBox.Name = "ReceiptDetailTextBox"
        Me.ReceiptDetailTextBox.Size = New System.Drawing.Size(342, 26)
        Me.ReceiptDetailTextBox.TabIndex = 11
        '
        'PaidToTextBox
        '
        Me.PaidToTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "PaidTo", True))
        Me.PaidToTextBox.Location = New System.Drawing.Point(387, 362)
        Me.PaidToTextBox.Name = "PaidToTextBox"
        Me.PaidToTextBox.Size = New System.Drawing.Size(342, 26)
        Me.PaidToTextBox.TabIndex = 13
        '
        'ExpensesTableAdapter
        '
        Me.ExpensesTableAdapter.ClearBeforeFill = True
        '
        'ExpenseTypeTableAdapter
        '
        Me.ExpenseTypeTableAdapter.ClearBeforeFill = True
        '
        'frmExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 672)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmExpenses"
        Me.Text = "Expenses"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ExpensesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpensesBindingNavigator.ResumeLayout(False)
        Me.ExpensesBindingNavigator.PerformLayout()
        CType(Me.ExpensesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.ExpensesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpenseTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Shops_DBDataSet As Shop_Manager.Shops_DBDataSet
    Friend WithEvents ExpensesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExpensesTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.ExpensesTableAdapter
    Friend WithEvents ExpensesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExpensesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExpensesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ExpenseTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExpenseTypeTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.ExpenseTypeTableAdapter
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As Shop_Manager.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SwitchToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExpenseTypeIdComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AmountSpentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateSpentDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ExpenseDetailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ApprovedByTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReceiptDetailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaidToTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExporttoExcel As System.Windows.Forms.ToolStripButton
End Class
