using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class PlantationFellingService : IPlantationFellingService
    {
        public PlantationData Calculate(string[] square, string[] price, int[] coeff)
        {
            var plantationData = new PlantationData();

            plantationData.ModelList = new List<PlantationViewModel>();
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < coeff.Length; i++)
            {
                double.TryParse(square[i], culture, out double currentSquare);
                double.TryParse(price[i], culture, out double currentPrice);
                var currentCoeff = Convert.ToDouble(coeff[i]);
                var model = new PlantationViewModel { Coeff = currentCoeff, Square = currentSquare, Price = currentPrice};
                plantationData.ModelList.Add(model);
            }

            CalculateTotalMoneyPunishment(plantationData);
            return plantationData;
        }
        private void CalculateTotalMoneyPunishment(PlantationData plantationData)
        {
            foreach (var plantation in plantationData.ModelList)
            {
                plantation.Money = plantation.Price * plantation.Square * plantation.Coeff;
            }

            plantationData.TotalMoney = plantationData.ModelList.Select(x => x.Money).Sum();
        }
    }
}