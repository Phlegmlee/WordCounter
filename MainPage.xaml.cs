using WordCounter.Models;
using System.Xml.Serialization;


namespace WordCounter
{
    public partial class MainPage : ContentPage
    {
        const string log_file = "WordCounter_log.xml";
        const string wc_file = "WordCounter_wc.txt";
        string log_path = Path.Combine(FileSystem.Current.AppDataDirectory, log_file);
        string wc_path = Path.Combine(FileSystem.Current.AppDataDirectory, wc_file);
        long previous_word_total = 0;

        List<LogItem> list;


        /// <summary>
        /// The main entry for the page.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;

            list = new List<LogItem>
            {
               new LogItem { WordCount = 0, WordDiff = 0, DateValue = "", NotesValue = log_path }
            };

            listView.ItemsSource = list;
        }

        /// <summary>
        /// Called when the main page is first loaded. Used to initialize data from files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public void Save<T>(string path, T objectToSave)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(fs, objectToSave);
            }
            
        }

        public T Load<T>(string path, T objectToLoad)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);

                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    return (T)formatter.Deserialize(stream);
                }
            }
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            string entryText = entry.Text;
            long count = long.Parse(entryText); // This currently only works if the input is only a number.
            long diff = count - previous_word_total;
            string date = datePicker.Date.ToString();

            var test = new LogItem { WordCount = count, WordDiff = diff, DateValue = date, NotesValue = "Meep" };
            list.Add(test);
            Save(log_path, list);

        }

    }

}
