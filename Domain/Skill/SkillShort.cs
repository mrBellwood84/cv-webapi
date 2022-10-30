
namespace Domain.Skill
{
    public class SkillShort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SvgUrl { get; set; }
    }
    
    public class FrameworkSkill : SkillShort { }
    public class LanguageSkill : SkillShort { }
}
