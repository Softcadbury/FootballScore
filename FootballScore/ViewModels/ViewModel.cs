namespace FootballScore.ViewModels
{
    using FootballScore.BusinessLogic;
    using FootballScore.Model;

    public class ViewModel : BaseViewModel
    {
        public ViewModel()
        {
            Countries = Generator.Generate();
        }

        private Countries _countries;

        public Countries Countries
        {
            get { return _countries; }
            set { _countries = value; OnPropertyChanged("Countries"); }
        }
    }
}