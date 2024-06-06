using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data.SeedData;

internal static class SeedData
{
    public static void Seed(this ModelBuilder builder)
    {
        SeedBelongingFunction(builder);
    }
    
    private static void SeedBelongingFunction(ModelBuilder builder)
    {
       builder.Entity<BelongingFunction>().HasData(
             new BelongingFunction { Id = new Guid("f4bf3d51-4f18-42e5-b92f-1e8cf40dca1a"), Name = "SigmoidMembershipFunction" },
             new BelongingFunction { Id = new Guid("a13bcaf8-0d49-4df7-ba32-0d6fd5b4c4c0"), Name = "GaussianMembershipFunction" },
             new BelongingFunction { Id = new Guid("6d8622f5-8e17-49a9-b66e-5e11fd761278"), Name = "ExponentialMembershipFunction" },
             new BelongingFunction { Id = new Guid("9c4b86fc-0f8f-4e26-8de0-29c57b076a54"), Name = "QuadraticMembershipFunction" }
         );
    }
}