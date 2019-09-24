Imports System
Imports System.IO
Imports System.Text
Imports Syncfusion.Pdf
Imports Syncfusion.Pdf.Parsing

Module Program
    Sub Main(args As String())
        Using pdfStream As FileStream = New FileStream("..\..\..\Data\input.pdf", FileMode.Open, FileAccess.Read)
            'load the corrupted document by setting the openAndRepair flag as true to repair the document
            Dim loadedPdfDocument As PdfLoadedDocument = New PdfLoadedDocument(pdfStream, True)

            'Do PDF processing

            'Save the document.
            Using outputStream As FileStream = New FileStream("result.pdf", FileMode.Create)

                loadedPdfDocument.Save(outputStream)
            End Using
            'Close the document
            loadedPdfDocument.Close(True)
        End Using
    End Sub
End Module
