using System.Xml.Serialization;
using Training.Objects.Payment.Tables.TableObjects;

namespace Training.Objects.Payment.Tables
{
    public class TransactionTable
    {
        public string TransactionHeader { get; set; }

        [XmlElement("TransactionDetail")]
        public TransactionDetail[] TransactionDetails { get; set; }
    }
}
