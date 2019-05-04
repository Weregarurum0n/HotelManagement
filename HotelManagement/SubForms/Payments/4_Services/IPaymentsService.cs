using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Payments._3_Models.Req;
using HotelManagement.SubForms.Payments._3_Models.Res;
using System.Collections.Generic;

namespace HotelManagement.SubForms.Payments._4_Services
{
    public interface IPaymentsService
    {
        List<Payment> GetPayments(GetPayments req);
        Payment GetPayment(int paymentId);
        ResponseStatus SetPayment(SetPayment req);
    }
}
