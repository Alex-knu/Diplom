using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class BaseApplicationService : BaseService<Application, int, BaseApplicationDTO>, IBaseApplicationService
    {
        protected readonly IRepository<Estimator, int> _estimatorRepository;
        public BaseApplicationService(IRepository<Estimator, int> estimatorRepository, IRepository<Application, int> repository, IMapper mapper) : base(repository, mapper)
        {
            _estimatorRepository = estimatorRepository;
        }

        public async Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            await SetCreatorId(baseApplication);
            
            return await base.CreateEntityAsync(baseApplication);
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
    }
}