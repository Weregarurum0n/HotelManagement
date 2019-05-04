using HotelManagement.Shared.BaseClass;
using HotelManagement.Shared.Dialogs;
using HotelManagement.SubForms.Permissions._3_Models.Req;
using Prism.Commands;
using System.Windows.Input;

namespace HotelManagement.SubForms.Permissions._2_ViewModels
{
    public class PermissionsViewModel : SharedBaseViewModel
    {
        #region Fields

        private IDialogObjects _dialogs;

        private GetPermissions _getPermissionsReq;
        private SetPermission _setPermissionsReq;
        private string _searchUser;
        private string _searchPermission;

        #endregion

        #region Constructor

        public PermissionsViewModel()
        {
            _dialogs = new DialogObjects();
            _dialogs.SetViewModel(this);

            SearchCmd = new DelegateCommand(OnSearchUser);
            MenuCmd = new DelegateCommand(OnSetUserPermissions);

            GetPermissionsReq = new GetPermissions();
            SetPermissionsReq = new SetPermission();

            SearchUser = string.Empty;
            SearchPermission = string.Empty;
        }

        #endregion

        #region Properties

        public ICommand SearchCmd { get; private set; }
        public ICommand MenuCmd { get; private set; }

        public GetPermissions GetPermissionsReq
        {
            get { return _getPermissionsReq; }
            set
            {
                _getPermissionsReq = value;
                RaisePropertyChanged();
            }
        }

        public SetPermission SetPermissionsReq
        {
            get { return _setPermissionsReq; }
            set
            {
                _setPermissionsReq = value;
                RaisePropertyChanged();
            }
        }

        public string SearchUser
        {
            get { return _searchUser; }
            set
            {
                _searchUser = value;
                RaisePropertyChanged();
            }
        }

        public string SearchPermission
        {
            get { return _searchPermission; }
            set
            {
                _searchPermission = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region SearchUser

        public void OnSearchUser()
        {
        }

        #endregion

        #region Get All Permissions

        public void OnGetAllPermissions()
        {
        }

        #endregion

        #region Get User Permissions

        public void OnGetUserPermissions()
        {
        }

        #endregion

        #region Set User Permissions

        public void OnSetUserPermissions()
        {
        }

        #endregion
    }
}
