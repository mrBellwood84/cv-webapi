namespace Domain.Shared
{
    public class Reference
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ReferenceText> Role { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
    }
}
