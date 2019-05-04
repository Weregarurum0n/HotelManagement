using HotelManagement.Shared.BaseClass;
using HotelManagement.Shared.Dialogs;
using MahApps.Metro;
using Prism.Commands;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace HotelManagement.SubForms.Themes._2_ViewModels
{
    public class PersonalizationViewModel : SharedBaseViewModel
    {
        #region Fields

        private IDialogObjects _dialogs;

        #endregion

        #region Constructor

        public PersonalizationViewModel()
        {
            _dialogs = new DialogObjects();
            _dialogs.SetViewModel(this);

            AccentCmd = new DelegateCommand<string>(OnSetAccent);
            ThemeCmd = new DelegateCommand<string>(OnSetTheme);
        }

        #endregion

        #region Properties

        public ICommand AccentCmd { get; private set; }

        public ICommand ThemeCmd { get; private set; }

        #endregion

        #region Set Accent/Theme

        public void OnSetAccent(string cmdPrm)
        {
            try
            {
                var tmpAccent = ThemeManager.Accents.FirstOrDefault(x => x.Name == cmdPrm);
                var tmpTheme = ThemeManager.DetectAppStyle().Item1;

                ThemeManager.ChangeAppStyle(System.Windows.Application.Current, tmpAccent, tmpTheme);
            }
            catch
            {
                _dialogs.DisplayErrorDialog("Unable To update the application's accent color", string.Empty);
                return;
            }
        }

        public void OnSetTheme(string cmdPrm)
        {
            try
            {
                var tmpTheme = ThemeManager.AppThemes.FirstOrDefault(x => x.Name == cmdPrm);
                var tmpAccent = ThemeManager.DetectAppStyle().Item2;

                ThemeManager.ChangeAppStyle(System.Windows.Application.Current, tmpAccent, tmpTheme);
            }
            catch
            {
                _dialogs.DisplayErrorDialog("Unable To update the application's theme", string.Empty);
                return;
            }
        }

        #endregion

    }
}
