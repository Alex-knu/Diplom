using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BelongingFunctionDTO, BelongingFunction>().ReverseMap();
        CreateMap<EvaluateParameterDTO, EvaluateParameter>().ReverseMap();
        CreateMap<ParametersDTO, Parameters>().ReverseMap();
        CreateMap<ParameterValueDTO, ParameterValue>().ReverseMap();
    }
}