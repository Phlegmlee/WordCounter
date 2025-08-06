using System.IO;
using WordCounter.Models;


namespace WordCounter
{
    public partial class MainPage : ContentPage
    {
        const string log_file = "WordCounter_log.txt";
        const string wc_file = "WordCounter_wc.txt";
        string log_path = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, log_file);
        string wc_path = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, wc_file);
        long previous_word_total = 0;


        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;

            var logItems = new List<LogItem>
            {
                new LogItem { WordCount = "9999999", WordDiff = "9999999", DateValue = "2025-08-05 19:30", NotesValue = ""},
                new LogItem { WordCount = "959", WordDiff = "699", DateValue = "2025-08-05 19:30", NotesValue = ""}
            };

            listView.ItemsSource = logItems;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            if (!File.Exists(log_path))
            {
                File.Create(log_path).Close();
            }
            else if (File.Exists(log_path))
            {      
                var log = File.ReadAllLines(log_path);
                foreach (string s in log)
                {
                    // Parse file, insert data into LogItem somehow????????
                }
            }

            if (!File.Exists(wc_path))
            {
                File.Create(wc_path).Close();
                File.WriteAllText(wc_path, "0");
            }
            else if (File.Exists(wc_path))
            {
                string wordCount = File.ReadAllText(wc_path);
                previous_word_total = long.Parse(wordCount);

                // Populate Word Count Boxes?
            }
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {

        }

    }

}
