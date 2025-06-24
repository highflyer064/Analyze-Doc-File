namespace DocxReaderApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnChooseFile = new Button();
            btnGetText = new Button();
            lblFilePath = new Label();
            txtOutput = new RichTextBox();
            SuspendLayout();
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(0, 21);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(142, 23);
            btnChooseFile.TabIndex = 0;
            btnChooseFile.Text = "Choose .docx File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnGetText
            // 
            btnGetText.Location = new Point(637, 21);
            btnGetText.Name = "btnGetText";
            btnGetText.Size = new Size(138, 23);
            btnGetText.TabIndex = 1;
            btnGetText.Text = "Get Text";
            btnGetText.UseVisualStyleBackColor = true;
            btnGetText.Click += btnGetText_Click;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(186, 25);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(88, 15);
            lblFilePath.TabIndex = 2;
            lblFilePath.Text = "No file selected";
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.Location = new Point(0, 50);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(981, 505);
            txtOutput.TabIndex = 3;
            txtOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(981, 555);
            Controls.Add(txtOutput);
            Controls.Add(lblFilePath);
            Controls.Add(btnGetText);
            Controls.Add(btnChooseFile);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChooseFile;
        private Button btnGetText;
        private Label lblFilePath;
        private RichTextBox txtOutput;
    }
}
