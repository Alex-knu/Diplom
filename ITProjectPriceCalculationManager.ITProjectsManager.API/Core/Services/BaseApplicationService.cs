using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.Extentions.Models;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class BaseApplicationService : BaseService<Application, Guid, BaseApplicationDTO, ITProjectPriceCalculationManagerDbContext>, IBaseApplicationService
{
    protected readonly IRepository<Evaluator, Guid, ITProjectPriceCalculationManagerDbContext> _estimatorRepository;
    protected readonly IRepository<ApplicationView, Guid, ITProjectPriceCalculationManagerDbContext> _applicationViewRepository;

    public BaseApplicationService(
        IRepository<Evaluator, Guid, ITProjectPriceCalculationManagerDbContext> estimatorRepository,
        IRepository<ApplicationView, Guid, ITProjectPriceCalculationManagerDbContext> applicationViewRepository,
        IRepository<Application, Guid, ITProjectPriceCalculationManagerDbContext> repository,
        IMapper mapper) : base(repository, mapper)
    {
        _estimatorRepository = estimatorRepository;
        _applicationViewRepository = applicationViewRepository;
    }

    public async Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
    {
        return await CreateEntityAsync(baseApplication);
    }

    public async Task<BaseApplicationDTO> DeleteBaseApplicationAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public async Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync(HttpContext httpContext)
    {
        return await ExecuteSqlProcedure(JwtUtils.GetUserInfo(httpContext));
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
            var domainCreator =
                await _estimatorRepository.GetFirstBySpecAsync(
                    new Evaluators.GetEvaluatorByUserId(baseApplication.UserCreatorId));

            if (domainCreator == null)
            {
                throw new BadHttpRequestException("Creator not found");
            }

            var domainApplication = _mapper.Map<Application>(baseApplication);

            domainApplication.CreatorId = domainCreator.Id;
            domainApplication.Status = null;

            var newDomainApplication = await _repository.AddAsync(domainApplication);

            await _repository.SaveChangesAcync();

            return _mapper.Map<BaseApplicationDTO>(newDomainApplication);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private async Task<IEnumerable<BaseApplicationDTO>> ExecuteSqlProcedure(UserInfo userInfo)
    {
        var result = new List<ApplicationView>();

        if (userInfo.Roles.Contains("User") || userInfo.Roles.Contains("Evaluator"))
        {
            result.AddRange((await _applicationViewRepository.GetAllAsync())
            .Where(a => a.CreatorUserId == userInfo.UserId || a.EvaluatorUserId == userInfo.UserId));
        }

        if (userInfo.Roles.Contains("Admin"))
        {
            result.AddRange(await _applicationViewRepository.GetAllAsync());
        }
        return _mapper.Map<IEnumerable<BaseApplicationDTO>>(result.DistinctBy(application => application.Id));
    }
}