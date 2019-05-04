namespace HotelManagement.SubForms.EmployeePermissions._3_Models.Req
{
    public class SetEmployeePermission
    {
        public int EmployeeId { get; set; }
        public int PermissionId { get; set; }
        public bool Disable { get; set; }
    }
}
