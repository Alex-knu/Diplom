using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.AuthServer.Infrastructure.Data
{
    internal class AuthServerDbContext : IdentityDbContext
    {
        public AuthServerDbContext(DbContextOptions<AuthServerDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new ProgramLanguageConfiguration());
        }

        //public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
    }
}