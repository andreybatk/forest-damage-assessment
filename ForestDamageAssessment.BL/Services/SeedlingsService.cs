using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class SeedlingsService : ISeedlingsService
    {
        private const double _mainCoefficient = 5D;

        public SeedlingData Calculate(int[] count, string[] breed, string[] price)
        {
            var seedlingData = new SeedlingData();

            seedlingData.ModelList = new List<SeedlingViewModel>();
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < count.Length; i++)
            {
                double.TryParse(price[i], culture, out double currentPrice);
                var money = currentPrice * Convert.ToDouble(count[i]);
                var model = new SeedlingViewModel { Count = count[i], Breed = breed[i], Price = currentPrice, Money = money };
                seedlingData.ModelList.Add(model);
            }

            CalculateTotalMoneyPunishment(seedlingData);
            return seedlingData;
        }
        private void CalculateTotalMoneyPunishment(SeedlingData seedlingData)
        {
            seedlingData.TotalMoney = seedlingData.ModelList.Select(x => x.Money).Sum();

            var totalMoneyWithCoeff = seedlingData.TotalMoney;
            totalMoneyWithCoeff *= _mainCoefficient;
            seedlingData.Coefficients.Add($"Коэффициент основной ({_mainCoefficient}):", totalMoneyWithCoeff);
        }
    }
}