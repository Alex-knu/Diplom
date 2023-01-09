using ITProjectPriceCalculationManager.Core.Entities.ProgramLanguage;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.Infrastructure.Data
{
    public class ITProjectPriceCalculationManagerDbContext : DbContext
    {
        public ITProjectPriceCalculationManagerDbContext(DbContextOptions<ITProjectPriceCalculationManagerDbContext> options) 
        : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProgramLanguageConfiguration());
        }

        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
    }
}