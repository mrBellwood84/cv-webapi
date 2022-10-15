namespace Identity.Data
{
    public class AccountManaged
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public DateTime AccountExpire { get; set; }

        public int LoginCount { get; set; }
        public bool ExportedPdf { get; set; }
#nullable enable
        public string? Password { get; set; }

    }
}
