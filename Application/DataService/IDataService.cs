using Application.DataService.DataHandlers;

namespace Application.DataService
{
    public interface IDataService
    {
        EmploymentHandler Employment { get; }
        ExperienceHandler Experience { get; }
        ProjectHandler Portfolio { get; }
        SchoolHandler School { get; }
        SkillHandler Skill { get; }
    }
}