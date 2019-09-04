<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShopDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShopDetails))
        Dim ShopNameLabel As System.Windows.Forms.Label
        Dim TelephoneLabel As System.Windows.Forms.Label
        Dim OwnerNameLabel As System.Windows.Forms.Label
        Dim LocationLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Shops_DBDataSet = New Shop_Manager.Shops_DBDataSet()
        Me.ShopInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShopInfoTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.ShopInfoTableAdapter()
        Me.ShopInfoBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.ShopInfoBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ShopInfoDataGridView = New System.Windows.Forms.DataGridView()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EditToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SwitchToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ShopNameTextBox = New System.Windows.Forms.TextBox()
        Me.TelephoneTextBox = New System.Windows.Forms.TextBox()
        Me.OwnerNameTextBox = New System.Windows.Forms.TextBox()
        Me.LocationTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        ShopNameLabel = New System.Windows.Forms.Label()
        TelephoneLabel = New System.Windows.Forms.Label()
        OwnerNameLabel = New System.Windows.Forms.Label()
        LocationLabel = New System.Windows.Forms.Label()
        EmailLabel = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShopInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShopInfoBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ShopInfoBindingNavigator.SuspendLayout()
        CType(Me.ShopInfoDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.ShopInfoBindingNavigator)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(880, 589)
        Me.SplitContainer1.SplitterDistance = 52
        Me.SplitContainer1.TabIndex = 0
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.ShopInfoDataGridView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(ShopNameLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ShopNameTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(TelephoneLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TelephoneTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(OwnerNameLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.OwnerNameTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(LocationLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.LocationTextBox)
        Me.SplitContainer2.Panel2.Controls.Add(EmailLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.EmailTextBox)
        Me.SplitContainer2.Size = New System.Drawing.Size(880, 533)
        Me.SplitContainer2.SplitterDistance = 107
        Me.SplitContainer2.TabIndex = 0
        '
        'Shops_DBDataSet
        '
        Me.Shops_DBDataSet.DataSetName = "Shops_DBDataSet"
        Me.Shops_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ShopInfoBindingSource
        '
        Me.ShopInfoBindingSource.DataMember = "ShopInfo"
        Me.ShopInfoBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'ShopInfoTableAdapter
        '
        Me.ShopInfoTableAdapter.ClearBeforeFill = True
        '
        'ShopInfoBindingNavigator
        '
        Me.ShopInfoBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ShopInfoBindingNavigator.BindingSource = Me.ShopInfoBindingSource
        Me.ShopInfoBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ShopInfoBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ShopInfoBindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShopInfoBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ShopInfoBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.EditToolStripButton, Me.SwitchToolStripButton})
        Me.ShopInfoBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ShopInfoBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ShopInfoBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ShopInfoBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ShopInfoBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ShopInfoBindingNavigator.Name = "ShopInfoBindingNavigator"
        Me.ShopInfoBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ShopInfoBindingNavigator.Size = New System.Drawing.Size(880, 52)
        Me.ShopInfoBindingNavigator.TabIndex = 1
        Me.ShopInfoBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 49)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 49)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 52)
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(54, 49)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 52)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 49)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 49)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 52)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(103, 49)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 49)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'ShopInfoBindingNavigatorSaveItem
        '
        Me.ShopInfoBindingNavigatorSaveItem.Image = CType(resources.GetObject("ShopInfoBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ShopInfoBindingNavigatorSaveItem.Name = "ShopInfoBindingNavigatorSaveItem"
        Me.ShopInfoBindingNavigatorSaveItem.Size = New System.Drawing.Size(111, 49)
        Me.ShopInfoBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ShopInfoDataGridView
        '
        Me.ShopInfoDataGridView.AllowUserToAddRows = False
        Me.ShopInfoDataGridView.AllowUserToDeleteRows = False
        Me.ShopInfoDataGridView.AutoGenerateColumns = False
        Me.ShopInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ShopInfoDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.ShopInfoDataGridView.DataSource = Me.ShopInfoBindingSource
        Me.ShopInfoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShopInfoDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.ShopInfoDataGridView.Name = "ShopInfoDataGridView"
        Me.ShopInfoDataGridView.ReadOnly = True
        Me.ShopInfoDataGridView.RowTemplate.Height = 28
        Me.ShopInfoDataGridView.Size = New System.Drawing.Size(880, 107)
        Me.ShopInfoDataGridView.TabIndex = 0
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 52)
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
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ShopName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ShopName"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Telephone"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Telephone"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "OwnerName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "OwnerName"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Location"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Location"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Email"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'EditToolStripButton
        '
        Me.EditToolStripButton.Image = Global.Shop_Manager.My.Resources.Resources.edit_icon1
        Me.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditToolStripButton.Name = "EditToolStripButton"
        Me.EditToolStripButton.Size = New System.Drawing.Size(62, 49)
        Me.EditToolStripButton.Text = "Edit"
        '
        'SwitchToolStripButton
        '
        Me.SwitchToolStripButton.Image = Global.Shop_Manager.My.Resources.Resources.Refresh_icon
        Me.SwitchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SwitchToolStripButton.Name = "SwitchToolStripButton"
        Me.SwitchToolStripButton.Size = New System.Drawing.Size(125, 49)
        Me.SwitchToolStripButton.Text = "Switch View"
        '
        'ShopNameLabel
        '
        ShopNameLabel.AutoSize = True
        ShopNameLabel.Location = New System.Drawing.Point(231, 44)
        ShopNameLabel.Name = "ShopNameLabel"
        ShopNameLabel.Size = New System.Drawing.Size(97, 20)
        ShopNameLabel.TabIndex = 2
        ShopNameLabel.Text = "Shop Name:"
        '
        'ShopNameTextBox
        '
        Me.ShopNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ShopInfoBindingSource, "ShopName", True))
        Me.ShopNameTextBox.Location = New System.Drawing.Point(349, 41)
        Me.ShopNameTextBox.Name = "ShopNameTextBox"
        Me.ShopNameTextBox.Size = New System.Drawing.Size(329, 26)
        Me.ShopNameTextBox.TabIndex = 3
        '
        'TelephoneLabel
        '
        TelephoneLabel.AutoSize = True
        TelephoneLabel.Location = New System.Drawing.Point(231, 104)
        TelephoneLabel.Name = "TelephoneLabel"
        TelephoneLabel.Size = New System.Drawing.Size(88, 20)
        TelephoneLabel.TabIndex = 4
        TelephoneLabel.Text = "Telephone:"
        '
        'TelephoneTextBox
        '
        Me.TelephoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ShopInfoBindingSource, "Telephone", True))
        Me.TelephoneTextBox.Location = New System.Drawing.Point(349, 101)
        Me.TelephoneTextBox.Name = "TelephoneTextBox"
        Me.TelephoneTextBox.Size = New System.Drawing.Size(329, 26)
        Me.TelephoneTextBox.TabIndex = 5
        '
        'OwnerNameLabel
        '
        OwnerNameLabel.AutoSize = True
        OwnerNameLabel.Location = New System.Drawing.Point(231, 164)
        OwnerNameLabel.Name = "OwnerNameLabel"
        OwnerNameLabel.Size = New System.Drawing.Size(105, 20)
        OwnerNameLabel.TabIndex = 6
        OwnerNameLabel.Text = "Owner Name:"
        '
        'OwnerNameTextBox
        '
        Me.OwnerNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ShopInfoBindingSource, "OwnerName", True))
        Me.OwnerNameTextBox.Location = New System.Drawing.Point(349, 161)
        Me.OwnerNameTextBox.Name = "OwnerNameTextBox"
        Me.OwnerNameTextBox.Size = New System.Drawing.Size(329, 26)
        Me.OwnerNameTextBox.TabIndex = 7
        '
        'LocationLabel
        '
        LocationLabel.AutoSize = True
        LocationLabel.Location = New System.Drawing.Point(231, 224)
        LocationLabel.Name = "LocationLabel"
        LocationLabel.Size = New System.Drawing.Size(74, 20)
        LocationLabel.TabIndex = 8
        LocationLabel.Text = "Location:"
        '
        'LocationTextBox
        '
        Me.LocationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ShopInfoBindingSource, "Location", True))
        Me.LocationTextBox.Location = New System.Drawing.Point(349, 221)
        Me.LocationTextBox.Name = "LocationTextBox"
        Me.LocationTextBox.Size = New System.Drawing.Size(329, 26)
        Me.LocationTextBox.TabIndex = 9
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Location = New System.Drawing.Point(231, 284)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(52, 20)
        EmailLabel.TabIndex = 10
        EmailLabel.Text = "Email:"
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ShopInfoBindingSource, "Email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(349, 281)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(329, 26)
        Me.EmailTextBox.TabIndex = 11
        '
        'frmShopDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 589)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmShopDetails"
        Me.Text = "Shop Details"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShopInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShopInfoBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ShopInfoBindingNavigator.ResumeLayout(False)
        Me.ShopInfoBindingNavigator.PerformLayout()
        CType(Me.ShopInfoDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Shops_DBDataSet As Shop_Manager.Shops_DBDataSet
    Friend WithEvents ShopInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShopInfoTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.ShopInfoTableAdapter
    Friend WithEvents ShopInfoBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents ShopInfoBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShopInfoDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SwitchToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ShopNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelephoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OwnerNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LocationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
End Class
