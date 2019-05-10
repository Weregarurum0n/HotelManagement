using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Login._3_Models.Req;
using HotelManagement.SubForms.Login._3_Models.Res;

namespace HotelManagement.SubForms.Login._4_Services
{
    public interface ILogonService
    {
        ApiResponse<UserDetail> Login(AuthLogin req);
    }
}
