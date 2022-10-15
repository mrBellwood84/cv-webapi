using Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.Context
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {

        private readonly IConfiguration _config;

        public IdentityContext(DbContextOptions<IdentityContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_config.GetConnectionString("default"));
        }
    }
}
