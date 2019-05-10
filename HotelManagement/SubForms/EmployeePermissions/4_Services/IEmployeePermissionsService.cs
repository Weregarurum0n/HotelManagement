using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.EmployeePermissions._3_Models.Req;
using HotelManagement.SubForms.EmployeePermissions._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.EmployeePermissions._4_Services
{
    public interface IEmployeePermissionsService
    {
        List<EmployeePermission> GetEmployeePermissions(int employeeId);
        ReturnStatus SetEmployeePermission(SetEmployeePermission req);
    }
}
