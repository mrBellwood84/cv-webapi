using Application.Mapper;
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

        private readonly PositionHandler _positionHandler;
        private readonly ReferenceHandler _referenceHandler;

        public EmploymentHandler(IMemoryCache cache, DataContext context)
        {
            _cache = cache;
            _context = context;
            _positionHandler = new PositionHandler(context);
            _referenceHandler = new ReferenceHandler(context);
        }

        /// <summary>
        /// Retrive employment dto's from cache.
        /// If no data was found in cache, method runs updateCache method and return result.
        /// </summary>
        /// <returns>
        /// List of employment dto's
        /// </returns>
        public async Task<List<EmploymentDto>> GetAll()
        {
            var result = _cache.Get<List<EmploymentDto>>(_cacheKey);
            if (result == null || result.Count == 0) return await UpdateCache();
            return result;
        }

        public async Task AddSingle(EmploymentDto employment)
        {
            // add employment entity
            var employmentEntity = EmploymentMapper.mapToEntity(employment);

            var positions = new List<PositionEntity>();
            foreach (var item in employment.Positions)
            {
                var entity = EmploymentPositionMapper.MapToEntity(item, employment.Id);
                positions.Add(entity);
            }

            var references = new List<ReferenceEntity>();
            foreach(var item in employment.References)
            {
                var entity = ReferenceMapper.MapToEntity(item, employment.Id);
                references.Add(entity);
            }

            await _context.Employment.AddAsync(employmentEntity);
            await _context.Position.AddRangeAsync(positions);
            await _context.Reference.AddRangeAsync(references);

            await _context.SaveChangesAsync();

            await UpdateCache();
        }

        public async Task UpdateSingle(EmploymentDto employment)
        {
            var employmentEntity = EmploymentMapper.mapToEntity(employment);

            var positions = new List<PositionEntity>();
            foreach (var item in employment.Positions)
            {
                var entity = EmploymentPositionMapper.MapToEntity(item, employment.Id);
                positions.Add(entity);
            }

            var references = new List<ReferenceEntity>();
            foreach (var item in employment.References)
            {
                var entity = ReferenceMapper.MapToEntity(item, employment.Id);
                references.Add(entity);
            }

            _context.Employment.Update(employmentEntity);
            await _positionHandler.Update(positions, employment.Id);
            await _referenceHandler.Update(references, employment.Id);

            await _context.SaveChangesAsync();

            await UpdateCache();
        }

        public async Task DeleteSingle(Guid id)
        {
            var employment = await _context.Employment.FindAsync(id);
            var positions = await _context.Position.Where(x => x.EmploymentId == id).ToListAsync();
            var references = await _context.Reference.Where(x => x.EmploymentId == id).ToListAsync();

            _context.Employment.Remove(employment);
            _context.Position.RemoveRange(positions);
            _context.Reference.RemoveRange(references);

            await _context.SaveChangesAsync();

            await UpdateCache();
        }

        /// <summary>
        /// Get all employment dto's with method.
        /// Store query result in cache and return result
        /// </summary>
        /// <returns>
        /// List of employment dto's
        /// </returns>
        private async Task<List<EmploymentDto>> UpdateCache()
        {
            var dtoList = await QueryAllEmployment();
            _cache.Set(_cacheKey, dtoList);
            return dtoList;
        }

        /// <summary>
        /// Query datacontext for all employment entities and collect as dto's
        /// </summary>
        /// <returns>
        /// List of employment dto's
        /// </returns>
        private async Task<List<EmploymentDto>> QueryAllEmployment()
        {
            var result = await _context.Employment.Select(e => new EmploymentDto
            {
                Id = e.Id,
                Employer = e.Employer,
                StartDate = e.StartDate,
                EndDate = e.EndDate,

            }).AsSplitQuery().ToListAsync();

            result.ForEach(async e =>
            {
                e.Positions = await _positionHandler.GetDtos(e.Id);
                e.References = await _referenceHandler.GetDtos(e.Id);
            });

            return result;
        }
        
    }
}
