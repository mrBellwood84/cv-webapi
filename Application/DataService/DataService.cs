using Application.DataService.DataHandlers;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.DataService
{
    public class DataService : IDataService
    {

        public DataService(DataContext context, IMemoryCache cache)
        {
            Employment = new EmploymentHandler(cache, context);
            Experience = new ExperienceHandler(cache, context);
            Portfolio = new PortfolioHandler(cache, context);
            School = new SchoolHandler(cache, context);
            Skill = new SkillHandler(cache, context);
        }

        public EmploymentHandler Employment { get; }
        public ExperienceHandler Experience { get; }
        public PortfolioHandler Portfolio { get; }
        public SchoolHandler School { get; }
        public SkillHandler Skill { get; }
    }
}
