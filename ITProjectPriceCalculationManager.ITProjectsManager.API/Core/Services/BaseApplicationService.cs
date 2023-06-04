using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class BaseApplicationService : BaseService<Application, Guid, BaseApplicationDTO>, IBaseApplicationService
    {
        protected readonly IRepository<Evaluator, Guid> _estimatorRepository;
        protected readonly IRepository<ProgramsParametr, Guid> _programsParametrRepository;

        public BaseApplicationService(IRepository<Evaluator, Guid> estimatorRepository, IRepository<ProgramsParametr, Guid> programsParametrRepository, IRepository<Application, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
            _estimatorRepository = estimatorRepository;
            _programsParametrRepository = programsParametrRepository;
        }

        public async Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            Console.WriteLine(baseApplication.Id);
            return await CreateEntityAsync(baseApplication);
        }

        public async Task<BaseApplicationDTO> DeleteBaseApplicationAsync(Guid id)
        {
            return await base.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync()
        {
            return await base.GetEntitysAsync();
        }

        public async Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(Guid id)
        {
            return await base.GetEntitysByIdAsync(id);
        }

        public async Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            return await base.UpdateEntityAsync(baseApplication);
        }

        protected override async Task<BaseApplicationDTO> CreateEntityAsync(BaseApplicationDTO baseApplication)
        {
            try
            {
                Console.WriteLine($"Creator ID: {baseApplication.UserCreatorId}");
                var domainCreator = (await _estimatorRepository.GetAllAsync()).Where(e => e.UserId == baseApplication.UserCreatorId).FirstOrDefault(); //.GetFirstBySpecAsync(new Evaluators.GetEstimatorByUserId(baseApplication.UserCreatorId));

                if (domainCreator == null)
                {
                    throw new BadHttpRequestException("Creator not found");
                }

                Console.WriteLine($"HAHAHAHAHAHAHAH: {domainCreator.Id}");
                var domainApplication = _mapper.Map<Application>(baseApplication);
                Console.WriteLine($"HAHAHAHAHAHAHAH: {domainCreator.Id}");
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