using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseApplicationDTO, Application>().ReverseMap();
            CreateMap<ApplicationDTO, Application>().ReverseMap();
            CreateMap<EvaluatorDTO, Estimator>().ReverseMap();
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<ProgramLanguageDTO, ProgramLanguage>().ReverseMap();
        }
    }
}