using Application.Mapper;
using Domain.Skill;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DataService.DataHandlers
{
    internal class ProjectSkillHandler
    {
        private readonly DataContext _context;

        public ProjectSkillHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<FrameworkSkillEntity>> GetFrameworkEntities(Guid parentId)
        {
            return await _context.FrameworkSkill.Where(e => e.ProjectId == parentId).Select(s => new FrameworkSkillEntity
            {
                Id = s.Id,
                Name = s.Name,
                SvgUrl = s.SvgUrl,
                ProjectId = s.ProjectId,
            }).AsSplitQuery().ToListAsync();
        }

        public async Task<List<LanguageSkillEntity>> GetLanguageEntities(Guid parentId)
        {
            return await _context.LanguageSkill.Where(e => e.ProjectId == parentId).Select(s => new LanguageSkillEntity
            {
                Id = s.Id,
                Name = s.Name,
                SvgUrl = s.SvgUrl,
                ProjectId = s.ProjectId,
            }).AsSplitQuery().ToListAsync();
        }

        public async Task<List<ProjectSkill>> GetFrameworkSkillAsDto(Guid parentId)
        {
            var entities = await GetFrameworkEntities(parentId);
            var dtos = new List<ProjectSkill>();

            foreach (var entity in entities)
            {
                dtos.Add(ProjectSkillMapper.MapToDto(entity));
            }

            return dtos;
        }

        public async Task<List<ProjectSkill>> GetLanguagesAsDto(Guid parentId)
        {
            var entities = await GetLanguageEntities(parentId);
            var dtos = new List<ProjectSkill>();

            foreach(var entity in entities)
            {
                dtos.Add(ProjectSkillMapper.MapToDto(entity));
            }

            return dtos;
        }

        public async Task AddFrameworkSkills(List<FrameworkSkillEntity> entities)
        {
            await _context.FrameworkSkill.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task AddLanguageSkills(List<LanguageSkillEntity> entities)
        {
            await _context.LanguageSkill.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFrameworkSkills(List<FrameworkSkillEntity> entities, Guid parentId)
        {
            var existing = await GetFrameworkEntities(parentId);

            foreach (var entity in entities)
            {
                var itemExist = existing.Find(x => x.Id == entity.Id) != null;

                if (itemExist)
                {
                    existing = existing.Where(x => x.Id != entity.Id).ToList();
                    _context.FrameworkSkill.Update(entity);
                }
                else
                {
                    await _context.FrameworkSkill.AddAsync(entity);
                }

                _context.FrameworkSkill.RemoveRange(existing);

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateLanguageSkills(List<LanguageSkillEntity> entities, Guid parentId)
        {
            var existing = await GetLanguageEntities(parentId);

            foreach(var entity in entities)
            {
                var itemExist = existing.Find(x => x.Id == entity.Id) != null;

                if (itemExist)
                {
                    existing = existing.Where(x => x.Id != entity.Id).ToList();
                    _context.LanguageSkill.Update(entity);
                }
                else
                {
                    await _context.LanguageSkill.AddAsync(entity);
                }

                _context.LanguageSkill.RemoveRange(existing);

                await _context.SaveChangesAsync();
            }
        }
    }
}
