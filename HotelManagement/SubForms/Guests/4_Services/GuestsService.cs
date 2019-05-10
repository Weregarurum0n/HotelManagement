using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Guests._3_Models.Req;
using HotelManagement.SubForms.Guests._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Guests._4_Services
{
    public class GuestsService : IGuestsService
    {
        public GuestsService()
        {

        }

        public List<Guest> GetGuests(GetGuests req)
        {
            return null;
        }

        public Guest GetGuest(int guestId)
        {
            return null;
        }

        public ReturnStatus SetGuest(SetGuest req)
        {
            return null;
        }
    }
}
