using Domain.Project;
using Domain.Shared;
using Domain.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataService.DataHandlers
{
    public class PortfolioHandler
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private readonly string _cacheKey = "portfolio";

        public PortfolioHandler(IMemoryCache cache, DataContext context)
        {
            _cache = cache;
            _context = context;
        }

        public async Task<List<Project>> GetAll()
        {
            var result = _cache.Get<List<Project>>(_cacheKey);
            if (result == null || result.Count == 0) return await updateCache();
            return result;
        }

        public async Task AddSingle(Project dto)
        {
            await _context.Project.AddAsync(dto);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task UpdateSingle(Project dto)
        {
            _context.Project.Update(dto);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task DeleteSingle(Guid id)
        {
            var item = await _context.Project.FindAsync(id);
            _context.Project.Remove(item);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        private async Task<List<Project>> updateCache()
        {
            var result = await queryAllPortfolio();
            _cache.Set(_cacheKey, result);
            return result;

        }

        private async Task<List<Project>> queryAllPortfolio()
        {

            return await _context.Project.Select(p => new Project
            {
                Id = p.Id,
                Name = p.Name,
                LinkRepoUrl = p.LinkRepoUrl,
                LinkWebsiteUrl = p.LinkWebsiteUrl,

                Text = p.Text.Select(t => new TextLocale
                {
                    Id = t.Id,
                    Code = t.Code,
                    Content = t.Content,
                }).ToList(),

                Frameworks = p.Frameworks.Select(f => new SkillShort
                {
                    Id = f.Id,
                    Name = f.Name,
                    SvgUrl = f.SvgUrl,
                }).ToList(),

                Languages = p.Languages.Select(f => new SkillShort
                {
                    Id = f.Id,
                    Name = f.Name,
                    SvgUrl = f.SvgUrl,
                }).ToList(),

            }).AsSplitQuery().ToListAsync();

        }
    }
}
