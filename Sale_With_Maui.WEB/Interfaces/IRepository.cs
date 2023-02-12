using Sale_With_Maui.WEB.Repositories;

namespace Sale_With_Maui.WEB.Interfaces
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);

        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);
    }
}
