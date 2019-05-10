using HotelManagement.Shared.Models.Objects;
using HotelManagement.Shared.Objects;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HotelManagement.Shared.BaseClass
{
    public class SharedBaseService : ISharedBaseService
    {
        private readonly HttpClient _client;

        public SharedBaseService()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:59012"),
            };
        }

        public ApiResponse<T> GetAsync<T>(string requestUri, object content)
        {
            return Execute<T>(requestUri, content, HttpMethod.Get);
        }

        public ApiResponse<T> PostAsync<T>(string requestUri, object content)
        {
            return Execute<T>(requestUri, content, HttpMethod.Post);
        }

        public ApiResponse<T> Execute<T>(string requestUri, object content, HttpMethod httpMethod)
        {
            var result = null as HttpResponseMessage;
            var response = null as ApiResponse<T>;

            try
            {
                if (httpMethod == HttpMethod.Get)
                {
                    if (content != null)
                        requestUri += "?" + content.ToQueryString();

                    result = _client.GetAsync(requestUri).Result;
                }
                else
                {
                    var myContent = JsonConvert.SerializeObject(content);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    result = _client.PostAsync(requestUri, byteContent).Result;
                }

                if (result == null) throw new Exception("empty response");
            }
            catch (HttpRequestException e)
            {
                response = new ApiResponse<T>()
                {
                    Status = new ReturnStatus(101, "Unable to connect to the API. " + e.Message),
                    Content = default(T)
                };
            }
            catch (Exception e)
            {
                response = new ApiResponse<T>()
                {
                    Status = new ReturnStatus(100, "Oops, something went wrong. " + e.Message),
                    Content = default(T)
                };
            }
            return response;
        }
    }
}
