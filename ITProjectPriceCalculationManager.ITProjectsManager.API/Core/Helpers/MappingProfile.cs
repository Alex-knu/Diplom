using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseApplicationDTO, Application>().ReverseMap();
            CreateMap<ApplicationDTO, Application>().ReverseMap();
            CreateMap<EvaluatorDTO, Estimator>().ReverseMap();
        }
    }
}