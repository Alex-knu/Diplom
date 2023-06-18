using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationForEvaluation;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationStatus;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseApplicationDTO, Application>().ReverseMap();
            CreateMap<ApplicationDTO, Application>().ReverseMap();
            CreateMap<EvaluatorDTO, Evaluator>().ReverseMap();
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<ProgramLanguageDTO, ProgramLanguage>().ReverseMap();
            CreateMap<DifficultyLevelsTypeDTO, DifficultyLevelsType>().ReverseMap();
            CreateMap<ApplicationToFactorsDTO, ApplicationToFactor>().ReverseMap();
            CreateMap<DifficultyLevelsTypeDTO, DifficultyLevel>().ReverseMap();
            CreateMap<ApplicationForEvaluation, EvaluationDTO>();
            CreateMap<Application, BaseApplicationDTO>();
            CreateMap<BaseApplicationDTO, Application>()
            .ForMember(a => a.Status, map => map.MapFrom((src, dest, memb) =>
                {
                    return new ApplicationStatus()
                    {
                        Id = src.StatusId
                    };
                }));
            CreateMap<ProcedureApplication, BaseApplicationDTO>()
            .ForMember(a => a.StatusName, map => map.MapFrom((src, dest, memb) =>
                {
                    return !string.IsNullOrEmpty(src.StatusName) ? src.StatusName : src.Status != null ? src.Status.Name : string.Empty;
                }));
            CreateMap<ProgramsParametr, ProgramsParametrEvaluationFactorDTO>()
            .ForMember(a => a.Id, map => map.MapFrom((src, dest, memb) =>
                {
                    return src.ProgramLanguage.Id;
                }))
            .ForMember(a => a.SLOC, map => map.MapFrom((src, dest, memb) =>
                {
                    return src.ProgramLanguage.SLOC;
                }));
            CreateMap<EvaluationAttribute, EvaluationParametrsInfoDTO>()
            .ForMember(a => a.FactorTypeId, map => map.MapFrom((src, dest, memb) =>
                {
                    if (src.FactorTypeId == new Guid("B03771E5-488A-449F-B886-19C581B63CDE"))
                    {
                        return (int)DTOModels.Enums.FactorType.InfluenceFactors;
                    }
                    else if (src.FactorTypeId == new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"))
                    {
                        return (int)DTOModels.Enums.FactorType.InformationObject;
                    }
                    else if (src.FactorTypeId == new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"))
                    {
                        return (int)DTOModels.Enums.FactorType.ScaleFactors;
                    }
                    else if (src.FactorTypeId == new Guid("63715754-CDFB-4320-9C17-72648673CB4B"))
                    {
                        return (int)DTOModels.Enums.FactorType.Function;
                    }

                    return 0;
                }));
            // CreateMap<FactorType, DTOModels.Enums.FactorType>()
            // .ForMember(a => a, map => map.MapFrom((src, dest, memb) =>
            // {
            //     if (src.Id == new Guid("B03771E5-488A-449F-B886-19C581B63CDE"))
            //     {
            //         return DTOModels.Enums.FactorType.InfluenceFactors;
            //     }
            //     else if (src.Id == new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"))
            //     {
            //         return DTOModels.Enums.FactorType.InformationObject;
            //     }
            //     else if (src.Id == new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"))
            //     {
            //         return DTOModels.Enums.FactorType.ScaleFactors;
            //     }
            //     else //if (src.Id == new Guid("63715754-CDFB-4320-9C17-72648673CB4B"))
            //     {
            //         return DTOModels.Enums.FactorType.Function;
            //     }
            // }));
        }
    }
}