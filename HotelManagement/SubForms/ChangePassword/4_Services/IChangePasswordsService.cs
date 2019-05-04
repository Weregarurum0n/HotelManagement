using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.ChangePassword._3_Models.Req;

namespace HotelManagement.SubForms.ChangePassword._4_Services
{
    public interface IChangePasswordsService
    {
        ResponseStatus SetPassword(SetPassword req);
    }
}
