using ITProjectPriceCalculationManager.Core.DTO;
using ITProjectPriceCalculationManager.Core.Enums;

namespace ITProjectPriceCalculationManager.Core.Services
{
    public class CalculateService
    {
        public async void Calculate()
        {

        }

        private void AlbrehtMethodCalculate(ApplicationDTO application)
        {
            double ksloc = 0;
            double developmentAverageComplexity;

            foreach(var programsParametr in application.ProgramsParametrs)
            {
                ksloc += programsParametr.SLOC * CountUOF(programsParametr.SubjectAreaElements);
            }

            developmentAverageComplexity = CountDevelopmentAverageComplexity(application.InfluenceFactors, application.ScaleFactors, ksloc);
        }

        private double CountUOF(List<SubjectAreaElementDTO> subjectAreaElements)
        {
            double sum = 0;

            foreach(var subjectAreaElement in subjectAreaElements)
            {
                if(subjectAreaElement.ConditionalUnitsOfFunctionality == ConditionalUnitsOfFunctionality.InformationObjects)
                {
                    sum = sum + subjectAreaElement.Count * subjectAreaElement.DifficultyLevel;
                }
                else
                {
                    sum = sum + subjectAreaElement.DifficultyLevel;
                }
            }

            return sum;
        }

        private double CountB(List<ScaleFactorDTO> scaleFactors)
        {
            double sumScaleFactors = 0;

            foreach(var scaleFactor in scaleFactors)
            {
                sumScaleFactors = sumScaleFactors + scaleFactor.Count;
            }

            return 0.91 + sumScaleFactors * 0.01;
        }

        private double CountDevelopmentAverageComplexity(List<InfluenceFactorDTO> influenceFactors, List<ScaleFactorDTO> scaleFactors, double ksloc)
        {
            double sumInfluenceFactors = 1;

            foreach(var influenceFactor in influenceFactors)
            {
                sumInfluenceFactors = sumInfluenceFactors * influenceFactor.Count;
            }

            return 2.94 * sumInfluenceFactors * Math.Pow(ksloc, CountB(scaleFactors));
        }
    }
}