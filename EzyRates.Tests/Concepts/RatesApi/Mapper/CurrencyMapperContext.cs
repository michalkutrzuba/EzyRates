using System;
using System.Collections.Generic;
using EzyRates.Web.Concepts.RatesApi.DataContract.Json;
using EzyRates.Web.Concepts.RatesApi.DataContract.Xml;
using EzyRates.Web.Concepts.RatesApi.Mapper;

namespace EzyRates.Tests.Concepts.RatesApi.Mapper
{
    public abstract class CurrencyMapperContext : Specification
    {
        protected ICurrencyMapper Mapper;
        protected ForexModel Result;
        protected List<Rate> Rates;
        protected DateTime ValidDate;
        protected string ValidDateAsString;

        protected override void EstablishContext()
        {
            ValidDate = new DateTime(2017, 07, 14, 20, 08, 0);
            ValidDateAsString = "2017-07-14 20:08:00";
            Rates = new List<Rate>();

            Mapper = new CurrencyMapper();
        }

        protected Rate CreateRate(
            string currencyCode = "FakeCode",
            string buyRate = "0,0",
            string sellRate = "1,0",
            string multiply = "2",
            string currencyGuideAmount = "3",
            string currencyGuideValue = "4,0"
        )
        {
            return new Rate
            {
                CurrencyCode = currencyCode,
                CurrencyName = "FakeName",
                FromCurrencyCode = "FakeFromCurrencyCode",
                BuyRate = buyRate,
                SellRate = sellRate,
                Multiply = multiply,
                CurrencyGuide = new CurrencyGuide
                {
                    From = "FakeCurrencyGuideFrom",
                    To = "FakeCurrencyGuideTo",
                    Amount = currencyGuideAmount,
                    Value = currencyGuideValue
                }
            };
        }
    }
}