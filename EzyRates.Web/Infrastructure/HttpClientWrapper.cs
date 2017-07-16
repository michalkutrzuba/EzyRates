using System.Net.Http;
using System.Threading.Tasks;

namespace EzyRates.Web.Infrastructure
{
    public interface IHttpClientWrapper
    {
        Task<string> GetStringAsync(string requestUri);

        //TODO: wrap other methods
    }

    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }
        
        public Task<string> GetStringAsync(string requestUri)
        {
            return _httpClient.GetStringAsync(requestUri);
        }
    }
}