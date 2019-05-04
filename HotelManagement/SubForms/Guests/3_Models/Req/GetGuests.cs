using System;

namespace HotelManagement.SubForms.Guests._3_Models.Req
{
    public class GetGuests
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public int GuestTypeId { get; set; }
        public string DLNo { get; set; }
        public bool IncludeBlackListed { get; set; }
        public DateTime BlackListDate { get; set; }
        public string StreetAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }
}
