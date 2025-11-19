Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports ZXing
Imports ZXing.Common
Imports System.IO

Public Class frmMain
  <DllImport("user32.dll", CharSet:=CharSet.Auto)>
  Public Shared Function ReleaseCapture() As Boolean
  End Function

  <DllImport("user32.dll", CharSet:=CharSet.Auto)>
  Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
  End Function

  Private Const WM_NCLBUTTONDOWN As Integer = &HA1
  Private Const HT_CAPTION As Integer = &H2

  Dim Crypto As New Simple3Des("InnSole")
  Dim bCodeWritter As ZXing.BarcodeWriter

  Private Sub Form1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged
    lblTitle.Text = Me.Text
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.WindowState = FormWindowState.Minimized
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs)
    If Me.WindowState = FormWindowState.Maximized Then
      Me.WindowState = FormWindowState.Normal
    Else
      Me.WindowState = FormWindowState.Maximized
    End If
  End Sub

  Protected Overrides Sub OnResize(e As EventArgs)
    MyBase.OnResize(e)

  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Me.Close()
  End Sub

  Private Sub lblTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles lblTitle.MouseDown
    If e.Button = MouseButtons.Left Then
      ' Release the capture to start moving the form
      ReleaseCapture()
      ' Send the message to simulate a title bar drag
      SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
    End If
  End Sub

  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim rect = Screen.GetWorkingArea(Me)
    Me.MaximizedBounds = Screen.GetWorkingArea(Me)
    ConStr = Crypto.DecryptData(ConStr)
    grdMain.AutoGenerateColumns = False
    bCodeWritter = New BarcodeWriter() With {
        .Format = BarcodeFormat.CODE_128,
        .Options = New EncodingOptions() With {
            .Height = 400,
            .Width = 800,
            .PureBarcode = False,
            .Margin = 10
        }
    }
    ComboBox1.SelectedIndex = 0
    Clipboard.SetText(Crypto.EncryptData("Server=.;Database=Dealzport;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;User ID=sa; Password=sysAdmin"))
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Using Con As New SqlConnection(ConStr)
                Using Cmd = Con.CreateCommand()
                    Cmd.CommandText = "spGetDataForLabels"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@PurchaseID", Val(TextBox1.Text.Trim))
                    Dim dAdapter As New SqlDataAdapter(Cmd)
                    Dim dTable As New DataTable
                    dAdapter.Fill(dTable)
                    If grdMain.Columns(0).Name <> "checkBoxColumn" Then
                        Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()

                        checkBoxColumn.HeaderText = ""
                        checkBoxColumn.Width = 40
                        checkBoxColumn.Name = "checkBoxColumn"
                        dTable.Columns.Remove("BarcodeImage")

                        dTable.Columns.Add("BarcodeImage", GetType(Byte()))

                        grdMain.DataSource = dTable
                        grdMain.Columns.Insert(0, checkBoxColumn)
                    End If

                    For Each row As DataGridViewRow In grdMain.Rows
                        row.Cells("checkBoxColumn").Value = True
                    Next

                    For Each row As DataRow In dTable.Rows
                        Dim text As String = row("Barcode").ToString() ' Replace with the column name containing the text
                        row("BarcodeImage") = GenerateBarcodeImage(text)
                    Next
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Alert...")
        End Try

  End Sub


  Private Function GenerateBarcodeImage(text As String) As Byte()
    ' Assuming this function returns a byte array of the barcode image
    Using bitmap = bCodeWritter.Write(text)
      Using ms As New MemoryStream()
        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
        Return ms.ToArray()
      End Using
    End Using
  End Function

  Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
    If e.KeyValue = Keys.Enter Then
      Button5.PerformClick()
    End If
  End Sub

  Private Sub btnCheckUnCheck_Click(sender As Object, e As EventArgs) Handles btnCheckUnCheck.Click
    For Each row As DataGridViewRow In grdMain.Rows
      ' Get the checkbox cell in the first column
      Dim chkCell As DataGridViewCheckBoxCell = CType(row.Cells(0), DataGridViewCheckBoxCell)

      ' Check if the checkbox is checked
      If Convert.ToBoolean(chkCell.Value) = True Then
        ' Uncheck the checkbox
        chkCell.Value = False
      Else
        chkCell.Value = True
      End If
    Next

  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    If grdMain.Rows.Count() = 0 Then
      MsgBox("Please fetch the data first then try again with some rows selected.", vbOKOnly + MsgBoxStyle.Exclamation, "Alert...")
      TextBox1.Focus()
      Exit Sub
    End If


    Dim IsSelected As Boolean = False
    For Each row As DataGridViewRow In grdMain.Rows
      Dim chkCell As DataGridViewCheckBoxCell = CType(row.Cells(0), DataGridViewCheckBoxCell)

      ' Check if the checkbox is checked
      If Convert.ToBoolean(chkCell.Value) = True Then
        IsSelected = True
        Exit For
      End If
    Next

    If Not IsSelected Then
      MsgBox("Please fetch the data first then try again with some rows selected.", vbOKOnly + MsgBoxStyle.Exclamation, "Alert...")
      TextBox1.Focus()
      Exit Sub
    End If

    If ComboBox1.SelectedIndex = -1 Then
      MsgBox("Please select a label type to continue.", vbOKOnly + MsgBoxStyle.Exclamation, "Alert...")
      ComboBox1.Focus()
      Exit Sub
    End If

    Select Case ComboBox1.SelectedIndex
      Case 0  ' 3x2
                Generate2x1Report()
      Case 1  '2x1
                GenerateReport()
    End Select


  End Sub

  Private Function GetSelectedRows() As DataTable
    Dim originalTable As DataTable = CType(grdMain.DataSource, DataTable)
    Dim selectedData As DataTable = originalTable.Clone() ' Clone the structure of the original DataTable

    For Each row As DataGridViewRow In grdMain.Rows
      Dim chk As DataGridViewCheckBoxCell = CType(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell)
      If chk.Value IsNot Nothing AndAlso CType(chk.Value, Boolean) = True Then
        Dim dataRow As DataRow = CType(row.DataBoundItem, DataRowView).Row
        selectedData.ImportRow(dataRow) ' Import the selected row
      End If
    Next

    Return selectedData
  End Function

  Private Sub GenerateReport()
    Dim selectedData As DataTable = GetSelectedRows() ' Get the selected rows

    If selectedData.Rows.Count = 0 Then
      MessageBox.Show("No rows selected!")
      Return
    End If

    Dim reportDataSet As DataSet = LoadDataIntoDataSet(selectedData) ' Load selected rows into dataset

    ' Create and configure the Crystal Report
    Dim report As New rpt3x2Labels ' Replace with your report class name
    report.SetDataSource(reportDataSet)

    ' Show the report in a Crystal Report Viewer
    CrystalReportViewer1.ReportSource = report
    CrystalReportViewer1.Refresh()
  End Sub


  Private Sub Generate2x1Report()
    Dim selectedData As DataTable = GetSelectedRows() ' Get the selected rows

    If selectedData.Rows.Count = 0 Then
      MessageBox.Show("No rows selected!")
      Return
    End If

    Dim reportDataSet As DataSet = LoadDataIntoDataSet(selectedData) ' Load selected rows into dataset

    ' Create and configure the Crystal Report
        Dim report As New rpt2x1Labels ' Replace with your report class name
    report.SetDataSource(reportDataSet)

    ' Show the report in a Crystal Report Viewer
    CrystalReportViewer1.ReportSource = report
    CrystalReportViewer1.Refresh()
  End Sub


  Private Function LoadDataIntoDataSet(selectedData As DataTable) As DataSet
        Dim ds As New Labels ' Replace with the name of your dataset
        Dim temp As New DataTable
        For Each col As DataColumn In ds.Tables(0).Columns
            temp.Columns.Add(col.ColumnName, col.DataType)
        Next

        ' Copy and convert rows

        For Each row As DataRow In selectedData.Rows
            Dim newRow As DataRow = temp.NewRow()
            For Each col As DataColumn In temp.Columns
                If row.Table.Columns.Contains(col.ColumnName) Then
                    Dim value = row(col.ColumnName)
                    If value IsNot DBNull.Value Then
                        ' Convert the value to the target column type
                        newRow(col.ColumnName) = Convert.ChangeType(value, col.DataType)
                    End If
                End If
            Next
            temp.Rows.Add(newRow)
        Next

        ' Merge safely
        ds.Tables(0).Merge(temp)
        'ds.Tables(0).Merge(selectedData) ' Merge the selected data into the dataset table
    Return ds
  End Function


  Private Sub btnIndImport_Click(sender As Object, e As EventArgs) Handles btnIndImport.Click
    Me.Hide()
    frmIndividulalPrint.Show()
  End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub
End Class
