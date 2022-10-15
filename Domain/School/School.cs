using Domain.Shared;

namespace Domain.School
{
    public class School
    {
        public Guid Id { get; set; }
        public List<TextLocale> SchoolName { get; set; }
        public List<TextLocale> Course { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime EndDate { get; set; }
        public List<TextLocale> Text { get; set; }
    }
}
