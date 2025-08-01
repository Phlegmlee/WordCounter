namespace WordCounter
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            WordcountLabel = new Label();
            EnterButton = new Button();
            tallyBox = new ListBox();
            DateLabel = new Label();
            dateTimePicker = new DateTimePicker();
            wordCountNum = new NumericUpDown();
            totalLabel = new Label();
            totalWordCount = new NumericUpDown();
            openFileDialog = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wordCountNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalWordCount).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.Size = new Size(464, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, closeToolStripMenuItem, settingsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New | CTRL + N";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open | CTRL + O";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save | CTRL + S";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(180, 22);
            closeToolStripMenuItem.Text = "Close | CTRL + Q";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 22);
            editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 22);
            viewToolStripMenuItem.Text = "View";
            // 
            // WordcountLabel
            // 
            WordcountLabel.AutoSize = true;
            WordcountLabel.Location = new Point(197, 44);
            WordcountLabel.Margin = new Padding(2, 0, 2, 0);
            WordcountLabel.Name = "WordcountLabel";
            WordcountLabel.Size = new Size(67, 15);
            WordcountLabel.TabIndex = 2;
            WordcountLabel.Text = "Wordcount";
            // 
            // EnterButton
            // 
            EnterButton.Location = new Point(206, 133);
            EnterButton.Margin = new Padding(2);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(51, 24);
            EnterButton.TabIndex = 3;
            EnterButton.Text = "Enter";
            EnterButton.UseVisualStyleBackColor = true;
            EnterButton.Click += EnterButton_Click;
            // 
            // tallyBox
            // 
            tallyBox.FormattingEnabled = true;
            tallyBox.ItemHeight = 15;
            tallyBox.Location = new Point(11, 176);
            tallyBox.Margin = new Padding(2);
            tallyBox.Name = "tallyBox";
            tallyBox.Size = new Size(442, 244);
            tallyBox.TabIndex = 4;
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(216, 86);
            DateLabel.Margin = new Padding(2, 0, 2, 0);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(31, 15);
            DateLabel.TabIndex = 5;
            DateLabel.Text = "Date";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Segoe UI", 9F);
            dateTimePicker.Location = new Point(134, 103);
            dateTimePicker.Margin = new Padding(2);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(198, 23);
            dateTimePicker.TabIndex = 7;
            // 
            // wordCountNum
            // 
            wordCountNum.AllowDrop = true;
            wordCountNum.Location = new Point(172, 62);
            wordCountNum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            wordCountNum.Name = "wordCountNum";
            wordCountNum.Size = new Size(120, 23);
            wordCountNum.TabIndex = 8;
            wordCountNum.ThousandsSeparator = true;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(12, 422);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(100, 15);
            totalLabel.TabIndex = 9;
            totalLabel.Text = "Total Word Count";
            // 
            // totalWordCount
            // 
            totalWordCount.InterceptArrowKeys = false;
            totalWordCount.Location = new Point(12, 440);
            totalWordCount.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            totalWordCount.Name = "totalWordCount";
            totalWordCount.ReadOnly = true;
            totalWordCount.Size = new Size(120, 23);
            totalWordCount.TabIndex = 11;
            totalWordCount.TabStop = false;
            totalWordCount.ThousandsSeparator = true;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(464, 481);
            Controls.Add(totalWordCount);
            Controls.Add(totalLabel);
            Controls.Add(wordCountNum);
            Controls.Add(dateTimePicker);
            Controls.Add(DateLabel);
            Controls.Add(tallyBox);
            Controls.Add(EnterButton);
            Controls.Add(WordcountLabel);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "WordCounter";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wordCountNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalWordCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label WordcountLabel;
        private Button EnterButton;
        private ListBox tallyBox;
        private Label DateLabel;
        private DateTimePicker dateTimePicker;
        private NumericUpDown wordCountNum;
        private Label totalLabel;
        private NumericUpDown totalWordCount;
        private OpenFileDialog openFileDialog;
    }
}
