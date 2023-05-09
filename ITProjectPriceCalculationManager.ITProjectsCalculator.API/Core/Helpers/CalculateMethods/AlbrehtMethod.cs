using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.ExpertMethods;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.CalculateMethods;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods
{
    internal class AlbrehtMethod : ICalculateMethod
    {
        public Task<ApplicationDTO> Calculate(ApplicationDTO application)
        {

            double ksloc = 0;

            foreach (var programsParametr in application.ProgramsParametrEvaluationFactorDTO)
            {
                ksloc += programsParametr.SLOC * CountUOF(GetFactors(programsParametr.SubjectAreaElements), application.ConfidenceArea);
            }

            application.Price = CountAverageCostWageFund(application, ksloc);

            application.Price = application.Price * application.Overhead + application.Price * application.Profit + application.Price * application.SocialInsurance;

            return Task.FromResult(application);
        }

        private double CountUOF(IEnumerable<IGrouping<string, EvaluationFactorDTO>> subjectAreaElements, double? confidenceArea)
        {
            double sum = 0;

            foreach (var subjectAreaElement in subjectAreaElements)
            {
                var result = (new DelphiTechnique()).CheckFactors(subjectAreaElement.ToList(), confidenceArea.Value);

                if(!string.IsNullOrEmpty(result.Error))
                {
                    return 0;
                }

                sum = sum + result.FactorValue * result.Count.Value;
            }

            return sum;
        }

        private double CountAverageCostWageFund(ApplicationDTO application, double ksloc)
        {
            return (152 * application.AverageCostLabor * CountDevelopmentAverageComplexity(application.EvaluationFactors, ksloc, application.ConfidenceArea)) / application.AverageMonthlyRateWorkingHours;
        }

        private double CountDevelopmentAverageComplexity(List<EvaluationFactorDTO> evaluations, double ksloc, double? confidenceArea)
        {
            double productInfluenceFactors = 1;

            foreach(var influenceFactors in GetFactors(evaluations.Where(e => e.FactorType == FactorType.InfluenceFactors)))
            {
                var result = (new DelphiTechnique()).CheckFactors(influenceFactors.ToList(), confidenceArea.Value);

                if(!string.IsNullOrEmpty(result.Error))
                {
                    return 0;
                }

                productInfluenceFactors = productInfluenceFactors * result.FactorValue;
            }

            return 2.94 * productInfluenceFactors * Math.Pow(ksloc, CountB(GetFactors(evaluations.Where(e => e.FactorType == FactorType.ScaleFactors)), confidenceArea));
        }

        private double CountB(IEnumerable<IGrouping<string, EvaluationFactorDTO>> evaluations, double? confidenceArea)
        {
            double sumScaleFactors = 0;

            foreach (var scaleFactor in evaluations)
            {
                var result = (new DelphiTechnique()).CheckFactors(scaleFactor.ToList(), confidenceArea.Value);

                if(!string.IsNullOrEmpty(result.Error))
                {
                    return 0;
                }

                sumScaleFactors = sumScaleFactors + result.FactorValue;
            }

            return 0.91 + sumScaleFactors * 0.01;
        }

        private IEnumerable<IGrouping<string, EvaluationFactorDTO>> GetFactors(IEnumerable<EvaluationFactorDTO> evaluations)
        {
            return from evaluation in evaluations group evaluation by evaluation.Name;
        }
    }
}