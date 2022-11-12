using Domain.Shared;

namespace Domain.Employment
{
    public class EmploymentDto
    {
        public Guid Id { get; set; }
        public string Employer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PositionDto> Positions  { get; set; }
        public List<ReferenceDto> References { get; set; }
    }
}
