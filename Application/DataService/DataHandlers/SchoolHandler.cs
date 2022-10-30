using Domain.School;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.DataService.DataHandlers
{
    public class SchoolHandler
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private readonly string _cacheKey = "school";

        public SchoolHandler(IMemoryCache cache, DataContext context)
        {
            _cache = cache;
            _context = context;
        }

        /// <summary>
        /// Get all school items
        /// </summary>
        public async Task<List<School>> GetAll()
        {
            var result = _cache.Get<List<School>>(_cacheKey);
            if (result == null || result.Count == 0) return await updateCache();
            return result;
        }


        /// <summary>
        /// Add singel school items
        /// </summary>
        /// <param name="school">school data model</param>
        public async Task AddSingleSchool(School school)
        {
            await _context.School.AddAsync(school);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        /// <summary>
        /// Update a single school item
        /// </summary>
        /// <param name="school">school data model</param>
        public async Task UpdateSchool(School school)
        {
            _context.School.Update(school);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        /// <summary>
        /// Delete a school item
        /// </summary>
        /// <param name="id">id of school entity</param>
        public async Task DeleteSchool(Guid id)
        {
            var school = await _context.School.FindAsync(id);
            _context.School.Remove(school);
            await _context.SaveChangesAsync();
            await updateCache();
        }

        /// <summary>
        /// Performs a query on all school entities and stores in cache
        /// Returns list of schools
        /// </summary>
        /// <returns></returns>
        private async Task<List<School>> updateCache()
        {
            var result = await queryAllSchools();
            _cache.Set(_cacheKey, result);
            return result;
        }

        /// <summary>
        /// Query all school entities
        /// </summary>
        private async Task<List<School>> queryAllSchools()
        {
            return await _context.School.Select(x => new School
            {
                Id = x.Id,
                SchoolName = x.SchoolName.Select(s => new SchoolName
                {
                    Id = s.Id,
                    Code = s.Code,
                    Content = s.Content,
                }).ToList(),
                Course = x.Course.Select(x => new CourseName
                {
                    Id = x.Id,
                    Code = x.Code,
                    Content = x.Content,
                }).ToList(),
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Text = x.Text.Select(s => new SchoolText
                {
                    Id = s.Id,
                    Code = s.Code,
                    Content= s.Content,
                }).ToList()
            }).AsSplitQuery().ToListAsync();
        }
    }
}
