
using Application.Mapper;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DataService.DataHandlers
{
    internal class ReferenceHandler
    {
        private readonly DataContext _context;

        public ReferenceHandler(DataContext context)
        {
            _context= context;
        }

        public async Task<List<ReferenceEntity>> GetEntities(Guid parentId)
        {
            var result = await _context.Reference.Where(x => x.EmploymentId == parentId).Select(r => new ReferenceEntity
            {
                Id = r.Id,
                Name = r.Name,
                Role = r.Role.Select(t => new ReferenceText
                {
                    Id = t.Id,
                    Code = t.Code,
                    Content = t.Content,
                }).ToList(),
                Phonenumber = r.Phonenumber,
                Email = r.Email,
                EmploymentId = r.EmploymentId,
            }).AsSplitQuery().ToListAsync();

            return result;
        }

        public async Task<List<ReferenceDto>> GetDtos(Guid parentId)
        {
            var entities = await GetEntities(parentId);
            var dtos = new List<ReferenceDto>();

            foreach (var entity in entities)
            {
                dtos.Add(ReferenceMapper.MapToDto(entity));
            }

            return dtos;
        }

        public async Task Update(List<ReferenceEntity> entities, Guid parentId)
        {
            var existing = await GetEntities(parentId);

            foreach (var entity in entities)
            {

                var itemExist = existing.Find(x => x.Id == entity.Id) != null;

                if (itemExist)
                {
                    existing = existing.Where(x => x.Id != entity.Id).ToList();
                    _context.Reference.Update(entity);
                }
                else
                {
                    await _context.Reference.AddAsync(entity);
                }
            }

            var t1 = existing;
            var t2 = entities;

            _context.Reference.RemoveRange(existing);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(List<ReferenceEntity> entities)
        {
            _context.Reference.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
