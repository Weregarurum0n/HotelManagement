using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.Payments._3_Models.Req;
using HotelManagement.SubForms.Payments._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Payments._4_Services
{
    public class PaymentsService : IPaymentsService
    {
        public PaymentsService()
        {

        }

        public List<Payment> GetPayments(GetPayments req)
        {
            return null;
        }

        public Payment GetPayment(int paymentId)
        {
            return null;
        }

        public ReturnStatus SetPayment(SetPayment req)
        {
            return null;
        }
    }
}
