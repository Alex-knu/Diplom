using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Stub
{
    public class StubCalculateService : ICalculateService
    {
        public Task<ApplicationDTO> AlbrehtMethodCalculate(ApplicationDTO application)
        {
            return Task.FromResult(new ApplicationDTO()
            {
                Id = 1,
                Price = 200,
                Profit = 100,
                Overhead = 50,
                SocialInsurance = 20,
                AverageCostLabor = 10,
                AverageMonthlyRateWorkingHours = 5,
                ScaleFactors = new List<FactorDTO>(),
                InfluenceFactors = new List<FactorDTO>(),
                ProgramsParametrs = new List<ProgramsParametrDTO>()
            });
        }
    }
}