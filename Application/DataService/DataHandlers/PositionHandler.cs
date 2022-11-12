using Application.Mapper;
using Domain.Employment;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DataService.DataHandlers
{
    internal class PositionHandler
    {
        private readonly DataContext _context;

        public PositionHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PositionEntity>> GetEntities(Guid parentId)
        {
            var result = await _context.Position.Where(x => x.EmploymentId == parentId).Select(x => new PositionEntity
            {
                Id = x.Id,
                Type = x.Type,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                
                Header = x.Header.Select(h => new PositionHeader
                {
                    Id = h.Id,
                    Code = h.Code,
                    Content = h.Content,
                }).ToList(),

                Text = x.Text.Select(t => new PositionText
                {
                    Id = t.Id,
                    Code = t.Code,
                    Content = t.Content,
                }).ToList(),

                EmploymentId = x.EmploymentId,

            }).AsSplitQuery().ToListAsync();

            return result;
        }

        public async Task<List<PositionDto>> GetDtos(Guid parentId)
        {
            var entities = await GetEntities(parentId);
            var dtos = new List<PositionDto>();

            foreach (var entity in entities)
            {
                dtos.Add(EmploymentPositionMapper.MapToDto(entity));
            }

            return dtos;
        }

        public async Task Update(List<PositionEntity> entities, Guid parentId)
        {
            var existing = await GetEntities(parentId);

            foreach (var item in entities)
            {
                var itemExist = existing.Find(x => x.Id == item.Id) != null;

                if (itemExist)
                {
                    existing = existing.Where(x => x.Id != item.Id).ToList();
                    _context.Position.Update(item);
                }
                else
                {
                    await _context.Position.AddAsync(item);
                }
            }

            _context.Position.RemoveRange(existing);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(List<PositionEntity> entities)
        {
            _context.Position.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
