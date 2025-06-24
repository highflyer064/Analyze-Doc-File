using System;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

class Program
{
    static void Main()
    {
        string filepath = @"E:\1.docx";

        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filepath, false))
        {
            Body body = wordDoc.MainDocumentPart.Document.Body;
            string text = body.InnerText;

            Console.WriteLine("==========Document Text===========");
            Console.WriteLine(text);
        }
    }
}