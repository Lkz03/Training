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
            using (TextReader reader = new StreamReader(@"C:\Users\AndriusBogda\Downloads\SNC_AOD_01102023_061442.xml"))
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