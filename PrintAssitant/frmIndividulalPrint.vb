Imports System.Data.SqlClient
Imports System.IO

Public Class frmIndividulalPrint

    Dim Crypto As New Simple3Des("InnSole")
    Private Function GetInventoryItem(itemNo As String) As DataRow
        Dim dt As New DataTable

        If txtItemNo.Text.Trim() = "" Then
            lblProductName.Text = ""
            lblVendor.Text = ""
            lblPurchasePrice.Text = ""
            lblDisplayPrice.Text = ""
            lblQuantity.Text = ""
            txtInternalItem.Clear()
            txtBarcode.Clear()
            txtSalePrice.Clear()
            txtTax.Text = "13"
            Return Nothing
        End If

        Using Con As New SqlConnection(ConStr)
            Con.Open()
            Dim Cmd As New SqlCommand("spGetItemInfo", Con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@ItemNo", itemNo)

            Dim da As New SqlDataAdapter(Cmd)
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                lblProductName.Text = "No record found..."
                lblVendor.Text = "No record found..."
                lblPurchasePrice.Text = ""
                lblDisplayPrice.Text = ""
                lblQuantity.Text = ""
                txtInternalItem.Clear()
                txtBarcode.Clear()
                txtSalePrice.Clear()
                txtTax.Text = "13"
                Return Nothing
            End If
            If (dt(0)("Processed").ToString() = "True") Then
                MessageBox.Show("This item has already been processed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblQuantity.ForeColor = Color.FromArgb(255, 0, 0)
                lblPurchasePrice.ForeColor = Color.FromArgb(255, 0, 0)
                lblVendor.ForeColor = Color.Red
                lblDisplayPrice.ForeColor = Color.FromArgb(255, 0, 0)
                lblProductName.ForeColor = Color.FromArgb(255, 0, 0)
            Else
                lblQuantity.ForeColor = Color.FromArgb(0, 0, 0)
                lblPurchasePrice.ForeColor = Color.FromArgb(0, 0, 0)
                lblDisplayPrice.ForeColor = Color.FromArgb(0, 0, 0)
                lblProductName.ForeColor = Color.FromArgb(0, 0, 0)
                lblVendor.ForeColor = Color.Black
            End If
            lblQuantity.Text = dt(0)("Qty").ToString()
            lblPurchasePrice.Text = dt(0)("PurchasePrice").ToString()
            lblDisplayPrice.Text = dt(0)("UnitRetail").ToString()
            lblProductName.Text = dt(0)("Description").ToString()
            lblVendor.Text = dt(0)("Vendor").ToString()
            txtSalePrice.Text = IIf(dt(0)("SalePrice").ToString() = "0", "", dt(0)("SalePrice").ToString())
            txtInternalItem.Clear()
            txtBarcode.Clear()
            txtTax.Text = "13"
            txtInternalItem.Focus()
        End Using

        Return dt.Rows(0)
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If TypeOf Me.ActiveControl Is Button Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        If keyData = Keys.Enter Then
            ' Move focus to next control
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            Return True ' Handled
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function GetOrCreatePurchase(lotNo As String, supplierId As Integer) As Integer
        Dim purchaseId As Integer = 0

        Using con As New SqlConnection(ConStr)
            con.Open()

            ' Check existing purchase
            Dim checkCmd As New SqlCommand("Select TOP 1 ID FROM tblPurchases WHERE LotNo = @LotNo", con)
            checkCmd.Parameters.AddWithValue("@LotNo", lotNo)

            Dim obj = checkCmd.ExecuteScalar()
            If obj IsNot Nothing Then
                Return Convert.ToInt32(obj)
            End If

            ' Create new purchase
            Dim insertCmd As New SqlCommand("INSERT INTO tblPurchases (LotNo, Cash, Discount, PurchaseInvoice, PurchaseDate, created, created_by, InvStatus, SupplierID) VALUES (@LotNo, 0, 0, 'Imp', GETDATE(), GETDATE(), '1da7364d-fc6b-4e3e-b290-56727fec2c65', 0, @SupplierID); SELECT SCOPE_IDENTITY();", con)
            insertCmd.Parameters.AddWithValue("@LotNo", lotNo)
            insertCmd.Parameters.AddWithValue("@SupplierID", supplierId)

            purchaseId = Convert.ToInt32(insertCmd.ExecuteScalar())
        End Using

        Return purchaseId
    End Function


    Private Function InsertPurchaseDetails(purchaseId As Integer, inv As DataRow, barcode As String, salePrice As Decimal, Tax As Int16, InnerItem As String) As Integer
        Dim recId As Integer = 0

        Using Con As New SqlConnection(ConStr)
            Con.Open()
            Dim Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandText = "spSavePurchaseDetails"
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.Parameters.AddWithValue("@PurchaseID", purchaseId)
            Cmd.Parameters.AddWithValue("@ProductID", inv("ProductID"))
            Cmd.Parameters.AddWithValue("@Barcode", barcode)
            Cmd.Parameters.AddWithValue("@Qty", inv("Qty"))
            Cmd.Parameters.AddWithValue("@PurchasePrice", inv("PurchasePrice"))
            Cmd.Parameters.AddWithValue("@ProductPrice", inv("UnitRetail"))
            Cmd.Parameters.AddWithValue("@SalePrice", salePrice)
            Cmd.Parameters.AddWithValue("@SizeID", inv("SizeID"))
            Cmd.Parameters.AddWithValue("@ColorID", inv("ColorID"))
            Cmd.Parameters.AddWithValue("@CompanyID", inv("VendorID"))
            Cmd.Parameters.AddWithValue("@Tax", Tax)
            Cmd.Parameters.AddWithValue("@OuterItemNo", InnerItem)
            Cmd.Parameters.Add("@InnerItemNo", SqlDbType.VarChar, 50).Value = inv("ItemNo")
            recId = Convert.ToInt32(Cmd.ExecuteScalar())
        End Using

        Return recId
    End Function

    Private Function GenerateBarcodeImage(barcode As String) As Byte()
        Dim writer As New ZXing.BarcodeWriter()
        writer.Format = ZXing.BarcodeFormat.CODE_128

        Dim bmp = writer.Write(barcode)
        Using ms As New MemoryStream()
            bmp.Save(ms, Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function


    Private Sub PreviewLabel(recId As Integer, inv As DataRow, barcode As String, salePrice As Decimal)

        Dim ds As New Labels
        Dim row = ds.dtLabels.Rows.Add()

        row("recid") = recId
        row("PurchaseID") = recId
        row("Qty") = inv("Qty")
        row("Barcode") = barcode
        row("SalePrice") = salePrice
        row("ModelName") = inv("Description")
        row("SizeTitle") = inv("Size")
        row("ColorName") = inv("Color")
        row("CompanyName") = inv("Vendor")
        row("ItemNo") = inv("ItemNo")
        row("BarcodeImage") = GenerateBarcodeImage(barcode)

        'ds.dtLabels.AdddtLabelsRow(row)

        Dim rpt As New rpt2x1   ' Your Crystal Report
        rpt.SetDataSource(ds)
        'rpt.PrintOptions.PrinterName = "DYMO LabelWriter 4XL"
        'rpt.PrintToPrinter(CInt(inv("Qty")), False, 0, 0)
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub PrintLabel(recId As Integer, inv As DataRow, barcode As String, salePrice As Decimal)

        Dim ds As New Labels
        Dim row = ds.dtLabels.Rows.Add()

        row("recid") = recId
        row("PurchaseID") = recId
        row("Qty") = inv("Qty")
        row("Barcode") = barcode
        row("SalePrice") = salePrice
        row("ModelName") = inv("Description")
        row("SizeTitle") = inv("Size")
        row("ColorName") = inv("Color")
        row("CompanyName") = inv("Vendor")
        row("ItemNo") = inv("ItemNo")
        row("BarcodeImage") = GenerateBarcodeImage(barcode)

        'ds.dtLabels.AdddtLabelsRow(row)

        Dim rpt As New rpt2x1   ' Your Crystal Report
        rpt.SetDataSource(ds)
        rpt.PrintOptions.PrinterName = "DYMO LabelWriter 4XL"
        rpt.PrintToPrinter(CInt(inv("Qty")), False, 0, 0)
        'CrystalReportViewer1.ReportSource = rpt
        'CrystalReportViewer1.Refresh()

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim itemNo = txtItemNo.Text.Trim()
        Dim salePrice = Decimal.Parse(txtSalePrice.Text)
        Dim barcode = txtBarcode.Text.Trim()
        Dim Tax = Val(txtTax.Text)
        Dim InnerItemNo As String = txtInternalItem.Text

        Dim inv = GetInventoryItem(itemNo)

        If inv Is Nothing Then
            MessageBox.Show("No record found for Item# " & itemNo)
            Exit Sub
        End If

        Dim purchaseId = GetOrCreatePurchase(inv("LotNo").ToString(), inv("SupplierID"))

        Dim recId = InsertPurchaseDetails(purchaseId, inv, barcode, salePrice, Tax, InnerItemNo)

        PrintLabel(recId, inv, barcode, salePrice)

        MessageBox.Show("Record saved and label printed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub frmIndividulalPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub frmIndividulalPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConStr = Crypto.DecryptData(ConStr)
    End Sub

    Private Sub frmIndividualPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Allow the active control to process Enter if needed
            ' Do not suppress unless you want to prevent beep
            e.SuppressKeyPress = True

            ' Move to the next control
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub txtItemNo_Leave(sender As Object, e As EventArgs) Handles txtItemNo.Leave
        GetInventoryItem(txtItemNo.Text)
    End Sub


    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Dim itemNo = txtItemNo.Text.Trim()
        Dim salePrice = Decimal.Parse(txtSalePrice.Text)
        Dim barcode = txtBarcode.Text.Trim()
        Dim Tax = Val(txtTax.Text)
        Dim InnerItemNo As String = txtInternalItem.Text

        Dim inv = GetInventoryItem(itemNo)

        If inv Is Nothing Then
            MessageBox.Show("No record found for Item# " & itemNo)
            Exit Sub
        End If

        Dim purchaseId = GetOrCreatePurchase(inv("LotNo").ToString(), inv("SupplierID"))

        Dim recId = InsertPurchaseDetails(purchaseId, inv, barcode, salePrice, Tax, InnerItemNo)

        PreviewLabel(recId, inv, barcode, salePrice)

        MessageBox.Show("Record saved and label printed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmMain.Show()
        Me.Hide()
    End Sub

    Private Sub txtItemNo_TextChanged(sender As Object, e As EventArgs) Handles txtItemNo.TextChanged

    End Sub
End Class