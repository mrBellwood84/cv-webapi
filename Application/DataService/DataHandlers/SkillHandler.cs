using Domain.Shared;
using Domain.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;


namespace Application.DataService.DataHandlers
{
    public class SkillHandler
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private readonly string _cacheKey = "skill";

        public SkillHandler(IMemoryCache cache, DataContext context)
        {
            _cache = cache;
            _context = context;
        }

        public async Task<List<Skill>> GetAll()
        {
            var result = _cache.Get<List<Skill>>(_cacheKey);
            if (result == null || result.Count == 0) return await updateCache();
            return result;
        }

        public async Task AddSingle(Skill skill)
        {
            await _context.Skill.AddAsync(skill);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task UpdateSingle(Skill skill)
        {
            _context.Skill.Update(skill);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task DeleteSingle(Guid id)
        {
            var item = await _context.Skill.FindAsync(id);
            _context.Skill.Remove(item);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        private async Task<List<Skill>> updateCache()
        {
            var result = await queryAllSkills();
            _cache.Set(_cacheKey, result);
            return result;
        }

        public async Task<List<Skill>> queryAllSkills()
        {
            return await _context.Skill.Select(s => new Skill
            {
                Id = s.Id,
                Type = s.Type,
                Name = s.Name,
                SvgUrl = s.SvgUrl,
                Rating = s.Rating,
                Text = s.Text.Select(t => new SkillText
                {
                    Id = t.Id,
                    Code = t.Code,
                    Content = t.Content,
                }).ToList(),

            }).AsSplitQuery().ToListAsync();
        }
    }
}
