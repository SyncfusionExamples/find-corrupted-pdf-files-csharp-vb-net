# Easy way to find the corrupted PDF files in C#

You might have a lot of PDF files in your disc or database; you need to find out the corrupted files and take necessary actions. But it is not possible for you to open every single file with a PDF reader to check whether it is corrupted or not. 

To save your effort and time, [Syncfusion&reg; PDF library](https://www.syncfusion.com/pdf-framework/net/pdf-library) provides you the support to identify the corrupted PDF files using C#, VB.NET by checking whether the PDF format syntax are proper. 

Let’s dive into the details about how to find the corrupted PDF files.

* [PdfDocumentAnalyzer](https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.Base~Syncfusion.Pdf.Parsing.PdfDocumentAnalyzer.html) class is used to find the corrupted PDF files by analyzing the PDF document structure and syntax. 
* [AnalyzeSyntax()](https://help.syncfusion.com/cr/cref_files/file-formats/Syncfusion.Pdf.Base~Syncfusion.Pdf.Parsing.PdfDocumentAnalyzer~AnalyzeSyntax.html) method of PdfDocumentAnalyzer class will invoke analysis of the PDF document structure and syntax and returns the result (an instance of [SyntaxAnalyzerResult](https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.Base~Syncfusion.Pdf.Parsing.SyntaxAnalyzerResult.html)).
* [IsCorrupted](https://help.syncfusion.com/cr/cref_files/file-formats/Syncfusion.Pdf.Base~Syncfusion.Pdf.Parsing.SyntaxAnalyzerResult~IsCorrupted.html) property of SyntaxAnalyzerResult is used to identify whether the processed PDF file is corrupted or not.

Using these APIs, you can ensure that the PDF document is not corrupted and then start processing it.

For example:

1. To avoid uploading corrupted any PDF report or resume to your web applications.
1. To avoid unexpected behavior or hanging when invoking PDF print programmatically.

The following code example will check whether the given PDF file is corrupted or not.

```C#
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
            using (FileStream pdfStream = new FileStream(“inputFile.pdf", FileMode.Open, FileAccess.Read))
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

```


