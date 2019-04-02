using MahApps.Metro.Controls;
using Prism.Interactivity;
using System.Windows;
using System.Windows.Media;

namespace HotelManagement.Shared.Objects
{
    public class MetroPopUpWindow : PopupWindowAction
    {
        protected override Window CreateWindow()
        {
            var theWindow = new MetroWindow
            {
                TitleCharacterCasing = System.Windows.Controls.CharacterCasing.Normal,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                WindowTransitionsEnabled = false,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
            };

            return theWindow;
        }
    }
}
