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
    }
}