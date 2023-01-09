using ITProjectPriceCalculationManager.Core.DTO;
using ITProjectPriceCalculationManager.Core.Helpers.CalculateMethods;

namespace ITProjectPriceCalculationManager.Core.Services
{
    public class CalculateService
    {
        public async void Calculate()
        {

        }

        public void AlbrehtMethodCalculate(ApplicationDTO application)
        {
            
            double ksloc = 0;
            double developmentAverageComplexity;

            foreach(var programsParametr in application.ProgramsParametrs)
            {
                ksloc += programsParametr.SLOC * AlbrehtMethod.CountUOF(programsParametr.SubjectAreaElements);
            }

            developmentAverageComplexity = AlbrehtMethod.CountDevelopmentAverageComplexity(application.InfluenceFactors, application.ScaleFactors, ksloc);
            
        }
    }
}