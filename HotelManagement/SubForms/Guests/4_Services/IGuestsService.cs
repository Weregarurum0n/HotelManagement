using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Guests._3_Models.Req;
using HotelManagement.SubForms.Guests._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Guests._4_Services
{
    public interface IGuestsService
    {
        List<Guest> GetGuests(GetGuests req);
        Guest GetGuest(int guestId);
        ReturnStatus SetGuest(SetGuest req);
    }
}
