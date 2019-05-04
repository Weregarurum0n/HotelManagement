using System;

namespace HotelManagement.SubForms.Permissions._3_Models.Res
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public int ParentId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
