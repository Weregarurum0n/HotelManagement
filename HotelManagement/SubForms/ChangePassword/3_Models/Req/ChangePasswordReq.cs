﻿namespace HotelManagement.SubForms.ChangePassword._3_Models.Req
{
    public class ChangePasswordReq
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
