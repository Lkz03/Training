namespace Training.Objects.Payment.Tables.TableObjects
{
    public class PlanDetail
    {
        public string PlanName { get; set; }
        public decimal EligibleAmount { get; set; }
        public string IgnoreEligibleAmount { get; set; }
        public decimal SubmittedClaims { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal PendingAmount { get; set; }
        public decimal DeniedAmount { get; set; }
        public decimal PlanYearBalance { get; set; }
        public string IgnorePlanYearBalance { get; set; }
        public decimal YTDContributionAmount { get; set; }
    }
}
