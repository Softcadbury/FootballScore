namespace FootballScore.Views
{
    using System.Windows;
    using FootballScore.ViewModels;

    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
}