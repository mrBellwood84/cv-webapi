using Domain.Shared;


namespace Domain.Employment
{
    public class PositionDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<PositionHeader> Header { get; set; }
        public List<PositionText> Text { get; set; }
    }

    public class PositionEntity : PositionDto
    {
        public Guid EmploymentId { get; set; }
    }
}
