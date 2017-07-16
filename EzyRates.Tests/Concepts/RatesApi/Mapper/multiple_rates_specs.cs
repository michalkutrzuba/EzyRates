using System;
using System.Linq;
using FluentAssertions;

namespace EzyRates.Tests.Concepts.RatesApi.Mapper
{
    public class when_mapping_two_valid_rates : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate(currencyCode: "FakeCode1"));
            Rates.Add(CreateRate(currencyCode: "FakeCode2"));
        }

        protected override void BecauseOf()
        {
            Result = Mapper.MapToJsonModel(ValidDateAsString, Rates);
        }

        [Observation]
        public void it_should_map_both_rates()
        {
            Result.UpdatedOn.Should().Be(ValidDate);
            Result.Currencies.Should().HaveCount(2);
            Result.Currencies.First().Details.Code.Should().Be("FakeCode1");
            Result.Currencies.Last().Details.Code.Should().Be("FakeCode2");
        }
    }

    public class when_mapping_one_valid_and_one_invalid_rate : CurrencyMapperContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            Rates.Add(CreateRate(currencyCode: "FakeCode1"));
            Rates.Add(CreateRate(currencyCode: "FakeCode2", buyRate: "invalid-rate"));

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