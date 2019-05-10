namespace HotelManagement.Shared.BaseClass
{
    public interface ISharedBaseService
    {
        ApiResponse<T> GetAsync<T>(string requestUri, object content);
        ApiResponse<T> PostAsync<T>(string requestUri, object content);
    }
}
