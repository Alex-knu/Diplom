using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;

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
            CreateMap<ApplicationToFactorsDTO, ApplicationToFactors>().ReverseMap();
            CreateMap<EvaluationParametrsInfoDTO, EvaluationAttribute>().ReverseMap();
            CreateMap<DifficultyLevelsTypeDTO, DifficultyLevel>().ReverseMap();
        }
    }
}