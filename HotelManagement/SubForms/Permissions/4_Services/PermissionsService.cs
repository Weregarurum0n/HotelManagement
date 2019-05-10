using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Permissions._3_Models.Req;
using HotelManagement.SubForms.Permissions._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Permissions._4_Services
{
    public class PermissionsService : IPermissionsService
    {
        public PermissionsService()
        {

        }

        public List<Permission> GetPermissions(GetPermissions req)
        {
            return null;
        }

        public Permission GetPermission(int permissionId)
        {
            return null;
        }

        public ReturnStatus SetPermission(SetPermission req)
        {
            return null;
        }
    }
}
