using Application.Mapper;
using Domain.Project;
using Domain.Shared;
using Domain.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.DataService.DataHandlers
{
    public class ProjectHandler
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private readonly string _cacheKey = "portfolio";
        private readonly ProjectSkillHandler _skillHandler;

        public ProjectHandler(IMemoryCache cache, DataContext context)
        {
            _cache = cache;
            _context = context;
            _skillHandler = new ProjectSkillHandler(context);
        }

        public async Task<List<ProjectDto>> GetAll()
        {
            var result = _cache.Get<List<ProjectDto>>(_cacheKey);
            if (result == null || result.Count == 0) return await updateCache();
            return result;
        }

        public async Task AddSingle(ProjectDto dto)
        {
            var entity = ProjectMapper.MapToEntity(dto); ;
            var frameworks = ProjectSkillMapper.MapToFrameworkSkillEntityList(dto.Frameworks, dto.Id);
            var languages = ProjectSkillMapper.MapToLanguageSkillEntityList(dto.Languages, dto.Id);

            await _context.Project.AddAsync(entity);
            await _skillHandler.AddFrameworkSkills(frameworks);
            await _skillHandler.AddLanguageSkills(languages);

            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task UpdateSingle(ProjectDto dto)
        {
            var project = ProjectMapper.MapToEntity(dto);
            var frameworks = ProjectSkillMapper.MapToFrameworkSkillEntityList(dto.Frameworks, dto.Id);
            var languages = ProjectSkillMapper.MapToLanguageSkillEntityList(dto.Languages, dto.Id);


            _context.Project.Update(project);
            await _skillHandler.UpdateFrameworkSkills(frameworks, project.Id);
            await _skillHandler.UpdateLanguageSkills(languages, project.Id);

            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task DeleteSingle(Guid id)
        {
            var project = await _context.Project.FindAsync(id);
            var frameworks = await _skillHandler.GetFrameworkEntities(id);
            var languages = await _skillHandler.GetLanguageEntities(id);

            _context.Project.Remove(project);
            _context.FrameworkSkill.RemoveRange(frameworks);
            _context.LanguageSkill.RemoveRange(languages);

            await _context.SaveChangesAsync(); 
            await updateCache();
        }

        private async Task<List<ProjectDto>> updateCache()
        {
            var result = await QueryAllProjects();
            _cache.Set(_cacheKey, result);
            return result;

        }

        private async Task<List<ProjectDto>> QueryAllProjects()
        {
            var result = await _context.Project.Select(p => new ProjectDto
            {
                Id = p.Id,
                ProjectName = p.ProjectName,
                RepoUrl = p.RepoUrl,
                WebsiteUrl = p.WebsiteUrl,

                Text = p.Text.Select(t => new ProjectText
                {
                    Id = t.Id,
                    Code = t.Code,
                    Content = t.Content,
                }).ToList(),

            }).AsSplitQuery().ToListAsync();

            result.ForEach(async p =>
            {
                p.Frameworks = await _skillHandler.GetFrameworkSkillAsDto(p.Id);
                p.Languages = await _skillHandler.GetLanguagesAsDto(p.Id);
            });

            return result;

        }
    }
}
