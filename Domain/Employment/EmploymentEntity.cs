namespace Domain.Employment
{
    public class EmploymentEntity
    {
        public Guid Id { get; set; }
        public string Employer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
