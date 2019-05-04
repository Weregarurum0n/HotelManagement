using HotelManagement.SubForms.Login._2_ViewModels;
using System.Windows.Controls;

namespace HotelManagement.SubForms.Login._1_Views
{
    /// <summary>
    /// Interaction logic for LogonView.xaml
    /// </summary>
    public partial class LogonView
    {
        public LogonView()
        {
            InitializeComponent();
            DataContext = new LogonViewModel();
        }
    }
}
