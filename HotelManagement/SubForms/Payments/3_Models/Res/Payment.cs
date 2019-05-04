using System;

namespace HotelManagement.SubForms.Payments._3_Models.Res
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int GuestId { get; set; }
        public decimal Amount { get; set; }
        public int CardTypeId { get; set; }
        public decimal SafetyDeposit { get; set; }
        public string Comment { get; set; }

        public int CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
