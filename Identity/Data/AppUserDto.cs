namespace Identity.Data
{
    public class AppUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime AccountExpire { get; set; }
#nullable enable
        public string? Token { get; set; }
        public string? Company { get; set; }
    }
}
