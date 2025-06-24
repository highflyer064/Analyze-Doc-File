using System;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DocxReaderApp
{
    public partial class Form1 : Form
    {
        private string selectedFilePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Word Documents (*.docx) | *.docx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    lblFilePath.Text = selectedFilePath;
                }
            }
        }

        private void btnGetText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please choose a .docx file first .");
                return;
            }

            DisplayFormattedText(selectedFilePath);
        }

        private string ExtractTextFromDocx(string filePath)
        {
            try
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
                {
                    Body body = wordDoc.MainDocumentPart.Document.Body;
                    return body.InnerText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file : " + ex.Message);
                return "";
            }
        }

        private void DisplayFormattedText(string filePath)
        {
            txtOutput.Clear();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                Body body = wordDoc.MainDocumentPart.Document.Body;

                foreach (Paragraph paragraph in body.Elements<Paragraph>())
                {
                    string styleId = GetParagraphStyleId(paragraph);

                    foreach (Run run in paragraph.Elements<Run>())
                    {
                        string text = run.InnerText;
                        if (string.IsNullOrWhiteSpace(text)) continue;

                        //Check for formatting
                        bool isBold = run.RunProperties?.Bold != null;
                        bool isItalic = run.RunProperties?.Italic != null;
                        bool isUnderline = run.RunProperties?.Underline != null;

                        txtOutput.SelectionFont = new System.Drawing.Font(
                            styleId.StartsWith("Heading") ? "Segoe UI" : "Segoe UI",
                            styleId.StartsWith("Heading") ? 14 : 10,
                            (isBold ? FontStyle.Bold : FontStyle.Regular) |
                            (isItalic ? FontStyle.Italic : 0) |
                            (isUnderline ? FontStyle.Underline : 0)
                        );

                        txtOutput.AppendText(text);
                    }

                    // Add a newline after each pagragraph
                    txtOutput.AppendText(Environment.NewLine);
                }
            }
        }

        private string GetParagraphStyleId(Paragraph paragraph)
        {
            var pPr = paragraph.Elements<ParagraphProperties>().FirstOrDefault();
            var pStyle = pPr?.ParagraphStyleId;
            return pStyle?.Val?.Value ?? "";
        }
    }
}
