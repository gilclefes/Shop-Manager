Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class PrintSaleRecipt
    Implements IDisposable
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)


    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub Export(ByVal report As LocalReport)
        Const deviceInfo As String = "<DeviceInfo>" & _
                                     "<OutputFormat>EMF</OutputFormat>" & _
                                     "<PageWidth>3.0in</PageWidth>" & _
                                     "<PageHeight>8.0in</PageHeight>" & _
                                     "<MarginTop>0.15in</MarginTop>" & _
                                     "<MarginLeft>0.15in</MarginLeft>" & _
                                     "<MarginRight>0.15in</MarginRight>" & _
                                     "<MarginBottom>0.15in</MarginBottom>" & _
                                     "</DeviceInfo>"
        Dim warnings As Warning()
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                          ev.PageBounds.Width, _
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        Dim printDoc As New PrintDocument()
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: cannot find the default printer.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            Dim pkCustomSize1 As New PaperSize("First custom size", 350, 700)
            printDoc.DefaultPageSettings.PaperSize = pkCustomSize1
            printDoc.PrintController = New StandardPrintController()
            printDoc.Print()
        End If
    End Sub

    ' Create a local report for Report.rdlc, load the data,
    ' export the report to an .emf file, and print it.
    Public Sub Run(ByVal user As String, ByVal customerName As String, ByVal salesDate As String, ByVal totalcost As Decimal, ByVal totalpaid As Decimal, ByVal data As DataTable)
        Dim report As New LocalReport()
        report.ReportPath = Application.StartupPath & "\Reports\SaleReceipt.rdlc" ' "..\..\Report.rdlc"
        report.DataSources.Add(New ReportDataSource("DataSet1", data))

        Dim rUser As New ReportParameter("user", user)

        Dim cName As New ReportParameter("customername", customerName)
        Dim sDate As New ReportParameter("salesdate", salesDate)
        Dim tcost As New ReportParameter("totalcost", totalcost.ToString("N1"))
        Dim tecost As New ReportParameter("totalextracost", 0.ToString("N1"))
        Dim tpaid As New ReportParameter("totalpaid", totalpaid.ToString("N1"))
        Dim bal As New ReportParameter("balance", (CDec(totalpaid) - CDec(totalcost)).ToString("N1"))

        ' Dim parameters As ReportParameterCollection = {rUser, sDate, cName, tcost, tecost, tpaid, bal}
        report.SetParameters(rUser)
        report.SetParameters(cName)
        report.SetParameters(sDate)
        report.SetParameters(tcost)
        report.SetParameters(tecost)
        report.SetParameters(tpaid)
        report.SetParameters(bal)

        report.Refresh()

        Export(report)
        Print()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub

    'Public Shared Sub Main(ByVal args As String())
    '    Using demo As New Demo()
    '        demo.Run()
    '    End Using
    'End Sub
End Class