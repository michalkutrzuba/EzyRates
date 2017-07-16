using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EzyRates.Web.Infrastructure
{
    public interface IXmlSerializerWrapper
    {
        T Deserialize<T>(string xml) where T: class;
    }

    public class XmlSerializerWrapper : IXmlSerializerWrapper
    {
        public T Deserialize<T>(string xml) where T : class
        {
            if (string.IsNullOrEmpty(xml))
                return null;

            var xmlserializer = new XmlSerializer(typeof(T));
            
            using (var stringReader = new StringReader(xml))
            using (var reader = XmlReader.Create(stringReader))
            {
                return (T) xmlserializer.Deserialize(reader);
            }
        }
    }
}