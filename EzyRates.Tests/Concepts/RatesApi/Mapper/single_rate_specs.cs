using System;
using System.Linq;
using EzyRates.Tests.Concepts.RatesApi.Mapper;
using FluentAssertions;

namespace EzyRates.Tests.Concepts.RatesApi.GetRates.Mapper
{
    public class when_mapping_one_valid_rate : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate());
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel(ValidDateAsString, Rates);
        }

        [Observation]
        public void it_should_map_correctly_forex_model()
        {
            Result.UpdatedOn.Should().Be(ValidDate);
            Result.Currencies.Should().HaveCount(1);
        }

        [Observation]
        public void it_should_map_correctly_details_model()
        {
            var details = Result.Currencies.First().Details;

            details.Code.Should().Be("FakeCode");
            details.Name.Should().Be("FakeName");
        }

        [Observation]
        public void it_should_map_correctly_rate_model()
        {
            var rate = Result.Currencies.First().Rate;

            rate.Buy.Should().Be(0.0);
            rate.Sell.Should().Be(1.0);
            rate.Multiply.Should().Be(2);
        }

        [Observation]
        public void it_should_map_correctly_guide_model()
        {
            var guide = Result.Currencies.First().Guide;

            guide.From.Should().Be("FakeCurrencyGuideFrom");
            guide.To.Should().Be("FakeCurrencyGuideTo");
            guide.Amount.Should().Be(3);
            guide.Value.Should().Be(4.0);
        }
    }

    public class when_mapping_one_rate_with_invalid_date : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate());

            ScenarioExceptionsExpected = true;
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel("not-valid-date", Rates);
        }

        [Observation]
        public void it_should_throw_expection()
        {
            ScenarioException.Should().BeOfType<FormatException>();
        }
    }

    public class when_mapping_one_rate_with_invalid_buy_rate : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate(buyRate: "not-valid-double"));

            ScenarioExceptionsExpected = true;
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel(ValidDateAsString, Rates);
        }

        [Observation]
        public void it_should_throw_expection()
        {
            ScenarioException.Should().BeOfType<FormatException>();
        }
    }

    public class when_mapping_one_rate_with_invalid_sell_rate : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate(sellRate: "not-valid-double"));

            ScenarioExceptionsExpected = true;
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel(ValidDateAsString, Rates);
        }

        [Observation]
        public void it_should_throw_expection()
        {
            ScenarioException.Should().BeOfType<FormatException>();
        }
    }

    public class when_mapping_one_rate_with_invalid_multiply : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate(multiply: "not-valid-int"));

            ScenarioExceptionsExpected = true;
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel(ValidDateAsString, Rates);
        }

        [Observation]
        public void it_should_throw_expection()
        {
            ScenarioException.Should().BeOfType<FormatException>();
        }
    }

    public class when_mapping_one_rate_with_invalid_currency_guide_amount : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate(currencyGuideAmount: "not-valid-int"));

            ScenarioExceptionsExpected = true;
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel(ValidDateAsString, Rates);
        }

        [Observation]
        public void it_should_throw_expection()
        {
            ScenarioException.Should().BeOfType<FormatException>();
        }
    }

    public class when_mapping_one_rate_with_invalid_currency_guide_value : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate(currencyGuideValue: "not-valid-double"));

            ScenarioExceptionsExpected = true;
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel(ValidDateAsString, Rates);
        }

        [Observation]
        public void it_should_throw_expection()
        {
            ScenarioException.Should().BeOfType<FormatException>();
        }
    }
}