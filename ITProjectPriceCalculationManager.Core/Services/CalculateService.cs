using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Core.Helpers.CalculateMethods;

namespace ITProjectPriceCalculationManager.Core.Services
{
    public class CalculateService
    {
        public void AlbrehtMethodCalculate(ApplicationDTO application)
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
        }
    }
}