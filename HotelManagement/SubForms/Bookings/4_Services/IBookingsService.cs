using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Bookings._3_Models.Req;
using HotelManagement.SubForms.Bookings._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Bookings._4_Services
{
    public interface IBookingsService
    {
        List<Booking> GetBookings(GetBookings req);
        Booking GetBooking(int bookingId);
        ReturnStatus SetBooking(SetBooking req);
    }
}
