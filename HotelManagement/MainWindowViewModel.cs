using HotelManagement.Shared.BaseClass;
using HotelManagement.Shared.Dialogs;
using HotelManagement.SubForms.ChangePassword._1_Views;
using HotelManagement.SubForms.Login._1_Views;
using HotelManagement.SubForms.Permissions._1_Views;
using HotelManagement.SubForms.Themes._1_Views;
using Prism.Commands;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement
{
    public class MainWindowViewModel : SharedBaseViewModel
    {
        #region Fields

        private IDialogObjects _dialogs;

        private string _mainWindowTitle;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            _dialogs = new DialogObjects();
            _dialogs.SetViewModel(this);

            MenuCmd = new DelegateCommand<string>(OnMenu);

            MainWindowTitle = "Hotel Management";

            UsersPermissions = new System.Collections.Generic.List<int> {1, 2, 3};
        }

        #endregion

        #region Properties

        public ICommand MenuCmd { get; private set; }

        public string MainWindowTitle
        {
            get { return _mainWindowTitle; }
            set
            {
                _mainWindowTitle = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Menus

        public void OnMenu(string cmdPrm)
        {
            var selectedMenu = new MenuSelection();
            try
            {
                selectedMenu = (MenuSelection)Enum.Parse(typeof(MenuSelection), cmdPrm);
            }
            catch
            {
                _dialogs.DisplayErrorDialog("Unable To Parse Menu", "The selected menu option " + cmdPrm + " was not found. Please contact the developer.");
                return;
            }

            //if (!HasPermissions((int)selectedMenu))
            //{
            //    _dialogs.DisplayNoPermissionDialog();
            //    return;
            //}

            switch (selectedMenu)
            {
                case MenuSelection.LogOn:
                    ShowWindow(new LogonView(), "Log On", ResizeMode.NoResize);
                    break;
                case MenuSelection.LogOff:
                    break;
                case MenuSelection.ChangePassword:
                    ShowWindow(new ChangePasswordView(), "Change Password", ResizeMode.NoResize);
                    break;
                case MenuSelection.Personalization:
                    ShowWindow(new PersonalizationView(), "Personalization", ResizeMode.NoResize);
                    break;
                case MenuSelection.Restart:
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                    return;
                case MenuSelection.ShutDown:
                    Application.Current.Shutdown();
                    return;

                case MenuSelection.RoomManagement:
                    break;
                case MenuSelection.ReserveaRoom:
                    break;
                case MenuSelection.BlackList:
                    break;
                case MenuSelection.ManageOtherUsers:
                    break;

                case MenuSelection.Users:
                    break;
                case MenuSelection.ManagePermissions:
                    ShowWindow(new PermissionsView(), "Permissions", ResizeMode.NoResize);
                    break;


                default:
                    break;
            };
        }

        #endregion

        private void ShowWindow(object content, string title, ResizeMode canResize = ResizeMode.CanResize, bool isModal = true)
        {
            var window = new Window()
            {
                Content = content,
                SizeToContent = SizeToContent.WidthAndHeight,
                Title = title,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowInTaskbar = false,
                ResizeMode = canResize,
            };

            if (isModal)
                window.ShowDialog();
            else
                window.Show();
        }
    }

    public enum MenuSelection
    {
        LogOn = 11,
        LogOff = 21,
        ChangePassword = 51,
        Personalization = 41,
        Restart = 31,
        ShutDown = 61,
        RoomManagement = 101,
        ReserveaRoom = 201,
        BlackList = 301,
        ManageOtherUsers = 701,
        Users = 801,
        ManagePermissions = 901
    }
}
