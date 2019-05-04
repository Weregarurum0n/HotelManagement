using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Permissions._3_Models.Req;
using HotelManagement.SubForms.Permissions._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Permissions._4_Services
{
    public interface IPermissionsService
    {
        List<Permission> GetPermissions(GetPermissions req);
        Permission GetPermission(int permissionId);
        ResponseStatus SetPermission(SetPermission req);
    }
}
