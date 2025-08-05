namespace WordCounter
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                SubmitBtn.Text = $"Clicked {count} time";
            else
                SubmitBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(SubmitBtn.Text);
        }

        public class Log
        {
            public string Words = "MEEP MORP";
        }
    }

}
