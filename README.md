# How to find the corrupted PDF files using Syncfusion PDF Library

Syncfusion PDF Library provides support to find the existing PDF document corruptions and provides the corruption details

## Finding the corrupted PDF document

Install the [Syncfusion.Pdf.Net.Core](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) NuGet package as a reference to your .NET Core applications from [NuGet.org](https://www.nuget.org/).

The following namespace should be included in the application:

```C#
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
```


The following code snippet explains how to find the corrupted PDF document.

```C#
using (FileStream pdfStream = new FileStream(@"..\..\..\PDF-Files\barcode.pdf", FileMode.Open, FileAccess.Read))
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
```