using HotelManagement.Shared.Models.Objects;

namespace HotelManagement.Shared.BaseClass
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }

        public ApiResponse(T content)
        {
            Content = content;

            var status = content as ReturnStatus;
            if (status != null)
            {
                Status = status;
            }
            else
            {
                Status = content == null ? new ReturnStatus(204, "No Content") : new ReturnStatus(200, "Ok");
            }
        }

        public T Content { get; set; }
        public ReturnStatus Status { get; set; }

        public bool Success
        {
            get
            {
                return Status != null && (Status.ReturnId == 1 || Status.ReturnId == 200 || Status.ReturnId == 204);
            }
        }
    }
}
