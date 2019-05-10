using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Bookings._3_Models.Req;
using HotelManagement.SubForms.Bookings._3_Models.Res;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HotelManagement.SubForms.Bookings._4_Services
{
    public class BookingsService : IBookingsService
    {
        private readonly string ApiUrl;

        public BookingsService()
        {
            ApiUrl = Convert.ToString(ConfigurationManager.AppSettings["HotelManagementApiUrl"]);
        }

        public List<Booking> GetBookings(GetBookings req)
        {
            return null;
        }

        public Booking GetBooking(int bookingId)
        {
            return null;
        }

        public ReturnStatus SetBooking(SetBooking req)
        {
            return null;
        }
    }
}
