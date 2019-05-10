using HotelManagement.Shared.Models.Objects;
using HotelManagement.SubForms.ChangePassword._3_Models.Req;

namespace HotelManagement.SubForms.ChangePassword._4_Services
{
    public interface IChangePasswordsService
    {
        ReturnStatus SetPassword(SetPassword req);
    }
}
