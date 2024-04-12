using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClothesBG.Data;

namespace ClothesBG.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ClothesBG.Data.Clothes> Clothes { get; set; } = default!;
        public DbSet<ClothesBG.Data.Girl> Girl { get; set; } = default!;
        public DbSet<ClothesBG.Data.Child> Child { get; set; } = default!;
    }
}
