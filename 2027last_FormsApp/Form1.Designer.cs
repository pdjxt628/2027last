namespace _2027last_FormsApp
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
            Inputbutton = new Button();
            DelateButton = new Button();
            textBox1 = new TextBox();
            Memo = new DataGridView();
            LoadButton = new Button();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Memo).BeginInit();
            SuspendLayout();
            // 
            // Inputbutton
            // 
            Inputbutton.Location = new Point(110, 359);
            Inputbutton.Name = "Inputbutton";
            Inputbutton.Size = new Size(126, 46);
            Inputbutton.TabIndex = 0;
            Inputbutton.Text = "送信";
            Inputbutton.UseVisualStyleBackColor = true;
            Inputbutton.Click += Inputbutton_Click;
            // 
            // DelateButton
            // 
            DelateButton.Location = new Point(307, 359);
            DelateButton.Name = "DelateButton";
            DelateButton.Size = new Size(126, 46);
            DelateButton.TabIndex = 1;
            DelateButton.Text = "削除";
            DelateButton.UseVisualStyleBackColor = true;
            DelateButton.Click += DelateButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(207, 300);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 44);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Memo
            // 
            Memo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Memo.Location = new Point(73, 36);
            Memo.Name = "Memo";
            Memo.Size = new Size(402, 246);
            Memo.TabIndex = 3;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(216, 411);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(108, 34);
            LoadButton.TabIndex = 4;
            LoadButton.Text = "更新";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(126, 300);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(75, 44);
            textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 450);
            Controls.Add(textBox2);
            Controls.Add(LoadButton);
            Controls.Add(Memo);
            Controls.Add(textBox1);
            Controls.Add(DelateButton);
            Controls.Add(Inputbutton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Memo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Inputbutton;
        private Button DelateButton;
        private TextBox textBox1;
        private DataGridView Memo;
        private Button LoadButton;
        private TextBox textBox2;
    }
}
