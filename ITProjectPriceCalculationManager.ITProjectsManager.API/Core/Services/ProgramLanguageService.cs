using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class ProgramLanguageService : BaseService<ProgramLanguage, int, ProgramLanguageDTO>, IProgramLanguageService
    {
        public ProgramLanguageService(IRepository<ProgramLanguage, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IEnumerable<ProgramLanguageDTO>> GetProgramLanguagesAsync()
        {
            return await base.GetEntitysAsync();
        }
    }
}