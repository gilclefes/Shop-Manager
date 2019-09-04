Option Strict Off
Imports System.IO
Imports System.Text
Imports System.Net
Imports Microsoft.Office.Interop

Public Class Utils

    Public Shared Function loadpic(ByVal arrpicture() As Byte) As MemoryStream
        Dim ms As New MemoryStream(arrpicture)

        Return ms
    End Function

    Public Shared Function savepic(ByVal pic1 As PictureBox) As Byte()
        Dim arrImage() As Byte = Nothing

        If pic1.Image Is Nothing Then
            pic1.Image = pic1.ErrorImage
        End If

        Dim ms As New MemoryStream
        pic1.Image.Save(ms, pic1.Image.RawFormat)
        arrImage = ms.GetBuffer
        ms.Close()

        Return arrImage

    End Function

    Public Shared Function deletePrompt() As DialogResult
        Dim result As DialogResult
        result = MsgBox("Are You Sure To Delete Record", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "DeletionPrompt")
        Return result
    End Function

    Public Shared Function UpdatePrompt() As DialogResult
        Dim result As DialogResult
        result = MsgBox("Are You Sure To Update Record", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Update Prompt")
        Return result
    End Function

    Public Shared Function AddPrompt() As DialogResult
        Dim result As DialogResult
        result = MsgBox("Are You Sure To " & vbCrLf & "Add New Record", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Add Prompt")
        Return result
    End Function

    Public Shared Function QuestionPrompt(ByVal question As String) As DialogResult
        Dim result As DialogResult
        result = MsgBox(question, MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Cancel Prompt")
        Return result
    End Function

    Public Shared Function CancelPrompt() As DialogResult
        Dim result As DialogResult
        result = MsgBox("Are You Sure To " & vbCrLf & "Cancel Current Operation", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Cancel Prompt")
        Return result
    End Function

    Public Shared Function ClosingPrompt() As DialogResult
        Dim result As DialogResult
        result = MsgBox("Are You Sure To Close this Form", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "From Closing Prompt")
        Return result
    End Function

    Public Shared Sub UpdateMessage()
        MsgBox("Succesful Update Of Record(s)", MsgBoxStyle.Information, "Successfull Updates")
    End Sub

    Public Shared Sub AddedMessage()
        MsgBox(" Record Added Successfully", MsgBoxStyle.Information, "Successfull Addition")
    End Sub

    Public Shared Sub DeletedMessage()
        MsgBox(" Record Deleted Successfully", MsgBoxStyle.Information, "Successfull Deletion")
    End Sub

    Public Shared Sub showError(ByVal message As String)
        MsgBox(message, MsgBoxStyle.Critical, "SHOP MANAGER Error Message")
    End Sub

    Public Shared Sub showMessage(ByVal message As String)
        MsgBox(message, MsgBoxStyle.Information, "SHOP MANAGER  Message")
    End Sub

    Public Shared Sub showException(ByVal ex As Exception)
        MsgBox(ex.ToString, MsgBoxStyle.Information, "SHOP MANAGER  Message")
    End Sub

    Public Shared Sub numerickey(ByVal txt1 As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)

        Select Case KeyAscii

            Case 48 To 57, 8, 13      ' these are the digits 0-9, backspace, 
                ' and carriage return
                ' we're OK on these, don't do anything

            Case 45                   ' minus sign

                ' The number can only have one minus sign, so 
                ' if we already have one, throw this one away
                If InStr(txt1.Text, "-") <> 0 Then
                    KeyAscii = 0
                End If

                ' if the insertion point is not sitting at zero
                ' (which is the beginning of the field), throw away the minus
                ' sign (because it's not valid except in first position)
                If txt1.SelectionStart <> 0 Then
                    KeyAscii = 0
                End If

            Case 46                   ' this is a period (decimal point)

                ' if we already have a period, throw it away
                If InStr(txt1.Text, ".") <> 0 Then
                    KeyAscii = 0
                End If

            Case Else
                ' provide no handling for the other keys
                KeyAscii = 0

        End Select

        ' If we want to throw the keystroke away, then set the event
        ' as already handled. Otherwise, let the keystroke be handled normally.
        If KeyAscii = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Public Shared Function getpicturefromfile() As String
        Dim file As String = ""
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Images|*.jpg;*gif;*.bmp"

        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            file = ofd.FileName
            Return file
        Else
            file = ""
        End If
        'Dim im As New Bitmap()
        Return file
    End Function

    Public Shared Function getClientName() As String
        Dim client As String = ""
        client = Dns.GetHostName
        Return client
    End Function

    Public Shared Function ValidateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)
        Return emailMatch.Success
    End Function

    Public Shared Function encrypt(ByVal password As String) As Byte()
        'Dim sha1CryptoService As SHA1CryptoServiceProvider = New SHA1CryptoServiceProvider()
        Dim byteValue() As Byte = Encoding.UTF8.GetBytes(password)
        'Dim hashValue() As Byte = sha1CryptoService.ComputeHash(byteValue)
        Return byteValue
    End Function

    Public Shared Function decrypt(ByVal pass As Byte()) As String
        Dim password As String = Encoding.UTF8.GetString(pass)
        Return password
    End Function

    Public Shared Function returnCellName(ByVal number As Integer) As String
        Dim value As Char
        Dim cellname As String = ""
        If number > 26 And number <= 52 Then
            cellname = "A"
            number = number - 26
        ElseIf number > 52 Then
            cellname = "B"
            number = number - 52
        End If

        number = 65 + number - 1

        value = Chr(number)
        cellname = cellname & value
        Return cellname
    End Function

    Public Shared Function ValueExist(ByVal dgrd As DataGridView, ByVal col As Integer, ByVal value As String) As Boolean
        Dim counter As Integer = 0
        For i As Integer = 0 To dgrd.RowCount - 1

            If String.Compare(dgrd.Rows(i).Cells(col).Value, value, True) = 0 Then
                counter = counter + 1
            End If
        Next
        If counter > 1 Then
            Return True
        End If
        Return False
    End Function

    Public Shared Sub ExportToExcel(ByVal title As String, ByVal dt As DataTable)
        Try


            Dim oExcel As New Excel.Application()
            Dim oWorkBook As Excel.Workbook = oExcel.Workbooks.Add()
            Dim oWorkSheet As New Excel.Worksheet
            oWorkSheet = oWorkBook.Worksheets(1)

            oExcel.Visible = True
            oWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            oWorkSheet.Range("B2").Value = "PLEASE WAIT..."

            Dim initValues(dt.Rows.Count, dt.Columns.Count) As String
            For r As Integer = 0 To dt.Rows.Count - 1
                For c As Integer = 0 To dt.Columns.Count - 1
                    If Not IsDBNull(dt.Rows(r)(c)) Then
                        initValues(r, c) = dt.Rows(r)(c)
                    End If
                Next
            Next

            oWorkSheet.Range("B2").Value = title
            oWorkSheet.Range("B2").Font.Bold = True
            oWorkSheet.Range("B2").Font.Underline = True
            oWorkSheet.Range("B2").Font.Size = 16
            oWorkSheet.Range("B3").Resize(1, dt.Columns.Count).Font.Bold = True
            oWorkSheet.Range("B3").Resize(dt.Rows.Count, dt.Columns.Count).Value = initValues


            oWorkSheet.PageSetup.RightFooter = "eSHOPPER "
            oWorkSheet.PageSetup.RightFooter = "eSHOPPER "


            oExcel.Visible = True
            oExcel = Nothing
            oWorkBook = Nothing
            oWorkSheet = Nothing
        Catch ex As Exception
            showError(ex.ToString)
        End Try

    End Sub

    Public Shared Function ValueExist_New(ByVal dgrd As DataGridView, ByVal col As Integer, ByVal value As String) As Boolean

        If dgrd.RowCount <= 0 Then
            Return False
        End If

        Dim counter As Integer = 0


        For i As Integer = 0 To dgrd.RowCount - 1

            If String.Compare(dgrd.Rows(i).Cells(col).Value, value, True) = 0 Then
                counter = counter + 1
            End If
        Next

        If counter > 1 Then
            Return True
        End If

        Return False
    End Function

End Class
