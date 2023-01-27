using Training.Objects.Enums;

namespace Training.Objects
{
    public class Plan : PlanObject<string>
    {
        private const decimal _maxAmount = 999999999.99M;
        private const decimal _minAmount = -999999999.99M;
        private const int _count = 6;

        private decimal _contributionAmount;
        private PriorTaxYear? _priorTaxYear;
        private DateOnly _contributionDate;

        protected override int Count => _count;

        public Plan(ICollection<string> values) : base(values)
        {
            EmployeeIdentifier = Int32.Parse(values.ElementAt(0));
            ContributionDate = values.ElementAt(1);
            ContributionDescription = values.ElementAt(2);
            PlanName = values.ElementAt(4);
            ContributionAmount = Decimal.Parse(values.ElementAt(3));
            PriorTaxYear = values.ElementAt(5);
        }

        public int EmployeeIdentifier { get; set; }
        public string ContributionDate 
        {
            get => _contributionDate.ToString("MMddyyyy");

            set
            {
                _contributionDate = DateOnly.ParseExact(value, "MMddyyyy");
            }
        }
        public string ContributionDescription { get; set; }
        public decimal ContributionAmount
        { 
            get => _contributionAmount;

            set
            {
                if (value < 0 && PlanName.ToLower().Contains("hsa"))
                {
                    throw new ArgumentException("Value may not be negative");
                }
                else if (value > _maxAmount || value < _minAmount)
                {
                    throw new ArgumentException("Value is out of bounds");
                }

                _contributionAmount = value;
            }
        }
        public string PlanName { get; set; }
        public string? PriorTaxYear
        {
            get => _priorTaxYear.ToString();

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                }
                else if (!PlanName.ToLower().Contains("hsa"))
                {
                    throw new ArgumentException("Only valid for HSA");
                }

                _priorTaxYear = (PriorTaxYear)Enum.Parse(typeof(PriorTaxYear), value);
            }
        }

        public List<string> ToList() => this._priorTaxYear.HasValue ?
            new List<string>{ EmployeeIdentifier.ToString(), ContributionDate.ToString(), ContributionDescription, ContributionAmount.ToString(), PlanName, PriorTaxYear.ToString() }:
            new List<string>{ EmployeeIdentifier.ToString(), ContributionDate.ToString(), ContributionDescription, ContributionAmount.ToString(), PlanName, "" };
    }
}
