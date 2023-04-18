using Microsoft.EntityFrameworkCore;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.SubjectAreaElement;

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

            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramsParametrConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramsParametrToSubjectAreaElementConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectAreaElementConfiguration());
        }
        
        public DbSet<Application> Applications { get; set; }
        public DbSet<ProgramsParametr> ProgramsParametrs { get; set; }
        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
        public DbSet<ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements { get; set; }
        public DbSet<SubjectAreaElement> SubjectAreaElements { get; set; }
    }
}