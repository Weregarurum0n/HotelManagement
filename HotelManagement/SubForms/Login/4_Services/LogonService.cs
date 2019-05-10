using HotelManagement.Shared.BaseClass;
using HotelManagement.SubForms.Login._3_Models.Req;
using HotelManagement.SubForms.Login._3_Models.Res;

namespace HotelManagement.SubForms.Login._4_Services
{
    public class LogonService : ILogonService
    {
        ISharedBaseService _apiService;

        public LogonService()
        {
            _apiService = new SharedBaseService();
        }

        public ApiResponse<UserDetail> Login(AuthLogin req)
        {
            req.UserName = "D";
            req.Password = "ad";

            return _apiService.GetAsync<UserDetail>("Login", req);
        }
    }
}
