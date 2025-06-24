using Microsoft.Office.Interop.Word;
using System;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using Word = Microsoft.Office.Interop.Word;

class Program
{
    static void Main()
    {
        Word.Application word = new Word.Application();
        Word.Document doc = null;

        try
        {
            object filePath = @"E:\11.doc";
            object readOnly = true;
            object missing = System.Reflection.Missing.Value;

            doc = word.Documents.Open(ref filePath, ReadOnly: ref readOnly, Visible: false);
            string text = doc.Content.Text;
            Console.WriteLine(text);
        }
        finally
        {
            if (doc != null) doc.Close();
            word.Quit();
        }
    }
}
