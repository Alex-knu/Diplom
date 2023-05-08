using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.Enums;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods
{
    internal static class AlbrehtMethod
    {
        public static double CountAverageCostWageFund(double averageCostLabor, double developmentAverageComplexity, double averageMonthlyRateWorkingHours)
        {
            return (152 * averageCostLabor * developmentAverageComplexity) / averageMonthlyRateWorkingHours;
        }

        private static double CountB(List<FactorDTO> scaleFactors)
        {
            double sumScaleFactors = 0;

            foreach(var scaleFactor in scaleFactors)
            {
                sumScaleFactors = sumScaleFactors + scaleFactor.Value;
            }

            return 0.91 + sumScaleFactors * 0.01;
        }

        public static double CountDevelopmentAverageComplexity(List<FactorDTO> influenceFactors, List<FactorDTO> scaleFactors, double ksloc)
        {
            double sumInfluenceFactors = 1;

            foreach(var influenceFactor in influenceFactors)
            {
                sumInfluenceFactors = sumInfluenceFactors * influenceFactor.Value;
            }

            return 2.94 * sumInfluenceFactors * Math.Pow(ksloc, CountB(scaleFactors));
        }

        public static double CountUOF(List<SubjectAreaElementDTO> subjectAreaElements)
        {
            double sum = 0;

            foreach(var subjectAreaElement in subjectAreaElements)
            {
                switch (subjectAreaElement.ConditionalUnitsOfFunctionality)
                {
                    case ConditionalUnitsOfFunctionality.InformationObjects:
                        sum = sum + subjectAreaElement.Count * subjectAreaElement.DifficultyLevel;
                        break;
                    case ConditionalUnitsOfFunctionality.Functions:
                        sum = sum + subjectAreaElement.DifficultyLevel;
                        break;
                }
            }

            return sum;
        }
    }
}