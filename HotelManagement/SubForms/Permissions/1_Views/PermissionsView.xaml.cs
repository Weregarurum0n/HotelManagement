using HotelManagement.SubForms.Permissions._2_ViewModels;
using System.Windows.Controls;

namespace HotelManagement.SubForms.Permissions._1_Views
{
    /// <summary>
    /// Interaction logic for PermissionsView.xaml
    /// </summary>
    public partial class PermissionsView
    {
        public PermissionsView()
        {
            InitializeComponent();
            DataContext = new PermissionsViewModel();
        }
    }
}
