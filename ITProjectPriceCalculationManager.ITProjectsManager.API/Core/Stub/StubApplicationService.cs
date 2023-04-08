using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Stub
{
    public class StubApplicationService : IApplicationService
    {
        public Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationDTO> DeleteApplicationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationDTO> GetApplicationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationDTO> GetApplicationsByIdAsync(int id)
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
                ScaleFactors = new List<ScaleFactorDTO>(),
                InfluenceFactors = new List<InfluenceFactorDTO>(),
                ProgramsParametrs = new List<ProgramsParametrDTO>()
            });
        }

        public Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query)
        {
            throw new NotImplementedException();
        }
    }
}