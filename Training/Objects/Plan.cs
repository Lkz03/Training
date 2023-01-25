using System;
using Training.Objects.Enums;

namespace Training.Objects
{
    public class Plan
    {
        private const decimal _maxAmount = 999999999.99M;
        private const decimal _minAmount = -999999999.99M;

        private decimal _contributionAmount;
        private PriorTaxYear _priorTaxYear;

        public int EmployeeIdentifier { get; set; }
        public DateOnly ContributionDate { get; set; }
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
        public PriorTaxYear? PriorTaxYear
        {
            get => _priorTaxYear;

            set
            {
                if (!PlanName.ToLower().Contains("hsa"))
                {
                    throw new ArgumentException("Only valid for HSA");
                }
            }
        }

        public Plan(string id, string date, string desc, string amount, string name, string taxYear)
        {
            EmployeeIdentifier = Int32.Parse(id);
            ContributionDate = DateOnly.Parse(date.Insert(2, "-").Insert(5, "-"));
            ContributionDescription = desc;
            PlanName = name;
            ContributionAmount = Decimal.Parse(amount);
            PriorTaxYear = (PriorTaxYear)Enum.Parse(typeof(PriorTaxYear), taxYear);
        }

        public List<string> ToList() => this.PriorTaxYear.HasValue ?
            new List<string>{ EmployeeIdentifier.ToString(), ContributionDate.ToString(), ContributionDescription, ContributionAmount.ToString(), PlanName, PriorTaxYear.ToString() }:
            new List<string>{ EmployeeIdentifier.ToString(), ContributionDate.ToString(), ContributionDescription, ContributionAmount.ToString(), PlanName, "" };
    }
}
