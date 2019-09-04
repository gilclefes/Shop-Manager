<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditorsPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreditorsPayment))
        Me.Shops_DBDataSet = New Shop_Manager.Shops_DBDataSet
        Me.DatePaidDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.AmountpaidTextBox = New System.Windows.Forms.TextBox
        Me.btnPayment = New System.Windows.Forms.Button
        Me.ReceiptNoTextBox = New System.Windows.Forms.TextBox
        Me.CreditorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CreditorsTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.creditorsTableAdapter
        Me.CreditorsDataGridView = New System.Windows.Forms.DataGridView
        Me.SuppliersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuppliersTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.suppliersTableAdapter
        Me.Payment_creditorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Payment_creditorsTableAdapter = New Shop_Manager.Shops_DBDataSetTableAdapters.payment_creditorsTableAdapter
        Me.Payment_creditorsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New Shop_Manager.CalendarColumn
        Me.DataGridViewTextBoxColumn8 = New Shop_Manager.TimeColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditorsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuppliersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Payment_creditorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Payment_creditorsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatePaidLabel
        '
        DatePaidLabel.AutoSize = True
        DatePaidLabel.Location = New System.Drawing.Point(487, 311)
        DatePaidLabel.Name = "DatePaidLabel"
        DatePaidLabel.Size = New System.Drawing.Size(57, 13)
        DatePaidLabel.TabIndex = 3
        DatePaidLabel.Text = "Date Paid:"
        '
        'AmountpaidLabel
        '
        AmountpaidLabel.AutoSize = True
        AmountpaidLabel.Location = New System.Drawing.Point(487, 343)
        AmountpaidLabel.Name = "AmountpaidLabel"
        AmountpaidLabel.Size = New System.Drawing.Size(66, 13)
        AmountpaidLabel.TabIndex = 5
        AmountpaidLabel.Text = "Amountpaid:"
        '
        'ReceiptNoLabel
        '
        ReceiptNoLabel.AutoSize = True
        ReceiptNoLabel.Location = New System.Drawing.Point(487, 378)
        ReceiptNoLabel.Name = "ReceiptNoLabel"
        ReceiptNoLabel.Size = New System.Drawing.Size(64, 13)
        ReceiptNoLabel.TabIndex = 7
        ReceiptNoLabel.Text = "Receipt No:"
        '
        'Shops_DBDataSet
        '
        Me.Shops_DBDataSet.DataSetName = "Shops_DBDataSet"
        Me.Shops_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DatePaidDateTimePicker
        '
        Me.DatePaidDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePaidDateTimePicker.Location = New System.Drawing.Point(611, 307)
        Me.DatePaidDateTimePicker.Name = "DatePaidDateTimePicker"
        Me.DatePaidDateTimePicker.Size = New System.Drawing.Size(165, 20)
        Me.DatePaidDateTimePicker.TabIndex = 4
        '
        'AmountpaidTextBox
        '
        Me.AmountpaidTextBox.Location = New System.Drawing.Point(611, 339)
        Me.AmountpaidTextBox.Name = "AmountpaidTextBox"
        Me.AmountpaidTextBox.Size = New System.Drawing.Size(165, 20)
        Me.AmountpaidTextBox.TabIndex = 6
        '
        'btnPayment
        '
        Me.btnPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.Location = New System.Drawing.Point(490, 406)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(158, 37)
        Me.btnPayment.TabIndex = 7
        Me.btnPayment.Text = "Make Payment"
        Me.btnPayment.UseVisualStyleBackColor = True
        '
        'ReceiptNoTextBox
        '
        Me.ReceiptNoTextBox.Location = New System.Drawing.Point(611, 374)
        Me.ReceiptNoTextBox.Name = "ReceiptNoTextBox"
        Me.ReceiptNoTextBox.Size = New System.Drawing.Size(165, 20)
        Me.ReceiptNoTextBox.TabIndex = 8
        '
        'CreditorsBindingSource
        '
        Me.CreditorsBindingSource.DataMember = "creditors"
        Me.CreditorsBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'CreditorsTableAdapter
        '
        Me.CreditorsTableAdapter.ClearBeforeFill = True
        '
        'CreditorsDataGridView
        '
        Me.CreditorsDataGridView.AllowUserToAddRows = False
        Me.CreditorsDataGridView.AllowUserToDeleteRows = False
        Me.CreditorsDataGridView.AutoGenerateColumns = False
        Me.CreditorsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewCheckBoxColumn1})
        Me.CreditorsDataGridView.DataSource = Me.CreditorsBindingSource
        Me.CreditorsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditorsDataGridView.Location = New System.Drawing.Point(3, 16)
        Me.CreditorsDataGridView.Name = "CreditorsDataGridView"
        Me.CreditorsDataGridView.ReadOnly = True
        Me.CreditorsDataGridView.Size = New System.Drawing.Size(456, 416)
        Me.CreditorsDataGridView.TabIndex = 9
        '
        'SuppliersBindingSource
        '
        Me.SuppliersBindingSource.DataMember = "suppliers"
        Me.SuppliersBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'SuppliersTableAdapter
        '
        Me.SuppliersTableAdapter.ClearBeforeFill = True
        '
        'Payment_creditorsBindingSource
        '
        Me.Payment_creditorsBindingSource.DataMember = "payment_creditors"
        Me.Payment_creditorsBindingSource.DataSource = Me.Shops_DBDataSet
        '
        'Payment_creditorsTableAdapter
        '
        Me.Payment_creditorsTableAdapter.ClearBeforeFill = True
        '
        'Payment_creditorsDataGridView
        '
        Me.Payment_creditorsDataGridView.AllowUserToAddRows = False
        Me.Payment_creditorsDataGridView.AllowUserToDeleteRows = False
        Me.Payment_creditorsDataGridView.AutoGenerateColumns = False
        Me.Payment_creditorsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.Payment_creditorsDataGridView.DataSource = Me.Payment_creditorsBindingSource
        Me.Payment_creditorsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Payment_creditorsDataGridView.Location = New System.Drawing.Point(3, 16)
        Me.Payment_creditorsDataGridView.Name = "Payment_creditorsDataGridView"
        Me.Payment_creditorsDataGridView.ReadOnly = True
        Me.Payment_creditorsDataGridView.Size = New System.Drawing.Size(445, 244)
        Me.Payment_creditorsDataGridView.TabIndex = 9
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
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "OrderID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "OrderID"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CreditorsDataGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(462, 435)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Creditors Information"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Payment_creditorsDataGridView)
        Me.GroupBox2.Location = New System.Drawing.Point(470, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(451, 263)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Creditors Payments"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "OrderID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "OrderID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "SupplierID"
        Me.DataGridViewTextBoxColumn2.DataSource = Me.SuppliersBindingSource
        Me.DataGridViewTextBoxColumn2.DisplayMember = "CompanyName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Supplier Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.ValueMember = "SupplierID"
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
        'frmCreditorsPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 446)
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
        Me.Name = "frmCreditorsPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creditors Payment"
        CType(Me.Shops_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditorsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuppliersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Payment_creditorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Payment_creditorsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Shops_DBDataSet As Shop_Manager.Shops_DBDataSet
    Friend WithEvents DatePaidDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents AmountpaidTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents ReceiptNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreditorsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CreditorsTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.creditorsTableAdapter
    Friend WithEvents CreditorsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SuppliersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SuppliersTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.suppliersTableAdapter
    Friend WithEvents Payment_creditorsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Payment_creditorsTableAdapter As Shop_Manager.Shops_DBDataSetTableAdapters.payment_creditorsTableAdapter
    Friend WithEvents Payment_creditorsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As Shop_Manager.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As Shop_Manager.TimeColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
