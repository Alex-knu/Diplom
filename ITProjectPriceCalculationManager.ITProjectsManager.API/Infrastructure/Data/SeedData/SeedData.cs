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
                new Attribute { Id = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), Name = "Qualifications(PERS)" },
                new Attribute { Id = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), Name = "Experience(PREX)" },
                new Attribute { Id = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), Name = "Technical support(FCIL)" },
                new Attribute { Id = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), Name = "Schedule restrictions(SCED)" },
                new Attribute { Id = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), Name = "Complexity of the program environment(PDIF)" },
                new Attribute { Id = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), Name = "Complexity and reliability(RCPX)" },
                new Attribute { Id = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), Name = "Reuse requested(RUSE)" },
                new Attribute { Id = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), Name = "Product novelty for the developer's company(PREC)" },
                new Attribute { Id = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), Name = "Development flexibility(FLEX)" },
                new Attribute { Id = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), Name = "Level of risk/architecture management (%)(RESL)" },
                new Attribute { Id = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), Name = "Cohesion of the development team(TEAM)" },
                new Attribute { Id = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), Name = "Technology maturity maturity process development(PMAT)" },
                new Attribute { Id = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), Name = "Internal logical object" },
                new Attribute { Id = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), Name = "External interface object" },
                new Attribute { Id = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), Name = "External input" },
                new Attribute { Id = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), Name = "External output" },
                new Attribute { Id = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), Name = "External request" }
            );
        }

        private static void SeedDifficultyLevelsType(ModelBuilder builder)
        {
            builder.Entity<DifficultyLevelsType>().HasData(
                new DifficultyLevelsType { Id = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), Name = "Super low" },
                new DifficultyLevelsType { Id = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), Name = "Very low" },
                new DifficultyLevelsType { Id = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), Name = "Low" },
                new DifficultyLevelsType { Id = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), Name = "Normal" },
                new DifficultyLevelsType { Id = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), Name = "Medium" },
                new DifficultyLevelsType { Id = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), Name = "High" },
                new DifficultyLevelsType { Id = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), Name = "Very high" },
                new DifficultyLevelsType { Id = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), Name = "Super high" }
            );
        }

        private static void SeedFactorType(ModelBuilder builder)
        {
            builder.Entity<FactorType>().HasData(
                new FactorType { Id = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Name = "Influence factor" },
                new FactorType { Id = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Name = "Scale factor" },
                new FactorType { Id = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Name = "Information object" },
                new FactorType { Id = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Name = "Function" }
            );
        }

        private static void SeedProgramLanguage(ModelBuilder builder)
        {
            builder.Entity<ProgramLanguage>().HasData(
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "ABAP (SAP)", SLOC = 28 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "ASP", SLOC = 51 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Assembler", SLOC = 119 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Brio +", SLOC = 14 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "C", SLOC = 97 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "C++", SLOC = 50 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "C#", SLOC = 54 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "COBOL", SLOC = 61 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Cognos Impromptu Scripts +", SLOC = 47 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Cross System Products (CSP) +", SLOC = 20 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Cool:Gen/IEF", SLOC = 32 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Datastage", SLOC = 71 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Excel", SLOC = 209 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Focus", SLOC = 43 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "FoxPro", SLOC = 36 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "HTML", SLOC = 34 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "J2EE", SLOC = 46 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Java", SLOC = 53 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "JavaScript", SLOC = 47 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "JCL", SLOC = 62 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "LINC II", SLOC = 29 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Lotus Notes", SLOC = 23 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Natural", SLOC = 40 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = ".NET", SLOC = 57 },
                new ProgramLanguage { Id = Guid.NewGuid(), Name = "Oracle", SLOC = 37 }
            );
        }

        private static void SeedDifficultyLevelsTypeToFactorType(ModelBuilder builder)
        {
            builder.Entity<DifficultyLevelsTypeToFactorType>().HasData(
                //Factor - Qualifications(PERS)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 2.12 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.62 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.26 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.83 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.63 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.5 },
                //Factor - Experience(PREX)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.59 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.33 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.12 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.71 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.62 },
                //Factor - Technical support(FCIL)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.43 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.3 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.73 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.62 },
                //Factor - Schedule restrictions(SCED)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.43 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.14 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
                //Factor - Complexity of the program environment(PDIF)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.29 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.81 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 2.61 },
                //Factor - Complexity and reliability(RCPX)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.49 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.6 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.83 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.33 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.97 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 2.72 },
                //Factor - Reuse requested(RUSE)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.95 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.07 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.15 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.24 },
                //Factor - Product novelty for the developer's company(PREC)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 6.2 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.96 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.72 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.48 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.24 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
                //Factor - Development flexibility(FLEX)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 5.07 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.05 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.04 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.03 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.01 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
                //Factor - Level of risk/architecture management (%)(RESL)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 7.07 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 5.65 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.24 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.83 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.41 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
                //Factor - Cohesion of the development team(TEAM)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 5.48 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.38 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.29 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.19 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.1 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
                //Factor - Technology maturity maturity process development(PMAT)
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 7.8 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 6.24 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.68 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.12 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.56 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
                //Factor - Internal logical object
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 7 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 10 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 15 },
                //Factor - External interface object
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 5 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 7 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 10 },
                //Factor - External input
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 3 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 4 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 6 },
                //Factor - External output
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 4 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 5 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 7 },
                //Factor - External request
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 3 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 4 },
                new DifficultyLevelsTypeToFactorType { Id = Guid.NewGuid(), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 6 }
            );
        }
    }
}