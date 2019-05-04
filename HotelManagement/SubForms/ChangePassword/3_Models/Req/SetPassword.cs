namespace HotelManagement.SubForms.ChangePassword._3_Models.Req
{
    public class SetPassword
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
