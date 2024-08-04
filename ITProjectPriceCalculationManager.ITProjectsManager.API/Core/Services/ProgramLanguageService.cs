using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ProgramLanguageService : BaseService<ProgramLanguage, Guid, ProgramLanguageDTO, ITProjectPriceCalculationManagerDbContext>, IProgramLanguageService
{
    public ProgramLanguageService(IRepository<ProgramLanguage, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<ProgramLanguageDTO>> GetAllProgramLanguagesByApplicationId(Guid applicationId)
    {
        return _mapper.Map<List<ProgramLanguageDTO>>(
            await _repository.ExecuteStoredProcedure(
                $"EXEC dbo.GetAllProgramLanguagesByApplicationId @applicationId = {applicationId}"));
    }

    public async Task<IEnumerable<ProgramLanguageDTO>> GetProgramLanguagesAsync()
    {
        return await base.GetEntitysAsync();
    }
}