namespace Domain.Shared
{
    public class ReferenceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ReferenceText> Role { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
    }

    public class ReferenceEntity : ReferenceDto
    {
        public Guid EmploymentId { get; set; }
    }
}
