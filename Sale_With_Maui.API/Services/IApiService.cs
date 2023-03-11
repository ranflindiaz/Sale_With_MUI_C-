using Sale_With_Maui.Shared.Response;

namespace Sale_With_Maui.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}
