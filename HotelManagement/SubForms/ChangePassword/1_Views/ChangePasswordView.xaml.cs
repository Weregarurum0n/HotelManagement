using HotelManagement.SubForms.ChangePassword._2_ViewModels;

namespace HotelManagement.SubForms.ChangePassword._1_Views
{
    /// <summary>
    /// Interaction logic for ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView
    {
        public ChangePasswordView()
        {
            InitializeComponent();
            DataContext = new ChangePasswordViewModel();
        }
    }
}
