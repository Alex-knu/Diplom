using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationStatus;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.BelongingFunction;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.SeedData;

internal static class SeedData
{
    public static void Seed(this ModelBuilder builder)
    {
        SeedApplicationStatuses(builder);
        SeedBelongingFunction(builder);
    }

    private static void SeedApplicationStatuses(ModelBuilder builder)
    {
        builder.Entity<ApplicationStatus>().HasData(
            new ApplicationStatus { Id = new Guid("4706D234-E64D-4AB2-BED0-6086E10C3325"), Name = "Нова" },
            new ApplicationStatus { Id = new Guid("C4A6971D-A0DE-4D6D-97FE-67DB465E330F"), Name = "На оцінюванні" },
            new ApplicationStatus { Id = new Guid("9806F24D-89D7-42F5-80B4-D39AC7798949"), Name = "На доопрацюванні" },
            new ApplicationStatus { Id = new Guid("56533C08-2C5B-4BBA-8DC2-9EFE0FB3DC66"), Name = "Оцінено" }
        );
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