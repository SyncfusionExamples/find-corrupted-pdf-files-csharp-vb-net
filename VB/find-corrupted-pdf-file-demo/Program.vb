Imports System
Imports System.IO
Imports System.Text
Imports Syncfusion.Pdf
Imports Syncfusion.Pdf.Parsing

Module Program
    Sub Main(args As String())
        'Load the PDF file as stream
        Using pdfStream As FileStream = New FileStream("..\..\..\PDF-Files\input-open-repair.pdf", FileMode.Open, FileAccess.Read)
            'Create a new instance of PDF document syntax analyzer.
            Dim analyzer As PdfDocumentAnalyzer = New PdfDocumentAnalyzer(pdfStream)
            'Analyze the syntax and return the results
            Dim analyzerResult As SyntaxAnalyzerResult = analyzer.AnalyzeSyntax()

            'Check whether the document is corrupted or not
            If analyzerResult.IsCorrupted Then
                Dim strBuilder As StringBuilder = New StringBuilder()
                strBuilder.AppendLine("The PDF document is corrupted.")
                Dim count As Integer = 1
                For Each exception As PdfException In analyzerResult.Errors
                    strBuilder.AppendLine(count.ToString + ": " + exception.Message)
                    count = count + 1
                Next
                Console.WriteLine(strBuilder)
            Else
                Console.WriteLine("No syntax error found in the provided PDF document")
            End If
            analyzer.Close()
        End Using

    End Sub
End Module
