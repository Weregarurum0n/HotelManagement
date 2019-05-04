using System;

namespace HotelManagement.SubForms.EmployeePermissions._3_Models.Res
{
    public class EmployeePermission
    {
        public int EmployeeId { get; set; }
        public int PermissionId { get; set; }
        public string Name { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
