using Microsoft.EntityFrameworkCore;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data
{
    internal class ITProjectPriceCalculationManagerDbContext : DbContext
    {
        public ITProjectPriceCalculationManagerDbContext(DbContextOptions<ITProjectPriceCalculationManagerDbContext> options) : base(options)
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