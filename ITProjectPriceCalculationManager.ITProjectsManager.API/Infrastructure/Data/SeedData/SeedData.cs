using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsTypeToFactorType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using Microsoft.EntityFrameworkCore;
using Attribute = ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute.Attribute;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.SeedData
{
    internal static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedAttribute(builder);
            SeedDifficultyLevelsType(builder);
            SeedDifficultyLevelsTypeToFactorType(builder);
            SeedFactorType(builder);
            SeedProgramLanguage(builder);
        }

        private static void SeedAttribute(ModelBuilder builder)
        {
            builder.Entity<Attribute>().HasData(
                new Attribute { Id = 1, Name = "Qualifications(PERS)" },
                new Attribute { Id = 2, Name = "Experience(PREX)" },
                new Attribute { Id = 3, Name = "Technical support(FCIL)" },
                new Attribute { Id = 4, Name = "Schedule restrictions(SCED)" },
                new Attribute { Id = 5, Name = "Complexity of the program environment(PDIF)" },
                new Attribute { Id = 6, Name = "Complexity and reliability(RCPX)" },
                new Attribute { Id = 7, Name = "Reuse requested(RUSE)" },
                new Attribute { Id = 8, Name = "Product novelty for the developer's company(PREC)" },
                new Attribute { Id = 9, Name = "Development flexibility(FLEX)" },
                new Attribute { Id = 10, Name = "Level of risk/architecture management (%)(RESL)" },
                new Attribute { Id = 11, Name = "Cohesion of the development team(TEAM)" },
                new Attribute { Id = 12, Name = "Technology maturity maturity process development(PMAT)" },
                new Attribute { Id = 13, Name = "Internal logical object" },
                new Attribute { Id = 14, Name = "External interface object" },
                new Attribute { Id = 15, Name = "External input" },
                new Attribute { Id = 16, Name = "External output" },
                new Attribute { Id = 17, Name = "External request" }
            );
        }

        private static void SeedDifficultyLevelsType(ModelBuilder builder)
        {
            builder.Entity<DifficultyLevelsType>().HasData(
                new DifficultyLevelsType { Id = 1, Name = "Super low" },
                new DifficultyLevelsType { Id = 2, Name = "Very low" },
                new DifficultyLevelsType { Id = 3, Name = "Low" },
                new DifficultyLevelsType { Id = 4, Name = "Normal" },
                new DifficultyLevelsType { Id = 5, Name = "Medium" },
                new DifficultyLevelsType { Id = 6, Name = "High" },
                new DifficultyLevelsType { Id = 7, Name = "Very high" },
                new DifficultyLevelsType { Id = 8, Name = "Super high" }
            );
        }

        private static void SeedFactorType(ModelBuilder builder)
        {
            builder.Entity<FactorType>().HasData(
                new FactorType { Id = 1, Name = "Influence factor" },
                new FactorType { Id = 2, Name = "Scale factor" },
                new FactorType { Id = 3, Name = "Information object" },
                new FactorType { Id = 4, Name = "Function" }
            );
        }

        private static void SeedProgramLanguage(ModelBuilder builder)
        {
            builder.Entity<ProgramLanguage>().HasData(
                new ProgramLanguage { Id = 1, Name = "ABAP (SAP)", SLOC = 28 },
                new ProgramLanguage { Id = 2, Name = "ASP", SLOC = 51 },
                new ProgramLanguage { Id = 3, Name = "Assembler", SLOC = 119 },
                new ProgramLanguage { Id = 4, Name = "Brio +", SLOC = 14 },
                new ProgramLanguage { Id = 5, Name = "C", SLOC = 97 },
                new ProgramLanguage { Id = 6, Name = "C++", SLOC = 50 },
                new ProgramLanguage { Id = 7, Name = "C#", SLOC = 54 },
                new ProgramLanguage { Id = 8, Name = "COBOL", SLOC = 61 },
                new ProgramLanguage { Id = 9, Name = "Cognos Impromptu Scripts +", SLOC = 47 },
                new ProgramLanguage { Id = 10, Name = "Cross System Products (CSP) +", SLOC = 20 },
                new ProgramLanguage { Id = 11, Name = "Cool:Gen/IEF", SLOC = 32 },
                new ProgramLanguage { Id = 12, Name = "Datastage", SLOC = 71 },
                new ProgramLanguage { Id = 13, Name = "Excel", SLOC = 209 },
                new ProgramLanguage { Id = 14, Name = "Focus", SLOC = 43 },
                new ProgramLanguage { Id = 15, Name = "FoxPro", SLOC = 36 },
                new ProgramLanguage { Id = 16, Name = "HTML", SLOC = 34 },
                new ProgramLanguage { Id = 17, Name = "J2EE", SLOC = 46 },
                new ProgramLanguage { Id = 18, Name = "Java", SLOC = 53 },
                new ProgramLanguage { Id = 19, Name = "JavaScript", SLOC = 47 },
                new ProgramLanguage { Id = 20, Name = "JCL", SLOC = 62 },
                new ProgramLanguage { Id = 21, Name = "LINC II", SLOC = 29 },
                new ProgramLanguage { Id = 22, Name = "Lotus Notes", SLOC = 23 },
                new ProgramLanguage { Id = 23, Name = "Natural", SLOC = 40 },
                new ProgramLanguage { Id = 24, Name = ".NET", SLOC = 57 },
                new ProgramLanguage { Id = 25, Name = "Oracle", SLOC = 37 }
            );
        }

        private static void SeedDifficultyLevelsTypeToFactorType(ModelBuilder builder)
        {
            builder.Entity<DifficultyLevelsTypeToFactorType>().HasData(
                //Factor - Internal logical object
                new DifficultyLevelsTypeToFactorType { Id = 1, DifficultyLevelId = 3, FactorId = 13, FactorTypeId = 3, Value = 7 },
                new DifficultyLevelsTypeToFactorType { Id = 2, DifficultyLevelId = 5, FactorId = 13, FactorTypeId = 3, Value = 10 },
                new DifficultyLevelsTypeToFactorType { Id = 3, DifficultyLevelId = 6, FactorId = 13, FactorTypeId = 3, Value = 15 },
                //Factor - External interface object
                new DifficultyLevelsTypeToFactorType { Id = 4, DifficultyLevelId = 3, FactorId = 14, FactorTypeId = 3, Value = 5 },
                new DifficultyLevelsTypeToFactorType { Id = 5, DifficultyLevelId = 5, FactorId = 14, FactorTypeId = 3, Value = 7 },
                new DifficultyLevelsTypeToFactorType { Id = 6, DifficultyLevelId = 6, FactorId = 14, FactorTypeId = 3, Value = 10 },
                //Factor - Qualifications(PERS)
                new DifficultyLevelsTypeToFactorType { Id = 7, DifficultyLevelId = 1, FactorId = 1, FactorTypeId = 1, Value = 2.12 },
                new DifficultyLevelsTypeToFactorType { Id = 8, DifficultyLevelId = 2, FactorId = 1, FactorTypeId = 1, Value = 1.62 },
                new DifficultyLevelsTypeToFactorType { Id = 9, DifficultyLevelId = 3, FactorId = 1, FactorTypeId = 1, Value = 1.26 },
                new DifficultyLevelsTypeToFactorType { Id = 10, DifficultyLevelId = 4, FactorId = 1, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 11, DifficultyLevelId = 6, FactorId = 1, FactorTypeId = 1, Value = 0.83 },
                new DifficultyLevelsTypeToFactorType { Id = 12, DifficultyLevelId = 7, FactorId = 1, FactorTypeId = 1, Value = 0.63 },
                new DifficultyLevelsTypeToFactorType { Id = 13, DifficultyLevelId = 8, FactorId = 1, FactorTypeId = 1, Value = 0.5 },
                //Factor - Experience(PREX)
                new DifficultyLevelsTypeToFactorType { Id = 14, DifficultyLevelId = 1, FactorId = 2, FactorTypeId = 1, Value = 1.59 },
                new DifficultyLevelsTypeToFactorType { Id = 15, DifficultyLevelId = 2, FactorId = 2, FactorTypeId = 1, Value = 1.33 },
                new DifficultyLevelsTypeToFactorType { Id = 16, DifficultyLevelId = 3, FactorId = 2, FactorTypeId = 1, Value = 1.12 },
                new DifficultyLevelsTypeToFactorType { Id = 17, DifficultyLevelId = 4, FactorId = 2, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 18, DifficultyLevelId = 6, FactorId = 2, FactorTypeId = 1, Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = 19, DifficultyLevelId = 7, FactorId = 2, FactorTypeId = 1, Value = 0.71 },
                new DifficultyLevelsTypeToFactorType { Id = 20, DifficultyLevelId = 8, FactorId = 2, FactorTypeId = 1, Value = 0.62 },
                //Factor - Technical support(FCIL)
                new DifficultyLevelsTypeToFactorType { Id = 21, DifficultyLevelId = 1, FactorId = 3, FactorTypeId = 1, Value = 1.43 },
                new DifficultyLevelsTypeToFactorType { Id = 22, DifficultyLevelId = 2, FactorId = 3, FactorTypeId = 1, Value = 1.3 },
                new DifficultyLevelsTypeToFactorType { Id = 23, DifficultyLevelId = 3, FactorId = 3, FactorTypeId = 1, Value = 1.1 },
                new DifficultyLevelsTypeToFactorType { Id = 24, DifficultyLevelId = 4, FactorId = 3, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 25, DifficultyLevelId = 6, FactorId = 3, FactorTypeId = 1, Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = 26, DifficultyLevelId = 7, FactorId = 3, FactorTypeId = 1, Value = 0.73 },
                new DifficultyLevelsTypeToFactorType { Id = 27, DifficultyLevelId = 8, FactorId = 3, FactorTypeId = 1, Value = 0.62 },
                //Factor - Schedule restrictions(SCED)
                new DifficultyLevelsTypeToFactorType { Id = 28, DifficultyLevelId = 1, FactorId = 4, FactorTypeId = 1, Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = 29, DifficultyLevelId = 2, FactorId = 4, FactorTypeId = 1, Value = 1.43 },
                new DifficultyLevelsTypeToFactorType { Id = 30, DifficultyLevelId = 3, FactorId = 4, FactorTypeId = 1, Value = 1.14 },
                new DifficultyLevelsTypeToFactorType { Id = 31, DifficultyLevelId = 4, FactorId = 4, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 32, DifficultyLevelId = 6, FactorId = 4, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 33, DifficultyLevelId = 7, FactorId = 4, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 34, DifficultyLevelId = 8, FactorId = 4, FactorTypeId = 1, Value = 0 },
                //Factor - Complexity of the program environment(PDIF)
                new DifficultyLevelsTypeToFactorType { Id = 35, DifficultyLevelId = 1, FactorId = 5, FactorTypeId = 1, Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = 36, DifficultyLevelId = 2, FactorId = 5, FactorTypeId = 1, Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = 37, DifficultyLevelId = 3, FactorId = 5, FactorTypeId = 1, Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = 38, DifficultyLevelId = 4, FactorId = 5, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 39, DifficultyLevelId = 6, FactorId = 5, FactorTypeId = 1, Value = 1.29 },
                new DifficultyLevelsTypeToFactorType { Id = 40, DifficultyLevelId = 7, FactorId = 5, FactorTypeId = 1, Value = 1.81 },
                new DifficultyLevelsTypeToFactorType { Id = 41, DifficultyLevelId = 8, FactorId = 5, FactorTypeId = 1, Value = 2.61 },
                //Factor - Complexity and reliability(RCPX)
                new DifficultyLevelsTypeToFactorType { Id = 42, DifficultyLevelId = 1, FactorId = 6, FactorTypeId = 1, Value = 0.49 },
                new DifficultyLevelsTypeToFactorType { Id = 43, DifficultyLevelId = 2, FactorId = 6, FactorTypeId = 1, Value = 0.6 },
                new DifficultyLevelsTypeToFactorType { Id = 44, DifficultyLevelId = 3, FactorId = 6, FactorTypeId = 1, Value = 0.83 },
                new DifficultyLevelsTypeToFactorType { Id = 45, DifficultyLevelId = 4, FactorId = 6, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 46, DifficultyLevelId = 6, FactorId = 6, FactorTypeId = 1, Value = 1.33 },
                new DifficultyLevelsTypeToFactorType { Id = 47, DifficultyLevelId = 7, FactorId = 6, FactorTypeId = 1, Value = 1.97 },
                new DifficultyLevelsTypeToFactorType { Id = 48, DifficultyLevelId = 8, FactorId = 6, FactorTypeId = 1, Value = 2.72 },
                //Factor - Reuse requested(RUSE)
                new DifficultyLevelsTypeToFactorType { Id = 49, DifficultyLevelId = 1, FactorId = 7, FactorTypeId = 1, Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = 50, DifficultyLevelId = 2, FactorId = 7, FactorTypeId = 1, Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = 51, DifficultyLevelId = 3, FactorId = 7, FactorTypeId = 1, Value = 0.95 },
                new DifficultyLevelsTypeToFactorType { Id = 52, DifficultyLevelId = 4, FactorId = 7, FactorTypeId = 1, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 53, DifficultyLevelId = 6, FactorId = 7, FactorTypeId = 1, Value = 1.07 },
                new DifficultyLevelsTypeToFactorType { Id = 54, DifficultyLevelId = 7, FactorId = 7, FactorTypeId = 1, Value = 1.15 },
                new DifficultyLevelsTypeToFactorType { Id = 55, DifficultyLevelId = 8, FactorId = 7, FactorTypeId = 1, Value = 1.24 },
                //Factor - Product novelty for the developer's company(PREC)
                new DifficultyLevelsTypeToFactorType { Id = 56, DifficultyLevelId = 2, FactorId = 8, FactorTypeId = 2, Value = 6.2 },
                new DifficultyLevelsTypeToFactorType { Id = 57, DifficultyLevelId = 3, FactorId = 8, FactorTypeId = 2, Value = 4.96 },
                new DifficultyLevelsTypeToFactorType { Id = 58, DifficultyLevelId = 4, FactorId = 8, FactorTypeId = 2, Value = 3.72 },
                new DifficultyLevelsTypeToFactorType { Id = 59, DifficultyLevelId = 6, FactorId = 8, FactorTypeId = 2, Value = 2.48 },
                new DifficultyLevelsTypeToFactorType { Id = 60, DifficultyLevelId = 7, FactorId = 8, FactorTypeId = 2, Value = 1.24 },
                new DifficultyLevelsTypeToFactorType { Id = 61, DifficultyLevelId = 8, FactorId = 8, FactorTypeId = 2, Value = 0 },
                //Factor - Development flexibility(FLEX)
                new DifficultyLevelsTypeToFactorType { Id = 62, DifficultyLevelId = 2, FactorId = 9, FactorTypeId = 2, Value = 5.07 },
                new DifficultyLevelsTypeToFactorType { Id = 63, DifficultyLevelId = 3, FactorId = 9, FactorTypeId = 2, Value = 4.05 },
                new DifficultyLevelsTypeToFactorType { Id = 64, DifficultyLevelId = 4, FactorId = 9, FactorTypeId = 2, Value = 3.04 },
                new DifficultyLevelsTypeToFactorType { Id = 65, DifficultyLevelId = 6, FactorId = 9, FactorTypeId = 2, Value = 2.03 },
                new DifficultyLevelsTypeToFactorType { Id = 66, DifficultyLevelId = 7, FactorId = 9, FactorTypeId = 2, Value = 1.01 },
                new DifficultyLevelsTypeToFactorType { Id = 67, DifficultyLevelId = 8, FactorId = 9, FactorTypeId = 2, Value = 0 },
                //Factor - Level of risk/architecture management (%)(RESL)
                new DifficultyLevelsTypeToFactorType { Id = 68, DifficultyLevelId = 2, FactorId = 10, FactorTypeId = 2, Value = 7.07 },
                new DifficultyLevelsTypeToFactorType { Id = 69, DifficultyLevelId = 3, FactorId = 10, FactorTypeId = 2, Value = 5.65 },
                new DifficultyLevelsTypeToFactorType { Id = 70, DifficultyLevelId = 4, FactorId = 10, FactorTypeId = 2, Value = 4.24 },
                new DifficultyLevelsTypeToFactorType { Id = 71, DifficultyLevelId = 6, FactorId = 10, FactorTypeId = 2, Value = 2.83 },
                new DifficultyLevelsTypeToFactorType { Id = 72, DifficultyLevelId = 7, FactorId = 10, FactorTypeId = 2, Value = 1.41 },
                new DifficultyLevelsTypeToFactorType { Id = 73, DifficultyLevelId = 8, FactorId = 10, FactorTypeId = 2, Value = 0 },
                //Factor - Cohesion of the development team(TEAM)
                new DifficultyLevelsTypeToFactorType { Id = 74, DifficultyLevelId = 2, FactorId = 11, FactorTypeId = 2, Value = 5.48 },
                new DifficultyLevelsTypeToFactorType { Id = 75, DifficultyLevelId = 3, FactorId = 11, FactorTypeId = 2, Value = 4.38 },
                new DifficultyLevelsTypeToFactorType { Id = 76, DifficultyLevelId = 4, FactorId = 11, FactorTypeId = 2, Value = 3.29 },
                new DifficultyLevelsTypeToFactorType { Id = 77, DifficultyLevelId = 6, FactorId = 11, FactorTypeId = 2, Value = 2.19 },
                new DifficultyLevelsTypeToFactorType { Id = 78, DifficultyLevelId = 7, FactorId = 11, FactorTypeId = 2, Value = 1.1 },
                new DifficultyLevelsTypeToFactorType { Id = 79, DifficultyLevelId = 8, FactorId = 11, FactorTypeId = 2, Value = 0 },
                //Factor - Technology maturity maturity process development(PMAT)
                new DifficultyLevelsTypeToFactorType { Id = 80, DifficultyLevelId = 2, FactorId = 12, FactorTypeId = 2, Value = 7.8 },
                new DifficultyLevelsTypeToFactorType { Id = 81, DifficultyLevelId = 3, FactorId = 12, FactorTypeId = 2, Value = 6.24 },
                new DifficultyLevelsTypeToFactorType { Id = 82, DifficultyLevelId = 4, FactorId = 12, FactorTypeId = 2, Value = 4.68 },
                new DifficultyLevelsTypeToFactorType { Id = 83, DifficultyLevelId = 6, FactorId = 12, FactorTypeId = 2, Value = 3.12 },
                new DifficultyLevelsTypeToFactorType { Id = 84, DifficultyLevelId = 7, FactorId = 12, FactorTypeId = 2, Value = 1.56 },
                new DifficultyLevelsTypeToFactorType { Id = 85, DifficultyLevelId = 8, FactorId = 12, FactorTypeId = 2, Value = 0 },
                //Factor - External input
                new DifficultyLevelsTypeToFactorType { Id = 86, DifficultyLevelId = 3, FactorId = 15, FactorTypeId = 4, Value = 3 },
                new DifficultyLevelsTypeToFactorType { Id = 87, DifficultyLevelId = 5, FactorId = 15, FactorTypeId = 4, Value = 4 },
                new DifficultyLevelsTypeToFactorType { Id = 88, DifficultyLevelId = 6, FactorId = 15, FactorTypeId = 4, Value = 6 },
                //Factor - External output
                new DifficultyLevelsTypeToFactorType { Id = 89, DifficultyLevelId = 3, FactorId = 16, FactorTypeId = 4, Value = 4 },
                new DifficultyLevelsTypeToFactorType { Id = 90, DifficultyLevelId = 5, FactorId = 16, FactorTypeId = 4, Value = 5 },
                new DifficultyLevelsTypeToFactorType { Id = 91, DifficultyLevelId = 6, FactorId = 16, FactorTypeId = 4, Value = 7 },
                //Factor - External request
                new DifficultyLevelsTypeToFactorType { Id = 92, DifficultyLevelId = 3, FactorId = 17, FactorTypeId = 4, Value = 3 },
                new DifficultyLevelsTypeToFactorType { Id = 93, DifficultyLevelId = 3, FactorId = 17, FactorTypeId = 4, Value = 4 },
                new DifficultyLevelsTypeToFactorType { Id = 94, DifficultyLevelId = 3, FactorId = 17, FactorTypeId = 4, Value = 6 }
            );
        }
    }
}