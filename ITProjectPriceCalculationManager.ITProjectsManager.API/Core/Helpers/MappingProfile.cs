using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationForEvaluation;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationStatus;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using DifficultyLevelsType =
    ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType.DifficultyLevelsType;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Helpers;

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
        CreateMap<ApplicationToEstimatorsDTO, ApplicationToEvaluator>().ReverseMap();
        CreateMap<Application, BaseApplicationDTO>();
        CreateMap<BaseApplicationDTO, Application>();
        CreateMap<ProcedureApplication, BaseApplicationDTO>()
            .ForMember(a => a.StatusName,
                map => map.MapFrom((src, dest, memb) =>
                {
                    return !string.IsNullOrEmpty(src.StatusName) ? src.StatusName :
                        src.Status != null ? src.Status.Name : string.Empty;
                }));
        CreateMap<ProgramsParametr, ProgramsParametrEvaluationFactorDTO>()
            .ForMember(a => a.Id, map => map.MapFrom((src, dest, memb) => { return src.ProgramLanguage?.Id; }))
            .ForMember(a => a.SLOC, map => map.MapFrom((src, dest, memb) => { return src.ProgramLanguage?.SLOC; }));
        CreateMap<EvaluationAttribute, EvaluationParametrsInfoDTO>()
            .ForMember(a => a.FactorTypeId, map => map.MapFrom((src, dest, memb) =>
            {
                if (src.FactorTypeId == new Guid("B03771E5-488A-449F-B886-19C581B63CDE"))
                    return (int)FactorType.InfluenceFactors;
                if (src.FactorTypeId == new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998"))
                    return (int)FactorType.InformationObject;
                if (src.FactorTypeId == new Guid("EB8F98D6-1C46-4721-9AD6-C464B9029905"))
                    return (int)FactorType.ScaleFactors;
                if (src.FactorTypeId == new Guid("63715754-CDFB-4320-9C17-72648673CB4B"))
                    return (int)FactorType.Function;

                return 0;
            }));
    }
}