<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndividulalPrint
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemNo = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSalePrice = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPurchasePrice = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDisplayPrice = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtInternalItem = New System.Windows.Forms.TextBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item No"
        '
        'txtItemNo
        '
        Me.txtItemNo.Location = New System.Drawing.Point(142, 19)
        Me.txtItemNo.MaxLength = 20
        Me.txtItemNo.Name = "txtItemNo"
        Me.txtItemNo.Size = New System.Drawing.Size(146, 24)
        Me.txtItemNo.TabIndex = 0
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(142, 285)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(154, 36)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update / Print"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(142, 192)
        Me.txtBarcode.MaxLength = 20
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(316, 24)
        Me.txtBarcode.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 226)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Sale Price"
        '
        'txtSalePrice
        '
        Me.txtSalePrice.Location = New System.Drawing.Point(142, 223)
        Me.txtSalePrice.MaxLength = 20
        Me.txtSalePrice.Name = "txtSalePrice"
        Me.txtSalePrice.Size = New System.Drawing.Size(316, 24)
        Me.txtSalePrice.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Product Name"
        '
        'lblProductName
        '
        Me.lblProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductName.Location = New System.Drawing.Point(142, 51)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(316, 22)
        Me.lblProductName.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Quantity"
        '
        'lblQuantity
        '
        Me.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuantity.Location = New System.Drawing.Point(142, 104)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(316, 22)
        Me.lblQuantity.TabIndex = 0
        Me.lblQuantity.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Purchase Price"
        '
        'lblPurchasePrice
        '
        Me.lblPurchasePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPurchasePrice.Location = New System.Drawing.Point(142, 132)
        Me.lblPurchasePrice.Name = "lblPurchasePrice"
        Me.lblPurchasePrice.Size = New System.Drawing.Size(100, 22)
        Me.lblPurchasePrice.TabIndex = 0
        Me.lblPurchasePrice.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(248, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Display Price"
        '
        'lblDisplayPrice
        '
        Me.lblDisplayPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisplayPrice.Location = New System.Drawing.Point(369, 132)
        Me.lblDisplayPrice.Name = "lblDisplayPrice"
        Me.lblDisplayPrice.Size = New System.Drawing.Size(89, 22)
        Me.lblDisplayPrice.TabIndex = 0
        Me.lblDisplayPrice.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Vendor Name"
        '
        'lblVendor
        '
        Me.lblVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVendor.Location = New System.Drawing.Point(142, 77)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(316, 22)
        Me.lblVendor.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 257)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tax Percentage"
        '
        'txtTax
        '
        Me.txtTax.Location = New System.Drawing.Point(142, 254)
        Me.txtTax.MaxLength = 3
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Size = New System.Drawing.Size(316, 24)
        Me.txtTax.TabIndex = 4
        Me.txtTax.Text = "13"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 164)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Inner Item No."
        '
        'txtInternalItem
        '
        Me.txtInternalItem.Location = New System.Drawing.Point(142, 161)
        Me.txtInternalItem.MaxLength = 20
        Me.txtInternalItem.Name = "txtInternalItem"
        Me.txtInternalItem.Size = New System.Drawing.Size(316, 24)
        Me.txtInternalItem.TabIndex = 1
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(464, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(610, 337)
        Me.CrystalReportViewer1.TabIndex = 6
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(304, 284)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(154, 36)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "Update / Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(15, 284)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(120, 36)
        Me.btnBack.TabIndex = 7
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'frmIndividulalPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1074, 337)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtTax)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSalePrice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtInternalItem)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtItemNo)
        Me.Controls.Add(Me.lblDisplayPrice)
        Me.Controls.Add(Me.lblPurchasePrice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frmIndividulalPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Individual Label"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemNo As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSalePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPurchasePrice As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPrice As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTax As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtInternalItem As TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
