using Domain.Shared;

namespace Domain.School
{
    public class School
    {
        public Guid Id { get; set; }
        public List<SchoolName> SchoolName { get; set; }
        public List<CourseName> Course { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime EndDate { get; set; }
        public List<SchoolText> Text { get; set; }
    }
}
