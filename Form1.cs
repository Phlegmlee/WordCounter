using System.IO;


namespace WordCounter
{
    public partial class Form1 : Form
    {
        const string log_file = "WordCounter_log.txt";
        const string word_count_file = "WordCounter_wc.txt";
        long previous_word_total = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(log_file))
            {
                File.Create(log_file).Close();
            }
            else if (File.Exists(log_file))
            {
                // Grab log, add to box
                string [] log = File.ReadAllLines(log_file);
                foreach (string s in log)
                {
                    tallyBox.Items.Add(s);
                }

            }

            if (!File.Exists(word_count_file))
            {
                File.Create(word_count_file).Close();
                
                // Add zero to new file in the event the application is
                // closed after first launch without word count input.
                // Avoids error with parsing
                File.WriteAllText(word_count_file, "0");
            }
            else if (File.Exists(word_count_file))
            {
                string wordCount = File.ReadAllText(word_count_file);
                previous_word_total = long.Parse(wordCount);

                // Populate word count box
                wordCountNum.Value = previous_word_total;

                // Populate total word count box
                totalWordCount.Value = previous_word_total;
            }

        }

        private void saveToFile(string path, string line_to_save, bool overwrite = false)
        {
            if (File.Exists(path))
            {
                File.AppendAllText(path, line_to_save);

                if (overwrite)
                {
                    File.WriteAllText(path, line_to_save);
                }
            }
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            long currentWordTotal = (long)wordCountNum.Value;
            long word_diff = currentWordTotal - previous_word_total;
            string output_string = "Words: " + currentWordTotal.ToString() + "      Words Written: "+ word_diff + "      Date: " + dateTimePicker.Value.ToString() + "\n";
            if (wordCountNum.Value > 0)
            {
                tallyBox.Items.Add(output_string);
                totalWordCount.Value = previous_word_total + word_diff;
                saveToFile(log_file, output_string);
                saveToFile(word_count_file, wordCountNum.Value.ToString(), true);
                previous_word_total = currentWordTotal;
            }
        }
    }
}
