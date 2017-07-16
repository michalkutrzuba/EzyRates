using System.Xml.Serialization;

namespace EzyRates.Web.Concepts.RatesApi.DataContract.Xml
{
    [XmlRoot("web_dis_rates")]
    public class ForexResponse
    {
        [XmlElement("timestamp")]
        public string UpdatedOn { get; set; }

        [XmlElement("row")]
        public Rate[] Rates { get; set; }
    }

    public class Rate
    {
        [XmlElement("swift_code")]
        public string CurrencyCode { get; set; }

        [XmlElement("swift_name")]
        public string CurrencyName { get; set; }

        [XmlElement("multiply")]
        public string Multiply { get; set; }

        [XmlElement("buy_cash")]
        public string BuyRate { get; set; }

        [XmlElement("sell_cash")]
        public string SellRate { get; set; }

        [XmlElement("base_swift")]
        public string FromCurrencyCode { get; set; }

        [XmlElement("CurrencyGuide")]
        public CurrencyGuide CurrencyGuide { get; set; }
    }

    public class CurrencyGuide
    {
        [XmlAttribute(AttributeName = "BaseSwift")]
        public string From { get; set; }

        [XmlAttribute(AttributeName = "Swift")]
        public string To { get; set; }

        [XmlAttribute(AttributeName = "Amount")]
        public string Amount { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}