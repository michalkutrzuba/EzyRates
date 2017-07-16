using System;
using System.Collections.Generic;

namespace EzyRates.Web.Concepts.RatesApi.DataContract.Json
{
    public class ForexModel
    {
        public ForexModel(DateTime updatedOn, IEnumerable<CurrencyModel> currencies)
        {
            UpdatedOn = updatedOn;
            Currencies = currencies;
        }

        public DateTime UpdatedOn { get; private set; }

        public IEnumerable<CurrencyModel> Currencies { get; private set; }
    }

    public class CurrencyModel
    {
        public CurrencyModel(CurrencyDetailsModel details, CurrencyRateModel rate, CurrencyGuideModel guide)
        {
            Details = details;
            Rate = rate;
            Guide = guide;
        }

        public CurrencyDetailsModel Details { get; private set; }

        public CurrencyRateModel Rate { get; private set; }

        public CurrencyGuideModel Guide { get; private set; }
    }

    public class CurrencyRateModel
    {
        public CurrencyRateModel(double buy, double sell, int multiply)
        {
            Buy = buy;
            Sell = sell;
            Multiply = multiply;
        }

        public double Buy { get; private set; }

        public double Sell { get; private set; }

        public int Multiply { get; private set; }
    }

    public class CurrencyDetailsModel
    {
        public CurrencyDetailsModel(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; private set; }

        public string Name { get; private set; }
    }

    public class CurrencyGuideModel
    {
        public CurrencyGuideModel(string @from, string to, int amount, double value)
        {
            From = @from;
            To = to;
            Amount = amount;
            Value = value;
        }

        public string From { get; private set; }

        public string To { get; private set; }

        public int Amount { get; private set; }

        public double Value { get; private set; }
    }
}