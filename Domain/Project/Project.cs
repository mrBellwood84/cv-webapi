using Domain.Shared;
using Domain.Skill;

namespace Domain.Project
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SkillShort> Languages { get; set; }
        public List<SkillShort> Frameworks { get; set; }
        public List<TextLocale> Text { get; set; }
        public string LinkWebsiteUrl { get; set; }
        public string LinkRepoUrl { get; set; }

    }
}
