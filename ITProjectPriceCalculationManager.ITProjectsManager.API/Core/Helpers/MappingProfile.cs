using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BaseApplicationDTO, Application>().ReverseMap();
        CreateMap<BaseApplicationDTO, Application>().ReverseMap();
        CreateMap<EvaluatorDTO, Evaluator>().ReverseMap();
        CreateMap<DepartmentDTO, Department>().ReverseMap();
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
    }
}