Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public NotInheritable Class Simple3Des
  Private ReadOnly TripleDes As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

  Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
    Using sha1 As SHA1CryptoServiceProvider = New SHA1CryptoServiceProvider()
      Dim keyBytes As Byte() = Encoding.Unicode.GetBytes(key)
      Dim hash As Byte() = sha1.ComputeHash(keyBytes)
      Array.Resize(hash, length)
      Return hash
    End Using
  End Function

  Public Sub New(ByVal key As String)
    Try
      TripleDes.Key = TruncateHash(key, TripleDes.KeySize / 8)
      TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8)
    Catch ex As Exception
      Console.WriteLine(ex.Message)
    End Try
  End Sub

  Public Sub New()
    Try
      TripleDes.Key = TruncateHash("Shayan", TripleDes.KeySize / 8)
      TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8)
    Catch ex As Exception
      Console.WriteLine(ex.Message)
    End Try
  End Sub

  Public Function EncryptData(ByVal plaintext As String) As String
    If String.IsNullOrEmpty(plaintext) Then Return ""
    Dim plaintextBytes As Byte() = Encoding.Unicode.GetBytes(plaintext)

    Using ms As MemoryStream = New MemoryStream()

      Using encStream As CryptoStream = New CryptoStream(ms, TripleDes.CreateEncryptor(), CryptoStreamMode.Write)
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()
        Return Convert.ToBase64String(ms.ToArray())
      End Using
    End Using
  End Function

  Public Function DecryptData(ByVal encryptedtext As String) As String
    If String.IsNullOrEmpty(encryptedtext) Then Return ""
    Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedtext)

    Using ms As MemoryStream = New MemoryStream()

      Using decStream As CryptoStream = New CryptoStream(ms, TripleDes.CreateDecryptor(), CryptoStreamMode.Write)
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)

        Try
          decStream.FlushFinalBlock()
        Catch ex As Exception
          Console.WriteLine(ex.Message)
          Return String.Empty
        End Try

        Return Encoding.Unicode.GetString(ms.ToArray())
      End Using
    End Using
  End Function

  Public Function DecryptDataTest(ByVal encryptedtext As String) As String
    If String.IsNullOrEmpty(encryptedtext) Then Return ""
    Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedtext)

    Using ms As MemoryStream = New MemoryStream()

      Using decStream As CryptoStream = New CryptoStream(ms, TripleDes.CreateDecryptor(), CryptoStreamMode.Write)
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()
        Return Encoding.Unicode.GetString(ms.ToArray())
      End Using
    End Using
  End Function
End Class
