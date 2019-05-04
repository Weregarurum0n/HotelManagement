using HotelManagement.Shared.Convert.Extensions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HotelManagement.Shared.BaseClass
{
    public class SharedBaseViewModel : BindableBase
    {
        #region Check Permissions

        public bool HasPermissions(int pm)
        {
            try
            {
                var permissionsObject = (List<int>)App.Current.Properties["UserPermissions"];
                var permissions = new List<int>();

                foreach (object i in permissionsObject)
                    permissions.Add(i.ToSafeInt32());

                return permissions.IndexOf(pm) != -1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Loading

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                RaisePropertyChanged();
            }
        }

        public void IsLoading(bool isloading)
        {
            IsActive = isloading;
        }

        #endregion

        #region Raise Propery

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {

        }
        
        #endregion
    }
}
