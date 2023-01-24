using Training.Helpers;
using Training.Objects.Payment;

namespace Training
{
    public class PaymentFileTests
    {
        private PaymentFile paymentFile;

        [SetUp]
        public void Setup()
        {
            paymentFile = XmlHelper.Deserialize<PaymentFile>(
                ZipHelper.OpenFile(
                @"C:\\Users\\AndriusBogda\\Downloads\\SNC_AOD_01102023_061442.xml.zip",
                "SNC_AOD_01102023_061442.xml"));
        }

        [Test]
        public void ValidateSumOfPaidAmounts()
        {
            decimal sumOfPaidAmounts = 0;
            var expectedSum = 3.49;

            foreach (var plan in paymentFile.PaymentDetail.ReimbursementEOB.PlanBalanceTable.PlanDetails)
            {
                sumOfPaidAmounts += plan.PaidAmount;
            }

            Assert.That(sumOfPaidAmounts, Is.EqualTo(expectedSum), "The amount paid is less than expected");
        }
    }
}