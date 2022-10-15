using Domain.Shared;

namespace Domain.Experience
{
    public class Experience
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<TextLocale> Header { get; set; }
        public List<TextLocale> Subheader { get; set; }
        public List<TextLocale> Text { get; set; }    
    }
}
