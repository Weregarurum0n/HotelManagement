namespace HotelManagement.SubForms.Constants._3_Models.Req
{
    public class GetConstants
    {
        public int ConstantId { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IncludeDisabled { get; set; }
    }
}
