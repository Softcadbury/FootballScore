namespace FootballScore.ViewModels
{
    using FootballScore.BusinessLogic;

    public class ViewModel : BaseViewModel
    {
        public ViewModel()
        {
            Text = "lola";
            var countries = Generator.Generate();
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged("Text"); }
        }
    }
}