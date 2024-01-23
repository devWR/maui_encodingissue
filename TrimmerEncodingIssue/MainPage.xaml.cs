using System.Text;

namespace TrimmerEncodingIssue
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //Without trimming asciiEnc = US-ASCII
            //After trimming asciiEnc = Globalization_cp_20127
            var asciiEnc = System.Text.Encoding.ASCII.EncodingName;

            CounterBtn.Text = $"{count}. {asciiEnc}";
            SemanticScreenReader.Announce(CounterBtn.Text);

            //GetEncoding will throw exception when app is trimmed
            var enc = Encoding.GetEncoding(Encoding.ASCII.EncodingName, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
            Console.WriteLine($"Encoding: {enc?.EncodingName}");
        }
    }

}
