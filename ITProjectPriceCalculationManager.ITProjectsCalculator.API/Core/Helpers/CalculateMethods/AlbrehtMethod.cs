using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.ExpertMethods;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods
{
    internal class AlbrehtMethod : CalculateMethod
    {
        public override async Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price)
        {
            double ksloc = 0;
            EvaluationResultDTO result = new EvaluationResultDTO();
            BaseDelphiTechnique tehnique = SetStrategy(evaluation);

            try
            {
                foreach (var programsParametr in evaluation.ProgramsParametrEvaluationFactorDTO)
                {
                    ksloc += programsParametr.SLOC * CountUOF(GetFactors(programsParametr.SubjectAreaElements), evaluation.ConfidenceArea, tehnique);
                }

                price = CountAverageCostWageFund(evaluation, ksloc, tehnique);

                result = await base.Calculate(evaluation, price);
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        private double CountUOF(IEnumerable<IGrouping<Guid, EvaluationFactorDTO>> subjectAreaElements, double? confidenceArea, BaseDelphiTechnique tehnique)
        {
            double sum = 0;

            foreach (var subjectAreaElement in subjectAreaElements)
            {
                var result = tehnique.CheckFactors(subjectAreaElement.ToList(), confidenceArea);

                sum = sum + result.FactorValue * result.Count.Value;
            }

            return sum;
        }

        private double CountAverageCostWageFund(EvaluationDTO evaluation, double ksloc, BaseDelphiTechnique tehnique)
        {
            return (152 * evaluation.AverageCostLabor * CountDevelopmentAverageComplexity(evaluation.EvaluationFactors, ksloc, evaluation.ConfidenceArea, tehnique)) / evaluation.AverageMonthlyRateWorkingHours;
        }

        private double CountDevelopmentAverageComplexity(List<EvaluationFactorDTO> evaluations, double ksloc, double? confidenceArea, BaseDelphiTechnique tehnique)
        {
            double productInfluenceFactors = 1;

            foreach (var influenceFactors in GetFactors(evaluations.Where(e => e.FactorType == FactorType.InfluenceFactors)))
            {
                var result = tehnique.CheckFactors(influenceFactors.ToList(), confidenceArea);

                if (!string.IsNullOrEmpty(result.Error))
                {
                    return 0;
                }

                productInfluenceFactors = productInfluenceFactors * result.FactorValue;
            }

            return 2.94 * productInfluenceFactors * Math.Pow(ksloc, CountB(GetFactors(evaluations.Where(e => e.FactorType == FactorType.ScaleFactors)), confidenceArea, tehnique));
        }

        private double CountB(IEnumerable<IGrouping<Guid, EvaluationFactorDTO>> evaluations, double? confidenceArea, BaseDelphiTechnique tehnique)
        {
            double sumScaleFactors = 0;

            foreach (var scaleFactor in evaluations)
            {
                var result = tehnique.CheckFactors(scaleFactor.ToList(), confidenceArea);

                if (!string.IsNullOrEmpty(result.Error))
                {
                    return 0;
                }

                sumScaleFactors = sumScaleFactors + result.FactorValue;
            }

            return 0.91 + sumScaleFactors * 0.01;
        }

        private IEnumerable<IGrouping<Guid, EvaluationFactorDTO>> GetFactors(IEnumerable<EvaluationFactorDTO> evaluations)
        {
            return from evaluation in evaluations group evaluation by evaluation.FactorId;
        }

        private BaseDelphiTechnique SetStrategy(EvaluationDTO evaluation)
        {
            if (evaluation.ConfidenceArea.HasValue)
            {
                return new DelphiTechniqueWithConfidenceArea();
            }
            else
            {
                return new DelphiTechniqueWithCoefficientVariations();
            }
        }
    }
}