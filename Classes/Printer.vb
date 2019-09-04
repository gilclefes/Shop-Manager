Namespace My
    ''' <summary>
    ''' Represents the lost VB6 functionality of a Printer object
    ''' </summary>
    ''' <remarks>Usage: My.Printer.Print(text)</remarks>
    Public Class Printer
        Private Shared Lines As New Queue(Of String)
        Private Shared _myfont As Font
        Private Shared prn As Printing.PrintDocument

        Shared Sub New()
            _myfont = New Font(SystemFonts.DefaultFont.FontFamily, 0.12, FontStyle.Regular, GraphicsUnit.Inch)
            prn = New Printing.PrintDocument
            AddHandler prn.PrintPage, AddressOf PrintPageHandler
        End Sub

        Public Shared Sub Print(ByVal text As String)
            Dim linesarray() = text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

            For Each line As String In linesarray
                Lines.Enqueue(line)

            Next
            prn.Print()
        End Sub

        Private Shared Sub PrintPageHandler(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
            Dim sf As New StringFormat()
            Dim vpos As Single = e.PageSettings.HardMarginY

            Do While Lines.Count > 0
                Dim line As String = Lines.Dequeue
                Dim sz As SizeF = e.Graphics.MeasureString(line, _myfont, e.PageSettings.Bounds.Size, sf)

                Dim rct As New RectangleF( _
                     e.PageSettings.HardMarginX, vpos, _
                     e.PageBounds.Width - e.PageSettings.HardMarginX * 2, _
                     e.PageBounds.Height - e.PageSettings.HardMarginY * 2)

                e.Graphics.DrawString(line, _myfont, Brushes.Black, rct)
                vpos += sz.Height
                If vpos > e.PageSettings.Bounds.Height - e.PageSettings.HardMarginY * 2 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            Loop
        End Sub
    End Class
End Namespace
