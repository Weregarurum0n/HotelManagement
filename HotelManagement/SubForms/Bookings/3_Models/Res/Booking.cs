using System;

namespace HotelManagement.SubForms.Bookings._3_Models.Res
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int PaymentId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int BookTypeId { get; set; }
        public decimal BookRate { get; set; }
        public string Comment { get; set; }
        public bool Canceled { get; set; }
        public DateTime CanceledDate { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
