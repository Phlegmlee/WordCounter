using System.IO;

namespace WordCounter
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("word_count_log.txt"))
            {
                File.Create("word_count_log.txt").Close();
            }
            else
            {
                var log = File.ReadAllLines("word_count_log.txt");
                // TODO: DO SOMETHING WITH THE FILE CONTENTS
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists("word_count_log.txt"))
            {
                File.Create("word_count_log.txt").Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open file
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save file
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            var combined_count_date = "Words: " + wordCountNum.Value.ToString() + "      Date: " + dateTimePicker.Value.ToString();
            if (wordCountNum.Value > 0)
                tallyBox.Items.Add(combined_count_date);
            totalWordCount.Value += wordCountNum.Value;

            // TODO: Save to file
        }
    }
}
