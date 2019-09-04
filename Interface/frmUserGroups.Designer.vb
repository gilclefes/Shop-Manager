<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserGroups
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserGroups))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.UsergroupsDataGridView = New System.Windows.Forms.DataGridView
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UsergroupsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAddnew = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtGroupName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGroupDescription = New System.Windows.Forms.TextBox
        Me.chkMenus = New System.Windows.Forms.CheckedListBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.UsergroupsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UsergroupsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UsergroupsBindingNavigator.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.UsergroupsDataGridView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(717, 566)
        Me.SplitContainer1.SplitterDistance = 186
        Me.SplitContainer1.TabIndex = 0
        '
        'UsergroupsDataGridView
        '
        Me.UsergroupsDataGridView.AllowUserToAddRows = False
        Me.UsergroupsDataGridView.AllowUserToDeleteRows = False
        Me.UsergroupsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UsergroupsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.UsergroupsDataGridView.Name = "UsergroupsDataGridView"
        Me.UsergroupsDataGridView.ReadOnly = True
        Me.UsergroupsDataGridView.Size = New System.Drawing.Size(717, 186)
        Me.UsergroupsDataGridView.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(717, 376)
        Me.SplitContainer2.SplitterDistance = 45
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UsergroupsBindingNavigator)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(717, 45)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'UsergroupsBindingNavigator
        '
        Me.UsergroupsBindingNavigator.AddNewItem = Nothing
        Me.UsergroupsBindingNavigator.CountItem = Nothing
        Me.UsergroupsBindingNavigator.DeleteItem = Nothing
        Me.UsergroupsBindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UsergroupsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorSeparator1, Me.btnAddnew, Me.btnDelete, Me.btnSave})
        Me.UsergroupsBindingNavigator.Location = New System.Drawing.Point(3, 16)
        Me.UsergroupsBindingNavigator.MoveFirstItem = Nothing
        Me.UsergroupsBindingNavigator.MoveLastItem = Nothing
        Me.UsergroupsBindingNavigator.MoveNextItem = Nothing
        Me.UsergroupsBindingNavigator.MovePreviousItem = Nothing
        Me.UsergroupsBindingNavigator.Name = "UsergroupsBindingNavigator"
        Me.UsergroupsBindingNavigator.PositionItem = Nothing
        Me.UsergroupsBindingNavigator.Size = New System.Drawing.Size(711, 26)
        Me.UsergroupsBindingNavigator.TabIndex = 1
        Me.UsergroupsBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 26)
        '
        'btnAddnew
        '
        Me.btnAddnew.Image = CType(resources.GetObject("btnAddnew.Image"), System.Drawing.Image)
        Me.btnAddnew.Name = "btnAddnew"
        Me.btnAddnew.RightToLeftAutoMirrorImage = True
        Me.btnAddnew.Size = New System.Drawing.Size(74, 23)
        Me.btnAddnew.Text = "Add new"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeftAutoMirrorImage = True
        Me.btnDelete.Size = New System.Drawing.Size(60, 23)
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 23)
        Me.btnSave.Text = "Save Data"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtGroupName)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtGroupDescription)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.chkMenus)
        Me.SplitContainer3.Size = New System.Drawing.Size(717, 327)
        Me.SplitContainer3.SplitterDistance = 80
        Me.SplitContainer3.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Group Menus"
        '
        'txtGroupName
        '
        Me.txtGroupName.Location = New System.Drawing.Point(135, 6)
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.Size = New System.Drawing.Size(247, 20)
        Me.txtGroupName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Group Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Group Description"
        '
        'txtGroupDescription
        '
        Me.txtGroupDescription.Location = New System.Drawing.Point(135, 32)
        Me.txtGroupDescription.Name = "txtGroupDescription"
        Me.txtGroupDescription.Size = New System.Drawing.Size(247, 20)
        Me.txtGroupDescription.TabIndex = 3
        '
        'chkMenus
        '
        Me.chkMenus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chkMenus.CheckOnClick = True
        Me.chkMenus.ColumnWidth = 150
        Me.chkMenus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkMenus.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMenus.FormattingEnabled = True
        Me.chkMenus.Location = New System.Drawing.Point(0, 0)
        Me.chkMenus.MultiColumn = True
        Me.chkMenus.Name = "chkMenus"
        Me.chkMenus.Size = New System.Drawing.Size(717, 240)
        Me.chkMenus.TabIndex = 5
        '
        'frmUserGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 566)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserGroups"
        Me.Text = "User Groups"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.UsergroupsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.UsergroupsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UsergroupsBindingNavigator.ResumeLayout(False)
        Me.UsergroupsBindingNavigator.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UsergroupsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGroupDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents chkMenus As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UsergroupsBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAddnew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
End Class
