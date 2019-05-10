﻿using HotelManagement.Shared.BaseClass;
using HotelManagement.Shared.Dialogs;
using HotelManagement.SubForms.ChangePassword._3_Models.Req;
using HotelManagement.SubForms.ChangePassword._4_Services;
using Prism.Commands;
using System.Windows.Input;

namespace HotelManagement.SubForms.ChangePassword._2_ViewModels
{
    public class ChangePasswordViewModel : SharedBaseViewModel
    {
        #region Fields

        private IDialogObjects _dialogs;
        private IChangePasswordsService _service;

        private SetPassword _saveReq;
        private string _currentPassword;
        private string _newPassword;
        private string _confirmPassword;

        #endregion

        #region Constructor

        public ChangePasswordViewModel()
        {
            _dialogs = new DialogObjects();
            _dialogs.SetViewModel(this);

            _service = new ChangePasswordsService();

            SaveCmd = new DelegateCommand(OnSave);

            SaveReq = new SetPassword();

            CurrentPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
        }

        #endregion

        #region Properties

        public ICommand SaveCmd { get; private set; }

        public SetPassword SaveReq
        {
            get { return _saveReq; }
            set
            {
                _saveReq = value;
                RaisePropertyChanged();
            }
        }

        public string CurrentPassword
        {
            get { return _currentPassword; }
            set
            {
                _currentPassword = value;
                RaisePropertyChanged();
            }
        }

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                RaisePropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Save

        public void OnSave()
        {
            if (NewPassword != ConfirmPassword)
            {
                _dialogs.DisplayErrorDialog("Password Mismatch", "New Password and Confirm Password does not Match");
                return;
            }

            IsLoading(true);
            //save
            IsLoading(false);
        }

        #endregion
    }
}
