using Domain.Employment;
using Domain.Experience;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;


namespace Application.DataService.DataHandlers
{
    public class EmploymentHandler
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private readonly string _cacheKey = "employment";

        public EmploymentHandler(IMemoryCache cache, DataContext context)
        {
            _cache = cache;
            _context = context;
        }

        public async Task<List<Employment>> GetAll()
        {
            var result = _cache.Get<List<Employment>>(_cacheKey);
            if (result == null || result.Count == 0) return await updateCache();
            return result;
        }

        public async Task AddSingle(Employment employment)
        {
            await _context.Employment.AddAsync(employment);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task UpdateSingle(Employment employment)
        {
            _context.Employment.Update(employment);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        public async Task DeleteSingle(Guid id)
        {
            var employment = await _context.Employment.FindAsync(id);
            _context.Employment.Remove(employment);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        private async Task<List<Employment>> updateCache()
        {
            var result = await queryAllEmployment();
            _cache.Set(_cacheKey, result);
            return result;
        }

        private async Task<List<Employment>> queryAllEmployment()
        {
            return await _context.Employment.Select(e => new Employment
            {
                Id = e.Id,
                Employer = e.Employer,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Positions = e.Positions.Select(p => new EmploymentExperience
                {
                    Id = p.Id,
                    Type = p.Type,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,

                    Header = p.Header.Select(t => new ExperienceHeader
                    {
                        Id = t.Id,
                        Code = t.Code,
                        Content = t.Content,
                    }).ToList(),

                    Subheader = p.Subheader.Select(t => new ExperienceSubheader
                    {
                        Id = t.Id,
                        Code = t.Code,
                        Content = t.Content,
                    }).ToList(),

                    Text = p.Text.Select(t => new ExperienceText
                    {
                        Id = t.Id,
                        Code = t.Code,
                        Content = t.Content,
                    }).ToList(),

                }).ToList(),

                References = e.References.Select(e => new Reference
                {
                    Id = e.Id,
                    Name = e.Name,
                    Role = e.Role.Select(t => new ReferenceText
                    {
                        Id = t.Id,
                        Code = t.Code,
                        Content = t.Content,
                    }).ToList(),
                    Phonenumber = e.Phonenumber,
                    Email = e.Email,

                }).ToList(),

            }).AsSplitQuery().ToListAsync();
        }

    }
}
