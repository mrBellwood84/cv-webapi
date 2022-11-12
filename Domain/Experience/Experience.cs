using Domain.Shared;

namespace Domain.Experience
{
    public class Experience
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ExperienceHeader> Header { get; set; }
        public List<ExperienceSubheader> Subheader { get; set; }
        public List<ExperienceText> Text { get; set; }    
    }
}
