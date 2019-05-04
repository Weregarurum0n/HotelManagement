namespace HotelManagement.SubForms.Payments._3_Models.Req
{
    public class GetPayments
    {
        public int PaymentId { get; set; }
        public int GuestId { get; set; }
        public decimal Amount { get; set; }
        public int CardTypeId { get; set; }
        public decimal SafetyDeposit { get; set; }
        public string Comment { get; set; }
    }
}
