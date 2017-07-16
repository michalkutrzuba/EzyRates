using System.Linq;
using EzyRates.Web.Concepts.RatesApi;
using EzyRates.Web.Concepts.RatesApi.DataContract.Xml;
using EzyRates.Web.Concepts.RatesApi.Mapper;
using EzyRates.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EzyRates.Web.Controllers
{
    public class RatesApiController : Controller
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly IXmlSerializerWrapper _xmlSerializer;
        
        private readonly IOptions<RatesApiConfig> _apiConfig;
        private readonly ICurrencyMapper _mapper;

        public RatesApiController(
            IHttpClientWrapper httpClient,
            IXmlSerializerWrapper xmlSerializer,
            IOptions<RatesApiConfig> apiConfig,
            ICurrencyMapper mapper)
        {
            _httpClient = httpClient;
            _xmlSerializer = xmlSerializer;
            
            _apiConfig = apiConfig;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetRates()
        {
            var rawResponse = _httpClient.GetStringAsync(_apiConfig.Value.Url).Result;
            var xmlResponse = _xmlSerializer.Deserialize<ForexResponse>(rawResponse);

            var selectedCurrencyCodes = new[] {"USD", "EUR"};
            var selectedRates = xmlResponse.Rates.Where(rate => selectedCurrencyCodes.Contains(rate.CurrencyCode)).ToArray();

            var jsonModel = _mapper.MapToJsonModel(xmlResponse.UpdatedOn, selectedRates);
            
            return new JsonResult(jsonModel);
        }
    }
}