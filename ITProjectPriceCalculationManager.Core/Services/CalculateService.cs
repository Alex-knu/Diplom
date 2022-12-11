using ITProjectPriceCalculationManager.Core.DTO;
using ITProjectPriceCalculationManager.Core.Enums;

namespace ITProjectPriceCalculationManager.Core.Services
{
    public class CalculateService
    {
        public async void Calculate()
        {

        }

        private int AlbrehtMethodCalculate(List<SubjectAreaElementDTO> subjectAreaElements)
        {
            int sum = 0;

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
    }
}