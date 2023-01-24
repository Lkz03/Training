using System.Xml.Serialization;
using Training.Objects.Payment.Tables.TableObjects;

namespace Training.Objects.Payment.Tables
{
    public class PlanBalanceTable
    {
        [XmlElement("PlanDetail")]
        public PlanDetail[] PlanDetails { get; set; }
    }
}
