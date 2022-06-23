using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Informatic_API.Models
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        public Context()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PhoneNumber> phoneNumbers { get; set; }
    }
}
