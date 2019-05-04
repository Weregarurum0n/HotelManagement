using System;

namespace HotelManagement.SubForms.Guests._3_Models.Res
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public int GuestTypeId { get; set; }
        public string DLNo { get; set; }
        public bool BlackListed { get; set; }
        public DateTime BlackListDate { get; set; }
        public string StreetAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
