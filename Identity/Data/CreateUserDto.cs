namespace Identity.Data
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime AccountExpire { get; set; }
#nullable enable
        public string? Company { get; set; }
    }
}
