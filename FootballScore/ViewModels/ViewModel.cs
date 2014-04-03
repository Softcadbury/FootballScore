namespace FootballScore.ViewModels
{
    using System.Collections.Generic;

    using FootballScore.BusinessLogic;
    using FootballScore.Model;

    public class ViewModel : BaseViewModel
    {
        public ViewModel()
        {
            Countries = Generator.Generate();
        }

        private List<Country> _countries;

        public List<Country> Countries
        {
            get { return _countries; }
            set { _countries = value; OnPropertyChanged("Countries"); }
        }
    }
}