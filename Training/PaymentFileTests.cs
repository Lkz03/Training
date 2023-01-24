using System.IO.Compression;
using System.Xml.Serialization;
using Training.Objects.Payment;

namespace Training
{
    public class PaymentFileTests
    {
        private PaymentFile paymentFile;

        [SetUp]
        public void Setup()
        {
            var zip = ZipFile.OpenRead(@"C:\\Users\\AndriusBogda\\Downloads\\SNC_AOD_01102023_061442.xml.zip");
            var e = zip.GetEntry("SNC_AOD_01102023_061442.xml");
            var xml = e.Open();


            using (TextReader reader = new StreamReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PaymentFile));
                paymentFile = (PaymentFile)serializer.Deserialize(reader);
            }
        }

        [Test]
        public void ValidateSumOfPaidAmounts()
        {
            foreach (var plan in paymentFile.PaymentDetail.ReimbursementEOB.PlanBalanceTable.PlanDetails)
            {
                Assert.IsTrue(plan.SubmittedClaims == plan.PaidAmount  + plan.PendingAmount - plan.DeniedAmount, "The amount paid is less than the claim");
            }
        }
    }
}