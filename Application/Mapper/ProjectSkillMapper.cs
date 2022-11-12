using Domain.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public static class ProjectSkillMapper
    {
        public static FrameworkSkillEntity MapToFrameworkSkillEntity(ProjectSkill skill, Guid parentId)
        {
            return new FrameworkSkillEntity
            {
                Id = skill.Id,
                Name = skill.Name,
                SvgUrl = skill.SvgUrl,
                ProjectId = parentId,
            };
        }

        public static List<FrameworkSkillEntity> MapToFrameworkSkillEntityList(List<ProjectSkill> skills, Guid parentId)
        {
            var list = new List<FrameworkSkillEntity>();
            foreach (var skill in skills)
            {
                list.Add(MapToFrameworkSkillEntity(skill, parentId));
            }
            return list;
        }

        public static LanguageSkillEntity MapToLanguageSkillEntity(ProjectSkill skill, Guid parentId)
        {
            return new LanguageSkillEntity
            {
                Id = skill.Id,
                Name = skill.Name,
                SvgUrl = skill.SvgUrl,
                ProjectId = parentId
            };
        }

        public static List<LanguageSkillEntity> MapToLanguageSkillEntityList(List<ProjectSkill> skills, Guid parentId)
        {
            var list = new List<LanguageSkillEntity>();
            foreach (var skill in skills)
            {
                list.Add(MapToLanguageSkillEntity(skill, parentId));
            }
            return list;
        }

        public static ProjectSkill MapToDto(FrameworkSkillEntity entity)
        {
            return new ProjectSkill
            {
                Id = entity.Id,
                Name = entity.Name,
                SvgUrl = entity.SvgUrl,
            };
        }

        public static ProjectSkill MapToDto(LanguageSkillEntity entity)
        {
            return new ProjectSkill
            {
                Id = entity.Id,
                Name = entity.Name,
                SvgUrl = entity.SvgUrl,
            };
        }

        public static List<ProjectSkill> MapToDtoList(List<FrameworkSkillEntity> entities)
        {
            var list = new List<ProjectSkill>();
            foreach (var entity in entities)
            {
                list.Add(MapToDto(entity));
            }
            return list;
        }

        public static List<ProjectSkill> MapToDtoList(List<LanguageSkillEntity> entities)
        {
            var list = new List<ProjectSkill>();
            foreach (var entity in entities)
            {
                list.Add(MapToDto(entity));
            }
            return list;
        }
    }
}
