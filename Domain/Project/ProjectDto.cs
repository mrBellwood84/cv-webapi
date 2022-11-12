using Domain.Shared;
using Domain.Skill;

namespace Domain.Project
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectSkill> Languages { get; set; }
        public List<ProjectSkill> Frameworks { get; set; }
        public List<ProjectText> Text { get; set; }
        public string WebsiteUrl { get; set; }
        public string RepoUrl { get; set; }
    }


}
