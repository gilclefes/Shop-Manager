<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDebtorsPayment
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
        Dim DatePaidLabel As System.Windows.Forms.Label
        Dim AmountpaidLabel As System.Windows.Forms.Label
        Dim ReceiptNoLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDebtorsPayment))
        Me.DebtorsDataGridView = New System.Windows.Forms.DataGridView
        Me.CustomersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Shops_DBDataSet = New Shop_Manager.Shops_DBDataSet
        Me.DebtorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatePaidDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.AmountpaidTextBox = New System.Windows.Forms.TextBox
        Me.btnPayment = New System.Windows.Forms.Button
        Me.Payment_debtorsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New Shop_Manager.CalendarColumn
        Me.DataGridViewTextBoxColumn8 = New Shop_Manager.TimeColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Payment_debtorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptNoTextBox = New System.Windows.Forms.TextBox
        Me.DebtorsTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.DebtorsTableAdapter
        Me.CustomersTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.customersTableAdapter
        Me.Payment_debtorsTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.payment_debtorsTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        DatePaidLabel = New System.Windows.Forms.Label
        AmountpaidLabel = New System.Windows.Forms.Label
        ReceiptNoLabel = New System.Windows.Forms.Label
        CType(Me.DebtorsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DebtorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Payment_debtorsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Payment_debtorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatePaidLabel
        '
        DatePaidLabel.AutoSize = True
        DatePaidLabel.Location = New System.Drawing.Point(487, 281)
        DatePaidLabel.Name = "DatePaidLabel"
        DatePaidLabel.Size = New System.Drawing.Size(57, 13)
        DatePaidLabel.TabIndex = 3
        DatePaidLabel.Text = "Date Paid:"
        '
        'AmountpaidLabel
        '
        AmountpaidLabel.AutoSize = True
        AmountpaidLabel.Location = New System.Drawing.Point(487, 313)
        AmountpaidLabel.Name = "AmountpaidLabel"
        AmountpaidLabel.Size = New System.Drawing.Size(66, 13)
        AmountpaidLabel.TabIndex = 5
        AmountpaidLabel.Text = "Amountpaid:"
        '
        'ReceiptNoLabel
        '
        ReceiptNoLabel.AutoSize = True
        ReceiptNoLabel.Location = New System.Drawing.Point(487, 348)
        ReceiptNoLabel.Name = "ReceiptNoLabel"
        ReceiptNoLabel.Size = New System.Drawing.Size(64, 13)
        ReceiptNoLabel.TabIndex = 7
        ReceiptNoLabel.Text = "Receipt No:"
        '
        'DebtorsDataGridView
        '
        Me.DebtorsDataGridView.AllowUserToAddRows = False
        Me.DebtorsDataGridView.AllowUserToDeleteRows = False
        Me.DebtorsDataGridView.AutoGenerateColumns = False
        Me.DebtorsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewCheckBoxColumn1})
        Me.DebtorsDataGridView.DataSource = Me.DebtorsBindingSource
        Me.DebtorsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebtorsDataGridView.Location = New System.Drawing.Point(3, 16)
        Me.DebtorsDataGridView.Name = "DebtorsDataGridView"
        Me.DebtorsDataGridView.ReadOnly = True
        Me.DebtorsDataGridView.Size = New System.Drawing.Size(439, 407)
        Me.DebtorsDataGridView.TabIndex = 1
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DataMember = "customers"
        Me.CustomersBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'Shops_DBDataSet
        '
        Me.Shops_DBDataSet.DataSetName = "Shops_DBDataSet"
        Me.Shops_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DebtorsBindingSource
        '
        Me.DebtorsBindingSource.DataMember = "Debtors"
        Me.DebtorsBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'DatePaidDateTimePicker
        '
        Me.DatePaidDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePaidDateTimePicker.Location = New System.Drawing.Point(611, 278)
        Me.DatePaidDateTimePicker.Name = "DatePaidDateTimePicker"
        Me.DatePaidDateTimePicker.Size = New System.Drawing.Size(165, 20)
        Me.DatePaidDateTimePicker.TabIndex = 4
        '
        'AmountpaidTextBox
        '
        Me.AmountpaidTextBox.Location = New System.Drawing.Point(611, 313)
        Me.AmountpaidTextBox.Name = "AmountpaidTextBox"
        Me.AmountpaidTextBox.Size = New System.Drawing.Size(165, 20)
        Me.AmountpaidTextBox.TabIndex = 6
        '
        'btnPayment
        '
        Me.btnPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.Location = New System.Drawing.Point(490, 389)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(158, 37)
        Me.btnPayment.TabIndex = 7
        Me.btnPayment.Text = "Make Payment"
        Me.btnPayment.UseVisualStyleBackColor = True
        '
        'Payment_debtorsDataGridView
        '
        Me.Payment_debtorsDataGridView.AllowUserToAddRows = False
        Me.Payment_debtorsDataGridView.AllowUserToDeleteRows = False
        Me.Payment_debtorsDataGridView.AutoGenerateColumns = False
        Me.Payment_debtorsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.Payment_debtorsDataGridView.DataSource = Me.Payment_debtorsBindingSource
        Me.Payment_debtorsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Payment_debtorsDataGridView.Location = New System.Drawing.Point(3, 16)
        Me.Payment_debtorsDataGridView.Name = "Payment_debtorsDataGridView"
        Me.Payment_debtorsDataGridView.ReadOnly = True
        Me.Payment_debtorsDataGridView.Size = New System.Drawing.Size(438, 232)
        Me.Payment_debtorsDataGridView.TabIndex = 7
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PaymentID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "PaymentID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "SalesID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "SalesID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "DatePaid"
        Me.DataGridViewTextBoxColumn7.HeaderText = "DatePaid"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "TimePaid"
        Me.DataGridViewTextBoxColumn8.HeaderText = "TimePaid"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Amountpaid"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Amountpaid"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "ReceiptNo"
        Me.DataGridViewTextBoxColumn10.HeaderText = "ReceiptNo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'Payment_debtorsBindingSource
        '
        Me.Payment_debtorsBindingSource.DataMember = "payment_debtors"
        Me.Payment_debtorsBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'ReceiptNoTextBox
        '
        Me.ReceiptNoTextBox.Location = New System.Drawing.Point(611, 348)
        Me.ReceiptNoTextBox.Name = "ReceiptNoTextBox"
        Me.ReceiptNoTextBox.Size = New System.Drawing.Size(165, 20)
        Me.ReceiptNoTextBox.TabIndex = 8
        '
        'DebtorsTableAdapter
        '
        Me.DebtorsTableAdapter.ClearBeforeFill = True
        '
        'CustomersTableAdapter
        '
        Me.CustomersTableAdapter.ClearBeforeFill = True
        '
        'Payment_debtorsTableAdapter
        '
        Me.Payment_debtorsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DebtorsDataGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 426)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Creditors Information"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Payment_debtorsDataGridView)
        Me.GroupBox2.Location = New System.Drawing.Point(460, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(444, 251)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Creditor Payments"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SalesID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "SalesID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CustomerID"
        Me.DataGridViewTextBoxColumn2.DataSource = Me.CustomersBindingSource
        Me.DataGridViewTextBoxColumn2.DisplayMember = "ContactName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Customer"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.ValueMember = "CustomerID"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "EmployeeID"
        Me.DataGridViewTextBoxColumn3.HeaderText = "EmployeeID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "AmountDue"
        Me.DataGridViewTextBoxColumn4.HeaderText = "AmountDue"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "CompletePayments"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "CompletePayments"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Visible = False
        '
        'frmDebtorsPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 438)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(ReceiptNoLabel)
        Me.Controls.Add(Me.ReceiptNoTextBox)
        Me.Controls.Add(Me.btnPayment)
        Me.Controls.Add(AmountpaidLabel)
        Me.Controls.Add(Me.AmountpaidTextBox)
        Me.Controls.Add(DatePaidLabel)
        Me.Controls.Add(Me.DatePaidDateTimePicker)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDebtorsPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debtors Payment"
        CType(Me.DebtorsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DebtorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Payment_debtorsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Payment_debtorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Shops_DBDataSet As Shop_Manager.Shops_DBDataSet
    Friend WithEvents DebtorsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DebtorsTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.DebtorsTableAdapter
    Friend WithEvents DebtorsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents CustomersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomersTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.customersTableAdapter
    Friend WithEvents DatePaidDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents AmountpaidTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents Payment_debtorsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Payment_debtorsTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.payment_debtorsTableAdapter
    Friend WithEvents Payment_debtorsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As Shop_Manager.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As Shop_Manager.TimeColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
