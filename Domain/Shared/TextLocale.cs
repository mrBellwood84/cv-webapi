namespace Domain.Shared
{
    public class TextLocale
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Content { get; set; }
    }

    public class CourseName : TextLocale { }

    public class ExperienceHeader : TextLocale { }
    public class ExperienceSubheader : TextLocale { }
    public class ExperienceText : TextLocale { }

    public class PositionHeader : TextLocale { }
    public class PositionText : TextLocale { }

    public class ProjectText : TextLocale { }
    public class ReferenceText : TextLocale { }
    public class SchoolName : TextLocale { }
    public class SchoolText : TextLocale { }
    public class SkillText : TextLocale { }


}
