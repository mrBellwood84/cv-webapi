using Domain.Employment;

namespace Application.Mapper
{
    internal static class EmploymentPositionMapper
    {
        public static PositionEntity MapToEntity(PositionDto dto, Guid parentId)
        {
            return new PositionEntity
            {
                Id = dto.Id,
                Type = dto.Type,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Header = dto.Header,
                Text = dto.Text,
                EmploymentId = parentId,
            };
        }
        
        public static PositionDto MapToDto(PositionEntity entity)
        {
            return new PositionDto
            {
                Id = entity.Id,
                Type = entity.Type,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Header = entity.Header,
                Text = entity.Text,
            };
        }

    }
}
