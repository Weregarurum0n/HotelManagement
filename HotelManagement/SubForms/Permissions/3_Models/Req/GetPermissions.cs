namespace HotelManagement.SubForms.Permissions._3_Models.Req
{
    public class GetPermissions
    {
        public int PermissionId { get; set; }
        public int ParentId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IncludeDisabled { get; set; }
    }
}
