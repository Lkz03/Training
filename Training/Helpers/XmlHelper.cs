using System.Xml.Serialization;
using Training.Objects.Payment;

namespace Training.Helpers
{
    internal static class XmlHelper
    {
        internal static T Deserialize<T>(Stream xml)
        {
            using (TextReader reader = new StreamReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PaymentFile));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
