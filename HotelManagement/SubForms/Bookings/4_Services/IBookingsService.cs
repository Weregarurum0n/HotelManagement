using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Bookings._3_Models.Req;
using HotelManagement.SubForms.Bookings._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Bookings._4_Services
{
    public interface IBookingsService
    {
        List<Booking> GetBookings(GetBookings req);
        Booking GetBooking(int bookingId);
        ResponseStatus SetBooking(SetBooking req);
    }
}
