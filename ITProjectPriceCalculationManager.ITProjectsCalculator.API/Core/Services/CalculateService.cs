using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Services
{
    internal class CalculateService : ICalculateService
    {
        public Task<ApplicationDTO> AlbrehtMethodCalculate(ApplicationDTO application)
        {
            
            double ksloc = 0;

            foreach(var programsParametr in application.ProgramsParametrs)
            {
                ksloc += programsParametr.SLOC * AlbrehtMethod.CountUOF(programsParametr.SubjectAreaElements);
            }
            
            application.Price = AlbrehtMethod.CountAverageCostWageFund(application.AverageCostLabor, 
                                                                                AlbrehtMethod.CountDevelopmentAverageComplexity(application.InfluenceFactors, application.ScaleFactors, ksloc), 
                                                                                application.AverageMonthlyRateWorkingHours);

            application.Price = application.Price * application.Overhead + application.Price * application.Profit + application.Price * application.SocialInsurance;
            
            return Task.FromResult(application);
        }
    }
}