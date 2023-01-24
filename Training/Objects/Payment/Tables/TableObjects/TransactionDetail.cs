namespace Training.Objects.Payment.Tables.TableObjects
{
    public class TransactionDetail
    {
        public string PlanName { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public DateTime ReimbursementDate { get; set; }
        public int BatchNumber { get; set; }
        public string ClaimNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal PendingAmount { get; set; }
        public decimal DeniedAmount { get; set; }
        public decimal AmountThisCycle { get; set; }
        public string MerchantProvider { get; set; }
    }
}
