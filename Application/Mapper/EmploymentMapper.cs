using Domain.Employment;

namespace Application.Mapper
{
    internal static class EmploymentMapper
    {
        public static EmploymentEntity mapToEntity(EmploymentDto entity)
        {
            return new EmploymentEntity
            {
                Id = entity.Id,
                Employer = entity.Employer,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
            };
        }
    }
}
