using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.IO;
using System.Text;

namespace find_corrupted_pdf_file_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF file as stream
using (FileStream pdfStream = new FileStream(@"..\..\..\PDF-Files\input-open-repair.pdf", FileMode.Open, FileAccess.Read))
{
    //Create a new instance of PDF document syntax analyzer.
    PdfDocumentAnalyzer analyzer = new PdfDocumentAnalyzer(pdfStream);
    //Analyze the syntax and return the results
    SyntaxAnalyzerResult analyzerResult = analyzer.AnalyzeSyntax();

    //Check whether the document is corrupted or not
    if (analyzerResult.IsCorrupted)
    {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine("The PDF document is corrupted.");
        int count = 1;
        foreach (PdfException exception in analyzerResult.Errors)
        {
            strBuilder.AppendLine(count++.ToString() + ": " + exception.Message);
        }
        Console.WriteLine(strBuilder);
    }
    else
    {
        Console.WriteLine("No syntax error found in the provided PDF document");
    }
    analyzer.Close();
}   
        }
    }
}
