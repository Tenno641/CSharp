namespace NumericTypesSuggester
{
    public partial class NumericTypeSuggesterApp : Form
    {
        public NumericTypeSuggesterApp()
        {
            InitializeComponent();
        }
        private int _counter;
        private void IncreaseCounterButton_Click(object sender, EventArgs e)
        {
            _counter++;
            CounterText.Text = _counter.ToString();
        }
    }
}
