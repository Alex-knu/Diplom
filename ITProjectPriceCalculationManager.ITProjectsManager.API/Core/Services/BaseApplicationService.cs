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
    protected readonly IRepository<ProcedureApplication, Guid, ITProjectPriceCalculationManagerDbContext> _procedureApplicationRepository;

    public BaseApplicationService(
        IRepository<Evaluator, Guid, ITProjectPriceCalculationManagerDbContext> estimatorRepository,
        IRepository<ProcedureApplication, Guid, ITProjectPriceCalculationManagerDbContext> procedureApplicationRepository,
        IRepository<Application, Guid, ITProjectPriceCalculationManagerDbContext> repository,
        IMapper mapper) : base(repository, mapper)
    {
        _estimatorRepository = estimatorRepository;
        _procedureApplicationRepository = procedureApplicationRepository;
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
        var result = new List<ProcedureApplication>();

        foreach (var role in userInfo.Roles)
            switch (role)
            {
                case "User":
                    result.AddRange(
                        await _procedureApplicationRepository.ExecuteStoredProcedure(
                            $"EXEC dbo.GetApplicationsByCreator @userId = {userInfo.UserId}"));
                    break;
                case "Evaluator":
                    result.AddRange(
                        await _procedureApplicationRepository.ExecuteStoredProcedure(
                            $"EXEC dbo.GetApplicationsByEvaluator @userId = {userInfo.UserId}"));
                    break;
                case "Admin":
                    result.AddRange(
                        await _procedureApplicationRepository.ExecuteStoredProcedure(
                            $"EXEC dbo.GetApplicationsByAdmin"));
                    break;
            }

        return _mapper.Map<List<BaseApplicationDTO>>(result.DistinctBy(application => application.Id));
    }
}