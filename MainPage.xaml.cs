using WordCounter.Models;


namespace WordCounter
{
    public partial class MainPage : ContentPage
    {
        const string log_file = "WordCounter_log.txt";
        const string wc_file = "WordCounter_wc.txt";
        string log_path = Path.Combine(FileSystem.Current.AppDataDirectory, log_file);
        string wc_path = Path.Combine(FileSystem.Current.AppDataDirectory, wc_file);
        long previous_word_total = 0;


        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;

            var list = new List<LogItem>
            {
               new LogItem { WordCount = 0, WordDiff = 0, DateValue = "", NotesValue = log_path }
            };

            listView.ItemsSource = list;
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
                    //list.Add(logItem);
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

       private static void SaveToFile(string path, string logItem, bool overwrite = false)
        {
            if (File.Exists(path))
            {
                File.AppendAllText(path, logItem);

                if (overwrite)
                {
                    File.WriteAllText(path, logItem);
                }
            }
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            string entryText = entry.Text;
            long count = long.Parse(entryText);
            long diff = count - previous_word_total;
            string date = datePicker.Date.ToString();

            // TODO: Find a way to save the data that can be extracted into a LogItem

            //SaveToFile(log_path, );
            //list.Add(newListItem);

        }

    }

}
