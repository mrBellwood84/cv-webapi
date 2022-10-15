using Application.DataService.DataHandlers;

namespace Application.DataService
{
    public interface IDataService
    {
        EmploymentHandler Employment { get; }
        ExperienceHandler Experience { get; }
        PortfolioHandler Portfolio { get; }
        SchoolHandler School { get; }
        SkillHandler Skill { get; }
    }
}