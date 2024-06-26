using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Stub;

public class StubApplicationService : IApplicationService
{
    public Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO dto)
    {
        return Task.FromResult(
            new ApplicationDTO
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                StatusName = "New",
                Price = 200,
                Profit = 100,
                Overhead = 50,
                SocialInsurance = 20,
                AverageCostLabor = 10,
                Description = "",
                ScaleFactors = new List<FactorDTO>(),
                InfluenceFactors = new List<FactorDTO>(),
                AverageMonthlyRateWorkingHours = 5,
                EvaluationFactors = new List<EvaluationFactorDTO>(),
                ProgramsParametrs = new List<ProgramsParametrDTO>(),
                ProgramsParametrEvaluationFactorDTO = new List<ProgramsParametrEvaluationFactorDTO>()
            });
    }

    public Task<ApplicationDTO> DeleteApplicationAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync()
    {
        return Task.FromResult<IEnumerable<ApplicationDTO>>(new List<ApplicationDTO>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                StatusName = "New",
                Price = 200,
                Profit = 100,
                Overhead = 50,
                SocialInsurance = 20,
                AverageCostLabor = 10,
                Description = "",
                ScaleFactors = new List<FactorDTO>(),
                InfluenceFactors = new List<FactorDTO>(),
                AverageMonthlyRateWorkingHours = 5,
                EvaluationFactors = new List<EvaluationFactorDTO>(),
                ProgramsParametrs = new List<ProgramsParametrDTO>(),
                ProgramsParametrEvaluationFactorDTO = new List<ProgramsParametrEvaluationFactorDTO>()
            }
        });
    }

    public Task<ApplicationDTO> GetApplicationsByIdAsync(Guid id)
    {
        return Task.FromResult(
            new ApplicationDTO
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                StatusName = "New",
                Price = 200,
                Profit = 100,
                Overhead = 50,
                SocialInsurance = 20,
                AverageCostLabor = 10,
                Description = "",
                ScaleFactors = new List<FactorDTO>(),
                InfluenceFactors = new List<FactorDTO>(),
                AverageMonthlyRateWorkingHours = 5,
                EvaluationFactors = new List<EvaluationFactorDTO>(),
                ProgramsParametrs = new List<ProgramsParametrDTO>(),
                ProgramsParametrEvaluationFactorDTO = new List<ProgramsParametrEvaluationFactorDTO>()
            });
    }

    public Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicationDTO> GetApplicationAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}