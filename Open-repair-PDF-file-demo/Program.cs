using System;
using System.IO;
using Syncfusion.Pdf.Parsing;

namespace Open_repair_PDF_file_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream pdfStream = new FileStream(@"..\..\..\Data\input.pdf", FileMode.Open, FileAccess.Read))
            {
                //load the corrupted document by setting the openAndRepair flag as true to repair the document
                PdfLoadedDocument loadedPdfDocument = new PdfLoadedDocument(pdfStream, true);

                //Do PDF processing

                //Save the document.
                using (FileStream outputStream = new FileStream(@"result.pdf", FileMode.Create))
                {
                    loadedPdfDocument.Save(outputStream);
                }
                //Close the document
                loadedPdfDocument.Close(true);
            }
        }
    }
}
