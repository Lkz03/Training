namespace Training.Objects
{
    public class Plan
    {
        public int EmployeeIdentifier { get; set; }
        public DateOnly ContributionDate { get; set; }
        public string ContributionDescription { get; set; }
        public decimal ContributionAmount { get; set; }
        public string PlanName { get; set; }
        public string PriorTaxYear { get; set; }

        public Plan(string id, string date, string desc, string amount, string name, string taxYear)
        {
            EmployeeIdentifier = Int32.Parse(id);
            ContributionDate = DateOnly.Parse(date.Insert(2, "-").Insert(5, "-"));
            ContributionDescription = desc;
            ContributionAmount = Decimal.Parse(amount);
            PlanName = name;
            PriorTaxYear = taxYear;
        }
    }
}
