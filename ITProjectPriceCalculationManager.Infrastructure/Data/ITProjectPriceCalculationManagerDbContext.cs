using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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