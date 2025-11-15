Imports System.Data.SqlClient
Imports System.IO

Public Class frmIndividulalPrint


  Private Function GetInventoryItem(itemNo As String) As DataRow
    Dim dt As New DataTable

    Using con As New SqlConnection(ConStr)
      con.Open()
      Dim cmd As New SqlCommand("SELECT TOP 1 ii.*, ISNULL(ts.title, 'N/A') [Size], ISNULL(ts.title, 'N/A') [Color] FROM InventoryItems ii LEFT OUTER JOIN tblSizes ts ON ii.SizeID = ts.id LEFT OUTER JOIN tblColors tc ON ii.ColorID = ts.id WHERE ItemNo = @ItemNo", con)
      cmd.Parameters.AddWithValue("@ItemNo", itemNo)

      Dim da As New SqlDataAdapter(cmd)
      da.Fill(dt)
      If dt.Rows.Count = 0 Then
        lblProductName.Text = "No record found..."
        lblVendor.Text = "No record found..."
        lblPurchasePrice.Text = ""
        lblDisplayPrice.Text = ""
        lblQuantity.Text = ""
        Return Nothing
      End If
      lblQuantity.Text = dt(0)("Qty").ToString()
      lblPurchasePrice.Text = dt(0)("PurchasePrice").ToString()
      lblDisplayPrice.Text = dt(0)("UnitRetail").ToString()
      lblProductName.Text = dt(0)("Description").ToString()
      lblVendor.Text = dt(0)("Vendor").ToString()

    End Using


    Return dt.Rows(0)
  End Function

  Private Function GetOrCreatePurchase(lotNo As String, supplierId As Integer) As Integer
    Dim purchaseId As Integer = 0

    Using con As New SqlConnection(ConStr)
      con.Open()

      ' Check existing purchase
      Dim checkCmd As New SqlCommand("SELECT TOP 1 ID FROM tblPurchases WHERE LotNo = @LotNo", con)
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


  Private Function InsertPurchaseDetails(purchaseId As Integer, inv As DataRow, barcode As String, salePrice As Decimal) As Integer
    Dim recId As Integer = 0

    Using con As New SqlConnection(ConStr)
      con.Open()

      Dim cmd As New SqlCommand("INSERT INTO tblPurchaseDetails (PurchaseID, product_id, Barcode, Quantity, purchasePrice, productPrice, SalePrice, SalePercentage, SizeID, ColorID, CompanyID, Tax) VALUES(@PurchaseID, @ProductID, @Barcode, @Qty, @PurchasePrice, @ProductPrice, @SalePrice, 0, @SizeID, @ColorID, @CompanyID, @Tax); SELECT SCOPE_IDENTITY();", con)

      cmd.Parameters.AddWithValue("@PurchaseID", purchaseId)
      cmd.Parameters.AddWithValue("@ProductID", inv("ProductID"))
      cmd.Parameters.AddWithValue("@Barcode", barcode)
      cmd.Parameters.AddWithValue("@Qty", inv("Qty"))
      cmd.Parameters.AddWithValue("@PurchasePrice", inv("PurchasePrice"))
      cmd.Parameters.AddWithValue("@ProductPrice", inv("UnitRetail"))
      cmd.Parameters.AddWithValue("@SalePrice", salePrice)
      cmd.Parameters.AddWithValue("@SizeID", inv("SizeID"))
      cmd.Parameters.AddWithValue("@ColorID", inv("ColorID"))
      cmd.Parameters.AddWithValue("@CompanyID", inv("VendorID"))
      cmd.Parameters.AddWithValue("@Tax", "0")

      recId = Convert.ToInt32(cmd.ExecuteScalar())
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
    row("BarcodeImage") = GenerateBarcodeImage(barcode)

    'ds.dtLabels.AdddtLabelsRow(row)

    Dim rpt As New rpt2x1Labels   ' Your Crystal Report
    rpt.SetDataSource(ds)
    ''rpt.PrintToPrinter(inv("Qty"), False, 0, 0)
    CrystalReportViewer1.ReportSource = rpt
    CrystalReportViewer1.Refresh()

  End Sub



  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    Dim itemNo = txtItemNo.Text.Trim()
    Dim salePrice = Decimal.Parse(txtSalePrice.Text)
    Dim barcode = txtBarcode.Text.Trim()

    Dim inv = GetInventoryItem(itemNo)

    If inv Is Nothing Then
      MessageBox.Show("No record found for Item# " & itemNo)
      Exit Sub
    End If

    Dim purchaseId = GetOrCreatePurchase(inv("LotNo").ToString(), inv("SupplierID"))

    Dim recId = InsertPurchaseDetails(purchaseId, inv, barcode, salePrice)

    PrintLabel(recId, inv, barcode, salePrice)

    MessageBox.Show("Record saved and label printed.")
  End Sub


  Private Sub txtItemNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItemNo.KeyPress
    If e.KeyChar = Chr(13) Or e.KeyChar = Chr(10) Then
      GetInventoryItem(txtItemNo.Text)
    End If
  End Sub

  Private Sub frmIndividulalPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    End
  End Sub
End Class