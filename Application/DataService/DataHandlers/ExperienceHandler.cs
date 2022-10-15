using Domain.Experience;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.DataService.DataHandlers
{
    public class ExperienceHandler
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private readonly string _cacheKeyEduc = "education";
        private readonly string _cachceKeyOther = "other";

        public ExperienceHandler(IMemoryCache cache, DataContext dataContext)
        {
            _cache = cache;
            _context = dataContext;
        }

        public async Task<List<Experience>> GetAllEducationExperiences()
        {
            var result = _cache.Get<List<Experience>>(_cacheKeyEduc);
            if (result == null || result.Count == 0)  return await updateEducationExperienceCache();
            return result;
        }

        public async Task<List<Experience>> GetAllOtherExperiences()
        {
            var result = _cache.Get<List<Experience>>(_cachceKeyOther);
            if (result == null || result.Count == 0) return await updateOtherExperienceCache();
            return result.ToList();
        }

        public async Task AddSingleExperience(Experience experience)
        {
            await _context.Experience.AddAsync(experience);
            await _context.SaveChangesAsync();
            if (experience.Type == _cacheKeyEduc) await updateEducationExperienceCache();
            if (experience.Type == _cachceKeyOther) await updateOtherExperienceCache();
        }

        public async Task UpdateExperience(Experience experience)
        {
            _context.Experience.Update(experience);
            await _context.SaveChangesAsync();
            if (experience.Type == _cacheKeyEduc) await updateEducationExperienceCache();
            if (experience.Type == _cachceKeyOther) await updateOtherExperienceCache();
        }

        public async Task DeleteExperience(Guid id)
        {
            var exp = await _context.Experience.FindAsync(id);
            _context.Experience.Remove(exp);
            await _context.SaveChangesAsync();
            if (exp.Type == _cacheKeyEduc) await updateEducationExperienceCache();
            if (exp.Type == _cachceKeyOther) await updateOtherExperienceCache();
        }

        private async Task<List<Experience>> updateEducationExperienceCache()
        {
            var exp = await queryExperience(_cacheKeyEduc);
            _cache.Set(_cacheKeyEduc, exp);
            return exp;
        }

        private async Task<List<Experience>> updateOtherExperienceCache()
        {
            var exp = await queryExperience(_cachceKeyOther);
            _cache.Set(_cachceKeyOther, exp);
            return exp;
        }

        private async Task<List<Experience>> queryExperience(string typestring)
        {
            return await _context.Experience
                .Where(e => e.Type == typestring)
                .Select(e => new Experience
                {
                    Id = e.Id,
                    Type = e.Type,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Header = e.Header.Select(h => new TextLocale
                    {
                        Id = h.Id,
                        Code = h.Code,
                        Content = h.Content,
                    }).ToList(),
                    Subheader = e.Subheader.Select(s => new TextLocale
                    {
                        Id= s.Id,
                        Code= s.Code,
                        Content = s.Content,
                    }).ToList(),
                    Text = e.Text.Select(t => new TextLocale
                    {
                        Id= t.Id,
                        Code = t.Code,
                        Content= t.Content,
                    }).ToList(),

                }).AsSplitQuery().ToListAsync();
        }

    }
}
