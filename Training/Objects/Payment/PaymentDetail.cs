namespace Training.Objects.Payment
{
    public class PaymentDetail
    {
        public int PaymentID { get; set; }
        public string SourceAccountName { get; set; }
        public string SourceAccountAddressLine1 { get; set; }
        public string? SourceAccountAddressLine2 { get; set; }
        public string? SourceAccountAddressLine3 { get; set; }
        public string SourceAccountAddressCity { get; set; }
        public string SourceAccountAddressState { get; set; }
        public int SourceAccountAddressZipCode { get; set; }
        public string ConsumerIdentifierDisplayName { get; set; }
        public int ConsumerCommunicationId { get; set; }
        public int EMailIndicator { get; set; }
        public string ConsumerFirstName { get; set; }
        public string? ConsumerMiddleName { get; set; }
        public string ConsumerLastName { get; set; }
        public int ConsumerSSN { get; set; }
        public DateTime ConsumerDOB { get; set; }
        public string PayeeFullName { get; set; }
        public string PayeeAddressLine1 { get; set; }
        public string? PayeeAddressLine2 { get; set; }
        public string? PayeeAddressLine3 { get; set; }
        public string PayeeAddressCity { get; set; }
        public string PayeeAddressState { get; set; }
        public int PayeeAddressZipCode { get; set; }
        public string PayeeAddressCountryCode { get; set; }
        public string PayeeAddressCountryName { get; set; }
        public string Reprint { get; set; }
        public int PaymentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentAmountLongHand { get; set; }
        public string? CheckInformation { get; set; }
        public string LogoImage { get; set; }
        public string? SignatureImage { get; set; }
        public string EmployerName { get; set; }
        public int EmployerCode { get; set; }
        public string EmployerDivision { get; set; }
        public string BusinessParty { get; set; }
        public string AdministratorCode { get; set; }
        public string ContactAdministratorName { get; set; }
        public string ContactName { get; set; }
        public string ContactAddressLine1 { get; set; }
        public string? ContactAddressLine2 { get; set; }
        public string? ContactAddressLine3 { get; set; }
        public string ContactAddressCity { get; set; }
        public string ContactAddressState { get; set; }
        public int ContactAddressZipCode { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactTollFreeNumber { get; set; }
        public string ContactFaxNumber { get; set; }
        public string ContactEmailAddress { get; set; }
        public string CustomText { get; set; }
        public ReimbursementEOB ReimbursementEOB { get; set; }
        public ClaimForms ClaimForms { get; set; }
    }
}
