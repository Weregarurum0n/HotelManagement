using Prism.Mvvm;
using System.Collections.Generic;

namespace HotelManagement.Shared.BaseClass
{
    public class SharedBaseViewModel : BindableBase
    {
        
        public bool HasPermissions(int pm)
        {
            if (UsersPermissions == null) return false;

            foreach (var i in UsersPermissions)
                if (i == pm)
                    return true;

            return false;
        }

        private List<int> _usersPermissions;
        public List<int> UsersPermissions
        {
            get { return _usersPermissions; }
            set
            {
                _usersPermissions = value;
                RaisePropertyChanged();
            }
        }

        private bool IsActive { get; set; }
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                IsActive = value;
                RaisePropertyChanged(nameof(IsActive));
            }
        }

        public void RaisePropertyChanged(object value)
        {
            //PropertyChanged(this, new PropertyChangedEventArgs(value.Name);
        }
    }
}
