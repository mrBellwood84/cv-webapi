using Domain.Shared;

namespace Domain.Skill
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SvgUrl { get; set; }
        public int Rating { get; set; }
        public List<SkillText> Text { get; set; }
    }
}
