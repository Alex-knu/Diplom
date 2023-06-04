using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class BaseApplicationService : BaseService<Application, Guid, BaseApplicationDTO>, IBaseApplicationService
    {
        protected readonly IRepository<Evaluator, Guid> _estimatorRepository;
        protected readonly IRepository<ProgramsParametr, Guid> _programsParametrRepository;
        protected readonly ITProjectPriceCalculationManagerDbContext _dbContext;
        protected readonly DbSet<Application> _dbSet;

        public BaseApplicationService(IRepository<Evaluator, Guid> estimatorRepository, IRepository<ProgramsParametr, Guid> programsParametrRepository, IRepository<Application, Guid> repository, IMapper mapper, ITProjectPriceCalculationManagerDbContext dbContext) : base(repository, mapper)
        {
            _estimatorRepository = estimatorRepository;
            _programsParametrRepository = programsParametrRepository;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Application>();
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
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", "821aeb96-b3c6-9df3-3239-9f631189caee")
            };

            await base.GetEntitysAsync();

            _dbSet.FromSqlInterpolated($"EXEC dbo.GetApplicationsByCreator @userId = '25322299-6C3B-4157-B83A-D806DAC59F32'");
            return _mapper.Map<List<BaseApplicationDTO>>(_dbSet.FromSqlInterpolated($"EXEC dbo.GetApplicationsByCreator @userId = '25322299-6C3B-4157-B83A-D806DAC59F32'"));
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
                var domainCreator = await _estimatorRepository.GetFirstBySpecAsync(new Evaluators.GetEstimatorByUserId(baseApplication.UserCreatorId));

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