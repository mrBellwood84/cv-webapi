using Microsoft.AspNetCore.Identity;

namespace Identity.Data
{
    /// <summary>
    /// Data model for application user
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Username used for login
        /// </summary>
        public override string UserName { get; set; }
        /// <summary>
        /// Account role:  admin | guesat
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Date of account expiration
        /// </summary>
        public DateTime AccountExpire { get; set; }
        /// <summary>
        /// Times user have logged in
        /// </summary>
        public int LoginCount { get; set; } = 0;
        /// <summary>
        /// True if user has exported the pdf
        /// </summary>
        public bool ExportedPdf { get; set; } = false;
#nullable enable
        /// <summary>
        /// Guest company if any
        /// </summary>
        public string? Company { get; set; }
    }
}
