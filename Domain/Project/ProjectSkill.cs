
namespace Domain.Skill
{
    public class ProjectSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SvgUrl { get; set; }
    }
    
    public class FrameworkSkillEntity : ProjectSkill
    {
        public Guid ProjectId { get; set; }
    }
    public class LanguageSkillEntity : ProjectSkill
    {
        public Guid ProjectId { set; get; }
    }
}
