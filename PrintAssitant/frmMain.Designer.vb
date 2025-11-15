<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.lblTitle = New System.Windows.Forms.Label()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.pbImage = New System.Windows.Forms.PictureBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.grdMain = New System.Windows.Forms.DataGridView()
    Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.PurchaseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ArticleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ColorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SizeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ColorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SizeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SalePrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.BarcodeImage = New System.Windows.Forms.DataGridViewImageColumn()
    Me.btnCheckUnCheck = New System.Windows.Forms.Button()
    Me.Button5 = New System.Windows.Forms.Button()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.Button6 = New System.Windows.Forms.Button()
    Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.btnIndImport = New System.Windows.Forms.Button()
    Me.Panel1.SuspendLayout()
    CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(164, Byte), Integer))
    Me.Panel1.Controls.Add(Me.lblTitle)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.pbImage)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1331, 42)
    Me.Panel1.TabIndex = 0
    '
    'lblTitle
    '
    Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lblTitle.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblTitle.ForeColor = System.Drawing.Color.White
    Me.lblTitle.Location = New System.Drawing.Point(43, 0)
    Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.lblTitle.Name = "lblTitle"
    Me.lblTitle.Size = New System.Drawing.Size(1186, 42)
    Me.lblTitle.TabIndex = 3
    Me.lblTitle.Text = "Inn Sole Print Assitant"
    Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Button3
    '
    Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(150, Byte), Integer))
    Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
    Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
    Me.Button3.Location = New System.Drawing.Point(1229, 0)
    Me.Button3.Margin = New System.Windows.Forms.Padding(0)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(51, 42)
    Me.Button3.TabIndex = 1
    Me.Button3.TabStop = False
    Me.Button3.Text = "–"
    Me.Button3.UseVisualStyleBackColor = False
    '
    'pbImage
    '
    Me.pbImage.Dock = System.Windows.Forms.DockStyle.Left
    Me.pbImage.Location = New System.Drawing.Point(0, 0)
    Me.pbImage.Margin = New System.Windows.Forms.Padding(4)
    Me.pbImage.Name = "pbImage"
    Me.pbImage.Size = New System.Drawing.Size(43, 42)
    Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.pbImage.TabIndex = 1
    Me.pbImage.TabStop = False
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(150, Byte), Integer))
    Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
    Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
    Me.Button1.Location = New System.Drawing.Point(1280, 0)
    Me.Button1.Margin = New System.Windows.Forms.Padding(0)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(51, 42)
    Me.Button1.TabIndex = 1
    Me.Button1.TabStop = False
    Me.Button1.Text = "X"
    Me.Button1.UseVisualStyleBackColor = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(271, 63)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(82, 20)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Purchase ID"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(43, 315)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(71, 20)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Label Size"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(372, 60)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(284, 24)
    Me.TextBox1.TabIndex = 0
    '
    'grdMain
    '
    Me.grdMain.AllowUserToAddRows = False
    Me.grdMain.AllowUserToDeleteRows = False
    Me.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grdMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Barcode, Me.PurchaseID, Me.ArticleName, Me.ColorID, Me.SizeID, Me.ColorName, Me.SizeDesc, Me.SalePrice, Me.BarcodeImage})
    Me.grdMain.Location = New System.Drawing.Point(47, 99)
    Me.grdMain.Name = "grdMain"
    Me.grdMain.RowHeadersWidth = 51
    Me.grdMain.RowTemplate.Height = 24
    Me.grdMain.Size = New System.Drawing.Size(1249, 206)
    Me.grdMain.TabIndex = 3
    '
    'Barcode
    '
    Me.Barcode.DataPropertyName = "Barcode"
    Me.Barcode.HeaderText = "Barcode"
    Me.Barcode.MinimumWidth = 6
    Me.Barcode.Name = "Barcode"
    Me.Barcode.ReadOnly = True
    Me.Barcode.Width = 125
    '
    'PurchaseID
    '
    Me.PurchaseID.DataPropertyName = "PurchaseID"
    Me.PurchaseID.HeaderText = "Purchase ID"
    Me.PurchaseID.MinimumWidth = 6
    Me.PurchaseID.Name = "PurchaseID"
    Me.PurchaseID.ReadOnly = True
    Me.PurchaseID.Visible = False
    Me.PurchaseID.Width = 125
    '
    'ArticleName
    '
    Me.ArticleName.DataPropertyName = "ModelName"
    Me.ArticleName.HeaderText = "Article Name"
    Me.ArticleName.MinimumWidth = 6
    Me.ArticleName.Name = "ArticleName"
    Me.ArticleName.ReadOnly = True
    Me.ArticleName.Width = 300
    '
    'ColorID
    '
    Me.ColorID.DataPropertyName = "ColorID"
    Me.ColorID.HeaderText = "ColorID"
    Me.ColorID.MinimumWidth = 6
    Me.ColorID.Name = "ColorID"
    Me.ColorID.ReadOnly = True
    Me.ColorID.Visible = False
    Me.ColorID.Width = 125
    '
    'SizeID
    '
    Me.SizeID.DataPropertyName = "SizeID"
    Me.SizeID.HeaderText = "Size ID"
    Me.SizeID.MinimumWidth = 6
    Me.SizeID.Name = "SizeID"
    Me.SizeID.ReadOnly = True
    Me.SizeID.Visible = False
    Me.SizeID.Width = 125
    '
    'ColorName
    '
    Me.ColorName.DataPropertyName = "ColorName"
    Me.ColorName.HeaderText = "Color Name"
    Me.ColorName.MinimumWidth = 6
    Me.ColorName.Name = "ColorName"
    Me.ColorName.ReadOnly = True
    Me.ColorName.Width = 250
    '
    'SizeDesc
    '
    Me.SizeDesc.DataPropertyName = "SizeTitle"
    Me.SizeDesc.HeaderText = "Size"
    Me.SizeDesc.MinimumWidth = 6
    Me.SizeDesc.Name = "SizeDesc"
    Me.SizeDesc.ReadOnly = True
    Me.SizeDesc.Width = 170
    '
    'SalePrice
    '
    Me.SalePrice.DataPropertyName = "SalePrice"
    Me.SalePrice.HeaderText = "Sale Price"
    Me.SalePrice.MinimumWidth = 6
    Me.SalePrice.Name = "SalePrice"
    Me.SalePrice.ReadOnly = True
    Me.SalePrice.Width = 125
    '
    'BarcodeImage
    '
    Me.BarcodeImage.HeaderText = "BarcodeImage"
    Me.BarcodeImage.Name = "BarcodeImage"
    Me.BarcodeImage.Visible = False
    '
    'btnCheckUnCheck
    '
    Me.btnCheckUnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnCheckUnCheck.Location = New System.Drawing.Point(47, 56)
    Me.btnCheckUnCheck.Name = "btnCheckUnCheck"
    Me.btnCheckUnCheck.Size = New System.Drawing.Size(115, 37)
    Me.btnCheckUnCheck.TabIndex = 4
    Me.btnCheckUnCheck.Text = "Check All"
    Me.btnCheckUnCheck.UseVisualStyleBackColor = True
    '
    'Button5
    '
    Me.Button5.Location = New System.Drawing.Point(662, 60)
    Me.Button5.Name = "Button5"
    Me.Button5.Size = New System.Drawing.Size(83, 28)
    Me.Button5.TabIndex = 1
    Me.Button5.Text = "Fetch"
    Me.Button5.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"3in x 2in", "2in x 1in"})
    Me.ComboBox1.Location = New System.Drawing.Point(144, 311)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(409, 25)
    Me.ComboBox1.TabIndex = 2
    '
    'Button4
    '
    Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Button4.Location = New System.Drawing.Point(559, 311)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(136, 30)
    Me.Button4.TabIndex = 3
    Me.Button4.Text = "Preview"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Button6
    '
    Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Button6.Location = New System.Drawing.Point(701, 310)
    Me.Button6.Name = "Button6"
    Me.Button6.Size = New System.Drawing.Size(136, 30)
    Me.Button6.TabIndex = 4
    Me.Button6.Text = "Print"
    Me.Button6.UseVisualStyleBackColor = True
    '
    'CrystalReportViewer1
    '
    Me.CrystalReportViewer1.ActiveViewIndex = -1
    Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
    Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 347)
    Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
    Me.CrystalReportViewer1.Size = New System.Drawing.Size(1331, 384)
    Me.CrystalReportViewer1.TabIndex = 5
    Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '
    'btnIndImport
    '
    Me.btnIndImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnIndImport.Location = New System.Drawing.Point(1203, 56)
    Me.btnIndImport.Name = "btnIndImport"
    Me.btnIndImport.Size = New System.Drawing.Size(93, 37)
    Me.btnIndImport.TabIndex = 6
    Me.btnIndImport.Text = "Import"
    Me.btnIndImport.UseVisualStyleBackColor = True
    '
    'frmMain
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(233, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(1331, 736)
    Me.Controls.Add(Me.btnIndImport)
    Me.Controls.Add(Me.CrystalReportViewer1)
    Me.Controls.Add(Me.ComboBox1)
    Me.Controls.Add(Me.Button5)
    Me.Controls.Add(Me.Button6)
    Me.Controls.Add(Me.Button4)
    Me.Controls.Add(Me.btnCheckUnCheck)
    Me.Controls.Add(Me.grdMain)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "frmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Panel1.ResumeLayout(False)
    CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents pbImage As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents grdMain As DataGridView
    Friend WithEvents btnCheckUnCheck As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button6 As Button
  Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PurchaseID As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ArticleName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ColorID As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SizeID As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ColorName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SizeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SalePrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BarcodeImage As System.Windows.Forms.DataGridViewImageColumn
  Friend WithEvents btnIndImport As System.Windows.Forms.Button
End Class
