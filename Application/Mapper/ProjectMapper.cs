using Domain.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public static class ProjectMapper
    {
        public static ProjectEntity MapToEntity(ProjectDto dto)
        {
            return new ProjectEntity
            {
                Id = dto.Id,
                ProjectName = dto.ProjectName,
                Text = dto.Text,
                WebsiteUrl = dto.WebsiteUrl,
                RepoUrl = dto.RepoUrl,
            };
        }
    }
}
