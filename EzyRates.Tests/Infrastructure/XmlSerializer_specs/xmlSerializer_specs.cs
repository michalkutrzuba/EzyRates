using EzyRates.Web.Infrastructure;
using FluentAssertions;

namespace EzyRates.Tests.Infrastructure.XmlSerializer_specs
{
    public class when_serialized_object_is_correct : XmlSerializerContext
    {
        protected override void BecauseOf()
        {
            Result = Wrapper.Deserialize<FakeXml>("<FakeXml><FakeProperty>FakeValue</FakeProperty></FakeXml>");
        }

        [Observation]
        public void it_should_be_correctly_deserialized()
        {
            Result.FakeProperty.Should().Be("FakeValue");
        }
    }

    public class when_serialized_object_does_not_exist : XmlSerializerContext
    {
        protected override void BecauseOf()
        {
            Result = Wrapper.Deserialize<FakeXml>(null);
        }

        [Observation]
        public void it_should_be_null()
        {
            Result.Should().BeNull();
        }
    }
 
    public class when_serialized_object_is_empty : XmlSerializerContext
    {
        protected override void BecauseOf()
        {
            Result = Wrapper.Deserialize<FakeXml>(string.Empty);
        }

        [Observation]
        public void it_should_be_null()
        {
            Result.Should().BeNull();
        }
    }

    public abstract class XmlSerializerContext : Specification
    {
        protected IXmlSerializerWrapper Wrapper;
        protected FakeXml Result;

        protected override void EstablishContext()
        {
            Wrapper = new XmlSerializerWrapper();
        }
    }

    public class FakeXml
    {
        public string FakeProperty { get; set; }
    }
}