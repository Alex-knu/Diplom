using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class BaseApplicationService : BaseService<Application, int, BaseApplicationDTO>, IBaseApplicationService
    {
        protected readonly IRepository<Estimator, int> _estimatorRepository;
        protected readonly IRepository<ProgramsParametr, int> _programsParametrRepository;

        public BaseApplicationService(IRepository<Estimator, int> estimatorRepository, IRepository<ProgramsParametr, int> programsParametrRepository, IRepository<Application, int> repository, IMapper mapper) : base(repository, mapper)
        {
            _estimatorRepository = estimatorRepository;
            _programsParametrRepository = programsParametrRepository;
        }

        public async Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            return await CreateEntityAsync(baseApplication);
        }

        public async Task<BaseApplicationDTO> DeleteBaseApplicationAsync(int id)
        {
            return await base.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync()
        {
            return await base.GetEntitysAsync();
        }

        public async Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(int id)
        {
            return await base.GetEntitysByIdAsync(id);
        }

        public async Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            return await base.UpdateEntityAsync(baseApplication);
        }

        private async Task<BaseApplicationDTO> SetCreatorId(BaseApplicationDTO baseApplication)
        {
            try
            {
                var domainCreator = await _estimatorRepository.GetFirstBySpecAsync(new Estimators.GetEstimatorByUserId(baseApplication.UserCreatorId));

                if (domainCreator == null)
                {
                    throw new BadHttpRequestException("Creator not found");
                }

                baseApplication.CreatorId = domainCreator.Id;

                return baseApplication;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected override async Task<BaseApplicationDTO> CreateEntityAsync(BaseApplicationDTO baseApplication)
        {
            try
            {
                var domainCreator = await _estimatorRepository.GetFirstBySpecAsync(new Estimators.GetEstimatorByUserId(baseApplication.UserCreatorId));

                if (domainCreator == null)
                {
                    throw new BadHttpRequestException("Creator not found");
                }

                var domainApplication = _mapper.Map<Application>(baseApplication);
                domainApplication.CreatorId = domainCreator.Id;
                var newDomainApplication = await _repository.AddAsync(domainApplication);

                await _repository.SaveChangesAcync();

                foreach (var programLanguage in baseApplication.ProgramLanguages)
                {
                    await _programsParametrRepository.AddAsync(new ProgramsParametr()
                    {
                        ApplicationId = newDomainApplication.Id,
                        ProgramLanguageId = programLanguage.Id
                    });
                }

                await _programsParametrRepository.SaveChangesAcync();

                return _mapper.Map<BaseApplicationDTO>(newDomainApplication);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}