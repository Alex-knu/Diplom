using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data.SeedData
{
    internal static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            // SeedAttribute(builder);
            // SeedApplicationStatuses(builder);
            // SeedDifficultyLevelsType(builder);
            // SeedDifficultyLevelsTypeToFactorType(builder);
            // SeedFactorType(builder);
            // SeedProgramLanguage(builder);
        }

        // private static void SeedAttribute(ModelBuilder builder)
        // {
        //     builder.Entity<Attribute>().HasData(
        //         new Attribute { Id = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), Name = "Qualifications(PERS)" },
        //         new Attribute { Id = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), Name = "Experience(PREX)" },
        //         new Attribute { Id = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), Name = "Technical support(FCIL)" },
        //         new Attribute { Id = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), Name = "Schedule restrictions(SCED)" },
        //         new Attribute { Id = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), Name = "Complexity of the program environment(PDIF)" },
        //         new Attribute { Id = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), Name = "Complexity and reliability(RCPX)" },
        //         new Attribute { Id = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), Name = "Reuse requested(RUSE)" },
        //         new Attribute { Id = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), Name = "Product novelty for the developer's company(PREC)" },
        //         new Attribute { Id = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), Name = "Development flexibility(FLEX)" },
        //         new Attribute { Id = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), Name = "Level of risk/architecture management (%)(RESL)" },
        //         new Attribute { Id = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), Name = "Cohesion of the development team(TEAM)" },
        //         new Attribute { Id = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), Name = "Technology maturity maturity process development(PMAT)" },
        //         new Attribute { Id = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), Name = "Internal logical object" },
        //         new Attribute { Id = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), Name = "External interface object" },
        //         new Attribute { Id = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), Name = "External input" },
        //         new Attribute { Id = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), Name = "External output" },
        //         new Attribute { Id = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), Name = "External request" }
        //     );
        // }

        // private static void SeedApplicationStatuses(ModelBuilder builder)
        // {
        //     builder.Entity<ApplicationStatus>().HasData(
        //         new ApplicationStatus { Id = new Guid("4706D234-E64D-4AB2-BED0-6086E10C3325"), Name = "Нова" },
        //         new ApplicationStatus { Id = new Guid("C4A6971D-A0DE-4D6D-97FE-67DB465E330F"), Name = "На оцінюванні" },
        //         new ApplicationStatus { Id = new Guid("9806F24D-89D7-42F5-80B4-D39AC7798949"), Name = "На доопрацюванні" },
        //         new ApplicationStatus { Id = new Guid("56533C08-2C5B-4BBA-8DC2-9EFE0FB3DC66"), Name = "Оцінено" }
        //     );
        // }

        // private static void SeedDifficultyLevelsType(ModelBuilder builder)
        // {
        //     builder.Entity<DifficultyLevelsType>().HasData(
        //         new DifficultyLevelsType { Id = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), Name = "Super low" },
        //         new DifficultyLevelsType { Id = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), Name = "Very low" },
        //         new DifficultyLevelsType { Id = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), Name = "Low" },
        //         new DifficultyLevelsType { Id = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), Name = "Normal" },
        //         new DifficultyLevelsType { Id = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), Name = "Medium" },
        //         new DifficultyLevelsType { Id = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), Name = "High" },
        //         new DifficultyLevelsType { Id = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), Name = "Very high" },
        //         new DifficultyLevelsType { Id = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), Name = "Super high" }
        //     );
        // }

        // private static void SeedFactorType(ModelBuilder builder)
        // {
        //     builder.Entity<FactorType>().HasData(
        //         new FactorType { Id = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Name = "Influence factor" },
        //         new FactorType { Id = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Name = "Scale factor" },
        //         new FactorType { Id = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Name = "Information object" },
        //         new FactorType { Id = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Name = "Function" }
        //     );
        // }

        // private static void SeedProgramLanguage(ModelBuilder builder)
        // {
        //     builder.Entity<ProgramLanguage>().HasData(
        //         new ProgramLanguage { Id = new Guid("794b2ac4-3310-4264-a367-d1e665a55458"), Name = "ABAP (SAP)", SLOC = 28 },
        //         new ProgramLanguage { Id = new Guid("c26246c3-caad-4d34-a42a-f6517cf45ef6"), Name = "ASP", SLOC = 51 },
        //         new ProgramLanguage { Id = new Guid("e3810495-b6ab-42af-87a6-9ba5f7393cd5"), Name = "Assembler", SLOC = 119 },
        //         new ProgramLanguage { Id = new Guid("a879c89b-11e3-4ae1-8b2a-eae6a126557c"), Name = "Brio +", SLOC = 14 },
        //         new ProgramLanguage { Id = new Guid("491c0205-a64e-46d1-8be0-25fabe8b6ae6"), Name = "C", SLOC = 97 },
        //         new ProgramLanguage { Id = new Guid("f3cd8a9f-dc66-46a4-b41b-f57c1d82a1ce"), Name = "C++", SLOC = 50 },
        //         new ProgramLanguage { Id = new Guid("aef38b0a-456c-455b-acca-fe7600ec8de8"), Name = "C#", SLOC = 54 },
        //         new ProgramLanguage { Id = new Guid("4e943d03-e4be-4ed2-b492-421b6c7b1c92"), Name = "COBOL", SLOC = 61 },
        //         new ProgramLanguage { Id = new Guid("32c19d74-6993-4d0e-8647-cdf75541e728"), Name = "Cognos Impromptu Scripts +", SLOC = 47 },
        //         new ProgramLanguage { Id = new Guid("00240fb2-4f29-431f-93b9-adfa31ceaaca"), Name = "Cross System Products (CSP) +", SLOC = 20 },
        //         new ProgramLanguage { Id = new Guid("b8c17601-7672-4b36-b4d5-975573edcaba"), Name = "Cool:Gen/IEF", SLOC = 32 },
        //         new ProgramLanguage { Id = new Guid("676bd39b-61fa-4718-af90-e2378851acdd"), Name = "Datastage", SLOC = 71 },
        //         new ProgramLanguage { Id = new Guid("10e69836-68a8-41cb-96c8-4ca6bc1190d1"), Name = "Excel", SLOC = 209 },
        //         new ProgramLanguage { Id = new Guid("736c315e-ec2b-4abf-8c4b-7f202939dced"), Name = "Focus", SLOC = 43 },
        //         new ProgramLanguage { Id = new Guid("c77c165f-3c3a-4e56-848f-0afe15af2315"), Name = "FoxPro", SLOC = 36 },
        //         new ProgramLanguage { Id = new Guid("22a1ad68-c278-4236-861b-0a256ca2a0b3"), Name = "HTML", SLOC = 34 },
        //         new ProgramLanguage { Id = new Guid("02f4ccdb-9fdb-4c65-87a8-3567d84a1781"), Name = "J2EE", SLOC = 46 },
        //         new ProgramLanguage { Id = new Guid("2229a77c-bdb4-4737-aaab-a5b456f74126"), Name = "Java", SLOC = 53 },
        //         new ProgramLanguage { Id = new Guid("ee1f313e-9603-4ebe-a3bd-e0da9c639a7d"), Name = "JavaScript", SLOC = 47 },
        //         new ProgramLanguage { Id = new Guid("98254d9f-f5ea-46f5-9278-fc77c8ff2b5a"), Name = "JCL", SLOC = 62 },
        //         new ProgramLanguage { Id = new Guid("8a889366-5efc-4bd4-be67-1373938692eb"), Name = "LINC II", SLOC = 29 },
        //         new ProgramLanguage { Id = new Guid("9f9752c2-18db-4b97-9d61-752b20aabb0c"), Name = "Lotus Notes", SLOC = 23 },
        //         new ProgramLanguage { Id = new Guid("d1627cf2-b9ad-46ac-9e84-93438f4ed0d1"), Name = "Natural", SLOC = 40 },
        //         new ProgramLanguage { Id = new Guid("34cb9cbc-564c-4494-bfda-941473f35341"), Name = ".NET", SLOC = 57 },
        //         new ProgramLanguage { Id = new Guid("c16181c5-3493-4223-8267-9d4d71b50eed"), Name = "Oracle", SLOC = 37 }
        //     );
        // }

        // private static void SeedDifficultyLevelsTypeToFactorType(ModelBuilder builder)
        // {
        //     builder.Entity<DifficultyLevelsTypeToFactorType>().HasData(
        //         //Factor - Qualifications(PERS)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("4d413d42-df92-483a-a769-3c70e6538bbd"), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 2.12 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("bec1c811-5198-4c74-bd9c-d1dfdfb56432"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.62 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("83591b36-ccd6-451f-a908-4a241012e96b"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.26 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("faf586cd-51bc-4a56-a10c-3d748355462c"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("ad158205-ff97-42a2-9abc-0040a8560c7e"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.83 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("7b27efd0-fee3-4689-98cd-95c444fb04d5"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.63 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("4a336b4d-61d9-48a1-970c-a0e69ac48fa7"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("7A0822A4-7012-4738-889B-FAFB713F72EA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.5 },
        //         //Factor - Experience(PREX)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("ee1e1078-41b2-43fc-b2ae-d4121c2b7ca2"), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.59 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("5f200051-a4b6-45b9-b6ce-9ba41351849b"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.33 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("afb9e99d-f300-4ae4-b2d7-c3099a660f4d"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.12 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("8c955d7f-dcd0-474a-85d7-d77b2c3f39eb"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("47464ce2-4daa-4d14-9e2d-285c254d0c27"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.87 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("aa4b9e0c-0f9c-42d7-bca1-db48d90af5fc"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.71 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("aea4daa0-2f03-4ef1-8ef5-787e676924e4"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("24FBF4F3-AA84-4B17-9D2E-0EF16238A2BA"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.62 },
        //         //Factor - Technical support(FCIL)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("502fe0cf-563e-4d8e-b65e-2bd3415f777a"), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.43 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("2a9240e9-b392-4a31-8f55-fb1f3e1e7399"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.3 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("a17667db-caaf-4644-986a-c7909be4295f"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("49543d41-1ce2-4d6c-9c7e-af9ffbdfae53"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("1c1f5991-cba7-4247-b338-5640d3237568"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.87 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("7e608ff2-0cbf-41bb-b0a1-f684d07536d8"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.73 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("31712da9-288f-4a6d-9c08-f446c130986c"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("33E07DED-1BD4-4E9A-8076-F071EA1A5269"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.62 },
        //         //Factor - Schedule restrictions(SCED)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("99555d3a-6b6d-42be-afe2-17ffae0547c4"), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("393ef14d-5612-4b29-979c-29b0e273bd1e"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.43 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("fb482a34-c3cf-40c9-9e34-72eac6668c4f"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.14 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("fbe342c7-9a7b-48d4-86bf-2cc9b32f3ac7"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("4d0492d2-12c3-4adf-b35e-c3ba949092af"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("63181747-3e61-4cdf-bd83-438f44f953c9"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("43cced97-4cb6-413b-ad18-9241389d63b3"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("EA5A8D97-0940-4463-B07A-D6A10B6F0D08"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
        //         //Factor - Complexity of the program environment(PDIF)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("5b20f57c-c7f0-4d2e-aa98-e8a250cd1e8f"), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("8e90a730-a896-41d2-96d9-08c1d47e74c0"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("d86fc321-ee82-4db9-b664-db9730395841"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.87 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("2474fdf5-1c38-4d46-a2e4-6fef3655d533"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("9518e8b5-c821-4b75-b7dc-8aee1b39ed76"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.29 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("48ef82ae-e8cc-4eb5-8aaf-8283296e1d00"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.81 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("bd4f0ee5-be9f-4298-a043-8424dd6d62d3"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("FE85D6AB-ADE6-412F-B2A6-7CA97F4F1DA4"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 2.61 },
        //         //Factor - Complexity and reliability(RCPX)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("a9596334-4666-4b29-a6bd-4d622ae5397d"), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.49 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("7bb09544-59ff-4733-a023-bf5d952e01ee"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.6 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("0ae2eaa5-e327-4425-95f1-822ae8ea01a6"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.83 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("9107c797-fa19-48e0-ae64-300c78b62b84"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("3013382f-daa7-4333-a4b5-e09a92158212"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.33 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("ae79da70-8847-4539-abb8-5cdf7d94772f"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.97 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("ff9377b2-17ac-4fbd-acbb-68b5aa4ea73a"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("4FEAB03A-7415-4C72-8B3F-6901E014C25E"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 2.72 },
        //         //Factor - Reuse requested(RUSE)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("7c53bf48-3633-4727-84f3-d16765c20dce"), DifficultyLevelId = new Guid("B3B0177D-BAF9-4AD6-B1C1-002E1B776A10"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("2f46aca0-6752-4352-9b57-2fbdacb7d576"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("58b98824-d6af-4fea-92fe-3292cc18a7b1"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 0.95 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("5d4848bd-c214-4159-b279-cf2eebee3fce"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("7908d221-07c3-4716-bbf6-6539503aec71"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.07 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("4a070749-70e4-4099-867c-0ce887e974b2"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.15 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("5fda3d4e-6657-4cb8-81bd-22c9b60f5a32"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("9B7D2F14-9EC0-414C-806B-D5E607664031"), FactorTypeId = new Guid("B03771E5-488A-449F-B886-19C581B63CDE"), Value = 1.24 },
        //         //Factor - Product novelty for the developer's company(PREC)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("05f60293-444f-44c0-9ed4-6d481f565f22"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 6.2 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("c8003f13-5dad-401a-a001-bdf333f506ca"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.96 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("80ba2fb4-b9f1-4888-8469-8c4dbdc9ac33"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.72 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("cb749915-4840-4ec7-8973-6587fd5f6552"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.48 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("d6d54404-f706-4535-af13-82bd6c0c3680"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.24 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("f73396af-6176-468d-abf3-d16555c63c3c"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("15140CFD-EACC-41F3-AAE5-718980DA88B9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
        //         //Factor - Development flexibility(FLEX)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("80835d99-cec6-454c-b490-52e484f094cb"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 5.07 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("5e1378ea-d04f-47af-a161-b3aa5232c713"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.05 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("cf453f03-5479-4396-ae8f-8d8f7bfa9283"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.04 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("0f4e8272-fe20-4665-b1c7-40358219826d"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.03 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("218cc659-82f0-4843-94f0-702a5dfaeee2"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.01 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("26bb242d-fe62-4865-9b7e-74ecd8c85eb1"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("B4A2B0B2-35C4-41D4-8CA7-1D2EBD1440E9"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
        //         //Factor - Level of risk/architecture management (%)(RESL)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("f1bdbe86-1a83-4d68-99d6-bc5a2abcdc9a"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 7.07 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("7f72fb34-c1ea-4df6-9777-09cc50f20737"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 5.65 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("929ee2d0-b285-4c30-bf89-e371058ea6a8"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.24 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("a1b726ed-b26e-4f23-8132-eee2438f2969"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.83 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("d6e01529-603a-40c8-95e8-33548f52de0f"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.41 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("44666184-1e47-4bcd-bbe3-60bfbfec5c9e"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("186476D2-772B-4EB1-B140-B0C1A238AE11"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
        //         //Factor - Cohesion of the development team(TEAM)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("c3dc44c9-1fbe-4630-bf9c-1f809a0519b9"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 5.48 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("2fef6711-824d-4a7e-bc76-df7951b3d211"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.38 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("5602f52e-029d-41ca-84a4-240f70edf8c5"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.29 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("d8f6e657-47d8-45eb-8cfa-50ef7f3b9094"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 2.19 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("e77e1650-444e-4363-a3f2-1cb04ccb7b83"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.1 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("50e9950f-e449-425b-b2c4-00416bfd7002"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("74B32655-E330-4E74-A1A2-E1E92023F676"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
        //         //Factor - Technology maturity maturity process development(PMAT)
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("dba6f127-5c75-4e38-8546-34e42089f6dd"), DifficultyLevelId = new Guid("0C5FD362-B14D-4186-BEF9-979ED21B9575"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 7.8 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("158ebafb-d831-408c-a7db-989c3674a5d7"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 6.24 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("101f9ac2-462a-4e73-bff3-d2de9bd39c26"), DifficultyLevelId = new Guid("B29FA523-BD56-48BE-9ADC-CBD23F0AF646"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 4.68 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("a0229597-864b-49e7-ab48-e8bacd811ebf"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 3.12 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("b27a1cf4-8043-4a26-a149-4bbac0efa9d7"), DifficultyLevelId = new Guid("F5AD4A31-A240-41BD-BFFD-245103B88D0F"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 1.56 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("c339e10e-0121-49b7-93e6-2a9e29a99b9b"), DifficultyLevelId = new Guid("C15C008F-F7F4-4DAE-95BB-02A32BB2B8B1"), FactorId = new Guid("C69EDB03-4FB6-4071-BCC5-F158808C69EE"), FactorTypeId = new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"), Value = 0 },
        //         //Factor - Internal logical object
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("79e53275-6e20-41a9-ae04-1f7cec1ec9e1"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 7 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("ad714742-d8bf-4a86-839e-9fd98822ba87"), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 10 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("98ef60ad-14da-422a-b24c-9f3eb6d58648"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("E777B5BF-559D-4194-A711-89CA4CA4A212"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 15 },
        //         //Factor - External interface object
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("226f4f9f-8563-437d-859b-b0bdf72e74d1"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 5 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("61df3738-c7c6-4dd5-95e3-aac57b78062a"), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 7 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("bdeb4acc-667c-4ee9-a9db-8d20fd1d68eb"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("D7C7BEEA-3351-482B-82E1-8DF4573395B9"), FactorTypeId = new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"), Value = 10 },
        //         //Factor - External input
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("ff79e6d5-606d-4d9f-a046-0157ff60de8c"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 3 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("d244f6c3-2695-4a18-9ecf-7aeb9e3ad1f3"), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 4 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("47eab601-4c65-405a-91b5-21bcc1a5acec"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("73A3A716-F447-4057-99CA-1500D438BA58"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 6 },
        //         //Factor - External output
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("08386350-d2bb-48d8-894a-9f8f25fe00de"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 4 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("089ffa0a-9691-4038-89f2-d0febb22058a"), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 5 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("c9e269e2-9faf-4e99-8066-08ee3c8b01d7"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("31F2F6D6-A5FA-4DA3-ADCF-0A5CC237EB95"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 7 },
        //         //Factor - External request
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("df789397-c69c-4305-b33c-c49af5f8fa3a"), DifficultyLevelId = new Guid("FC6EA190-24A2-42D0-B2AA-783758EFA82D"), FactorId = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 3 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("66744342-2820-4fbf-9f97-917f3099647b"), DifficultyLevelId = new Guid("5540D80E-8FAE-4AFB-A475-B49C1A9C4C2E"), FactorId = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 4 },
        //         new DifficultyLevelsTypeToFactorType { Id = new Guid("cc0ca9a0-e14d-468a-8ca1-a58f23aaeda3"), DifficultyLevelId = new Guid("1AA2EF63-41DB-4F3D-AACD-E38C7E4639AC"), FactorId = new Guid("7A540A8B-0198-40D8-9185-2E02BA5EB1AB"), FactorTypeId = new Guid("63715754-CDFB-4320-9C17-72648673CB4B"), Value = 6 }
        //     );
        // }
    }
}