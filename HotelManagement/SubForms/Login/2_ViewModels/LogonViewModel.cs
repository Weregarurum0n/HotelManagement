using HotelManagement.Shared.BaseClass;
using HotelManagement.Shared.Dialogs;
using HotelManagement.SubForms.Login._3_Models.Req;
using HotelManagement.SubForms.Login._4_Services;
using Prism.Commands;
using System.Windows.Input;

namespace HotelManagement.SubForms.Login._2_ViewModels
{
    public class LogonViewModel : SharedBaseViewModel
    {
        #region Fields

        private IDialogObjects _dialogs;
        private ILogonService _service;

        private AuthLogin _logonReq;
        private string _userName;
        private string _password;

        #endregion

        #region Constructor

        public LogonViewModel()
        {
            _dialogs = new DialogObjects();
            _dialogs.SetViewModel(this);

            _service = new LogonService();

            IsLoading(false);

            LogonCmd = new DelegateCommand(OnLogon);

            LogonReq = new AuthLogin();

            UserName = string.Empty;
            Password = string.Empty;

            var b = App.Current.Properties["LoginUser"];
        }

        #endregion

        #region Properties

        public ICommand LogonCmd { get; private set; }

        public AuthLogin LogonReq
        {
            get { return _logonReq; }
            set
            {
                _logonReq = value;
                RaisePropertyChanged();
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }
        
        #endregion

        #region Save

        public void OnLogon()
        {
            //if (string.IsNullOrEmpty(UserName))
            //{
            //    _dialogs.DisplayErrorDialog("Username is Required", string.Empty);
            //    return;
            //}

            //if (string.IsNullOrEmpty(Password))
            //{
            //    _dialogs.DisplayErrorDialog("Password is Required", string.Empty);
            //    return;
            //}

            IsLoading(true);
            //Attempt logon
            var res = _service.Login(LogonReq);
            IsLoading(false);

            if (res.Success)
            {

            }
            else
            {
                _dialogs.DisplayErrorDialog(res.Status);
            }
        }

        #endregion
    }
}
