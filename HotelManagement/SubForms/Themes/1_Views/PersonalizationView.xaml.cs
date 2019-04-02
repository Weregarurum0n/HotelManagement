using HotelManagement.SubForms.Themes._2_ViewModels;

namespace HotelManagement.SubForms.Themes._1_Views
{
    /// <summary>
    /// Interaction logic for PersonalizationView.xaml
    /// </summary>
    public partial class PersonalizationView
    {
        public PersonalizationView()
        {
            InitializeComponent();
            DataContext = new PersonalizationViewModel();
        }
    }
}
