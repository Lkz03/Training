using Training.Objects.Payment.Tables;

namespace Training.Objects.Payment
{
    public class ReimbursementEOB
    {
        public TransactionTable TransactionTable { get; set; }
        public PlanBalanceTable PlanBalanceTable { get; set; }
    }
}
