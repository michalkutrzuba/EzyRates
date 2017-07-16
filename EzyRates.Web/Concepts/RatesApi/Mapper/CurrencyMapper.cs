using System;
using System.Collections.Generic;
using EzyRates.Web.Concepts.RatesApi.DataContract.Json;
using EzyRates.Web.Concepts.RatesApi.DataContract.Xml;

namespace EzyRates.Web.Concepts.RatesApi.Mapper
{
    public interface ICurrencyMapper
    {
        ForexModel MapToJsonModel(string updatedOn, IEnumerable<Rate> rates);
    }

    public class CurrencyMapper : ICurrencyMapper
    {
        public ForexModel MapToJsonModel(string updatedOn, IEnumerable<Rate> rates)
        {
            var currencyModels = new List<CurrencyModel>();

            foreach (var rate in rates)
            {
                var detailsModel = new CurrencyDetailsModel(rate.CurrencyCode, rate.CurrencyName);

                var rateModel = new CurrencyRateModel(
                    rate.BuyRate.ToDouble(),
                    rate.SellRate.ToDouble(),
                    rate.Multiply.ToInt()
                );

                var guideModel = new CurrencyGuideModel(
                    rate.CurrencyGuide.From,
                    rate.CurrencyGuide.To,
                    rate.CurrencyGuide.Amount.ToInt(),
                    rate.CurrencyGuide.Value.ToDouble()
                );

                var currencyModel = new CurrencyModel(detailsModel, rateModel, guideModel);

                currencyModels.Add(currencyModel);
            }

            var mappedModel = new ForexModel(DateTime.Parse(updatedOn), currencyModels);

            return mappedModel;
        }
    }
}