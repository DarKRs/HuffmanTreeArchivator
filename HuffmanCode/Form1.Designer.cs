namespace HuffmanCode
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.loadFile = new System.Windows.Forms.OpenFileDialog();
            this.SourceText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EncodedText = new System.Windows.Forms.RichTextBox();
            this.Закодировать = new System.Windows.Forms.Button();
            this.v = new System.Windows.Forms.Button();
            this.ClearEncoded = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.CodeInFile = new System.Windows.Forms.Button();
            this.DecodeInFile = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.OpenEncodeText = new System.Windows.Forms.Button();
            this.loadfile2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть исходный текст";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadFile
            // 
            this.loadFile.FileName = "openFileDialog1";
            // 
            // SourceText
            // 
            this.SourceText.Location = new System.Drawing.Point(12, 82);
            this.SourceText.Name = "SourceText";
            this.SourceText.Size = new System.Drawing.Size(431, 326);
            this.SourceText.TabIndex = 1;
            this.SourceText.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Открытый файл(Исходный текст)";
            // 
            // EncodedText
            // 
            this.EncodedText.Location = new System.Drawing.Point(629, 82);
            this.EncodedText.Name = "EncodedText";
            this.EncodedText.Size = new System.Drawing.Size(431, 326);
            this.EncodedText.TabIndex = 3;
            this.EncodedText.Text = "";
            // 
            // Закодировать
            // 
            this.Закодировать.Location = new System.Drawing.Point(468, 82);
            this.Закодировать.Name = "Закодировать";
            this.Закодировать.Size = new System.Drawing.Size(133, 45);
            this.Закодировать.TabIndex = 4;
            this.Закодировать.Text = "Закодировать";
            this.Закодировать.UseVisualStyleBackColor = true;
            this.Закодировать.Click += new System.EventHandler(this.Закодировать_Click);
            // 
            // v
            // 
            this.v.Location = new System.Drawing.Point(12, 414);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(133, 45);
            this.v.TabIndex = 5;
            this.v.Text = "Очистить";
            this.v.UseVisualStyleBackColor = true;
            this.v.Click += new System.EventHandler(this.v_Click);
            // 
            // ClearEncoded
            // 
            this.ClearEncoded.Location = new System.Drawing.Point(947, 414);
            this.ClearEncoded.Name = "ClearEncoded";
            this.ClearEncoded.Size = new System.Drawing.Size(133, 45);
            this.ClearEncoded.TabIndex = 6;
            this.ClearEncoded.Text = "Очистить";
            this.ClearEncoded.UseVisualStyleBackColor = true;
            this.ClearEncoded.Click += new System.EventHandler(this.ClearEncoded_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(626, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Закодированный текст";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "Раскодировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CodeInFile
            // 
            this.CodeInFile.Location = new System.Drawing.Point(468, 158);
            this.CodeInFile.Name = "CodeInFile";
            this.CodeInFile.Size = new System.Drawing.Size(133, 45);
            this.CodeInFile.TabIndex = 9;
            this.CodeInFile.Text = "Закодировать в файл";
            this.CodeInFile.UseVisualStyleBackColor = true;
            this.CodeInFile.Click += new System.EventHandler(this.CodeInFile_Click);
            // 
            // DecodeInFile
            // 
            this.DecodeInFile.Location = new System.Drawing.Point(468, 302);
            this.DecodeInFile.Name = "DecodeInFile";
            this.DecodeInFile.Size = new System.Drawing.Size(133, 45);
            this.DecodeInFile.TabIndex = 10;
            this.DecodeInFile.Text = "Раскодировать в файл";
            this.DecodeInFile.UseVisualStyleBackColor = true;
            this.DecodeInFile.Click += new System.EventHandler(this.DecodeInFile_Click);
            // 
            // OpenEncodeText
            // 
            this.OpenEncodeText.Location = new System.Drawing.Point(859, 12);
            this.OpenEncodeText.Name = "OpenEncodeText";
            this.OpenEncodeText.Size = new System.Drawing.Size(201, 45);
            this.OpenEncodeText.TabIndex = 11;
            this.OpenEncodeText.Text = "Открыть закодированный текст";
            this.OpenEncodeText.UseVisualStyleBackColor = true;
            this.OpenEncodeText.Click += new System.EventHandler(this.button3_Click);
            // 
            // loadfile2
            // 
            this.loadfile2.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 483);
            this.Controls.Add(this.OpenEncodeText);
            this.Controls.Add(this.DecodeInFile);
            this.Controls.Add(this.CodeInFile);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClearEncoded);
            this.Controls.Add(this.v);
            this.Controls.Add(this.Закодировать);
            this.Controls.Add(this.EncodedText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceText);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog loadFile;
        private System.Windows.Forms.RichTextBox SourceText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox EncodedText;
        private System.Windows.Forms.Button Закодировать;
        private System.Windows.Forms.Button v;
        private System.Windows.Forms.Button ClearEncoded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CodeInFile;
        private System.Windows.Forms.Button DecodeInFile;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.Button OpenEncodeText;
        private System.Windows.Forms.OpenFileDialog loadfile2;
    }
}

