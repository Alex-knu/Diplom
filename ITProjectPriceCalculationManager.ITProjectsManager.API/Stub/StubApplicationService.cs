using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Stub;

public class StubApplicationService : IApplicationService
{
    public Task<BaseApplicationDTO> CreateApplicationAsync(BaseApplicationDTO dto)
    {

        throw new NotImplementedException();
        // return Task.FromResult(
        //     new BaseApplicationDTO
        //     {
        //         Id = Guid.NewGuid(),
        //         Name = "Test",
        //         StatusName = "New",
        //         Price = 200,
        //         Profit = 100,
        //         Overhead = 50,
        //         SocialInsurance = 20,
        //         AverageCostLabor = 10,
        //         Description = "",
        //         ScaleFactors = new List<FactorDTO>(),
        //         InfluenceFactors = new List<FactorDTO>(),
        //         AverageMonthlyRateWorkingHours = 5,
        //         EvaluationFactors = new List<EvaluationFactorDTO>(),
        //         ProgramsParametrs = new List<ProgramsParametrDTO>(),
        //         ProgramsParametrEvaluationFactorDTO = new List<ProgramsParametrEvaluationFactorDTO>()
        //     });
    }

    public Task<BaseApplicationDTO> DeleteApplicationAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BaseApplicationDTO>> GetApplicationsAsync()
    {

        throw new NotImplementedException();
        // return Task.FromResult<IEnumerable<BaseApplicationDTO>>(new List<BaseApplicationDTO>
        // {
        //     new()
        //     {
        //         Id = Guid.NewGuid(),
        //         Name = "Test",
        //         StatusName = "New",
        //         Price = 200,
        //         Profit = 100,
        //         Overhead = 50,
        //         SocialInsurance = 20,
        //         AverageCostLabor = 10,
        //         Description = "",
        //         ScaleFactors = new List<FactorDTO>(),
        //         InfluenceFactors = new List<FactorDTO>(),
        //         AverageMonthlyRateWorkingHours = 5,
        //         EvaluationFactors = new List<EvaluationFactorDTO>(),
        //         ProgramsParametrs = new List<ProgramsParametrDTO>(),
        //         ProgramsParametrEvaluationFactorDTO = new List<ProgramsParametrEvaluationFactorDTO>()
        //     }
        // });
    }

    public Task<BaseApplicationDTO> GetApplicationsByIdAsync(Guid id)
    {

        throw new NotImplementedException();
        // return Task.FromResult(
        //     new BaseApplicationDTO
        //     {
        //         Id = Guid.NewGuid(),
        //         Name = "Test",
        //         StatusName = "New",
        //         Price = 200,
        //         Profit = 100,
        //         Overhead = 50,
        //         SocialInsurance = 20,
        //         AverageCostLabor = 10,
        //         Description = "",
        //         ScaleFactors = new List<FactorDTO>(),
        //         InfluenceFactors = new List<FactorDTO>(),
        //         AverageMonthlyRateWorkingHours = 5,
        //         EvaluationFactors = new List<EvaluationFactorDTO>(),
        //         ProgramsParametrs = new List<ProgramsParametrDTO>(),
        //         ProgramsParametrEvaluationFactorDTO = new List<ProgramsParametrEvaluationFactorDTO>()
        //     });
    }

    public Task<BaseApplicationDTO> UpdateApplicationAsync(BaseApplicationDTO query)
    {
        throw new NotImplementedException();
    }

    public Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
    {
        throw new NotImplementedException();
    }

    public Task<BaseApplicationDTO> GetApplicationAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}