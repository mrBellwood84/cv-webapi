using Domain.Shared;

namespace Application.Mapper
{
    internal static class ReferenceMapper
    {
        public static ReferenceEntity MapToEntity(ReferenceDto reference, Guid parentId)
        {
            return new ReferenceEntity
            {
                Id = reference.Id,
                Name = reference.Name,
                Role = reference.Role,
                Phonenumber = reference.Phonenumber,
                Email = reference.Email,
                EmploymentId = parentId,
            };
        }

        public static ReferenceDto MapToDto(ReferenceEntity reference)
        {
            return new ReferenceDto
            {
                Id = reference.Id,
                Name = reference.Name,
                Role = reference?.Role,
                Phonenumber = reference?.Phonenumber,
                Email= reference?.Email,
            };
        }
    }
}
