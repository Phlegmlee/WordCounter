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
            if (File.Exists("word_count_log.txt"))
            {
                var log = File.ReadAllLines("word_count_log.txt");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists("word_count_log.txt"))
            {
                File.Create("word_count_log.txt").Close();
                using (StreamWriter sw = File.AppendText("word_count_log.txt"))
                {
                    sw.WriteLine("FILE CREATED");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText("word_count_log.txt"))
                {
                    sw.WriteLine("FILE EXISTS, MODIFIED");
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            var combined_count_date = "Words: " + wordCountNum.Value.ToString() + "      Date: " + dateTimePicker.Value.ToString();
            if (wordCountNum.Value > 0)
                tallyBox.Items.Add(combined_count_date);
            totalWordCount.Value += wordCountNum.Value;
        }
    }
}
