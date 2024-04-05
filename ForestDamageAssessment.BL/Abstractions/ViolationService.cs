using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Abstractions
{
    public abstract class ViolationService
    {
        public ViolationService(IAssortmentRepository assortmentRepository)
        {
            _assortmentRepository = assortmentRepository;
        }

        protected readonly IAssortmentRepository _assortmentRepository;
        protected virtual double MainCoefficient { get; } = 50D;
        protected virtual double Year2024Coefficient { get; } = 3.14;
        protected virtual double OZUCoefficient { get; } = 3D;
        protected virtual double ProtectiveForestsCoefficient { get; } = 2D;
        protected virtual double OOPTtCoefficient { get; } = 5D;

        public async Task CalculateStockAsync<T>(List<T>? modelList)
        {
            try
            {
                if (modelList == null)
                {
                    return;
                }

                var culture = new CultureInfo("en-us");
                List<IViolationViewModel> currentModelList = modelList.Cast<IViolationViewModel>().ToList();

                foreach (var model in currentModelList)
                {
                    var assortment = await _assortmentRepository.GetAssortmentAsync(model.Breed, model.ThicknessLevel.ToString(), model.RankH.ToString());

                    if (assortment == null)
                    {
                        continue;
                    }

                    double.TryParse(assortment.LargeTotal, culture, out double largeTotal);
                    double.TryParse(assortment.VInBark, culture, out double vInBark);
                    double.TryParse(assortment.Average1Total, culture, out double average1Total);
                    double.TryParse(assortment.Average2Total, culture, out double average2Total);
                    double.TryParse(assortment.SmallTotal, culture, out double smallTotal);
                    double.TryParse(assortment.AllBusiness, culture, out double allBusiness);
                    double.TryParse(assortment.FirewoodFuel, culture, out double firewoodFuel);
                    double.TryParse(assortment.Waste, culture, out double waste);

                    model.Stock.VInBark = vInBark;
                    model.Stock.SumLarge = largeTotal * vInBark / 100;
                    model.Stock.SumAverage = (average1Total + average2Total) * vInBark / 100;
                    model.Stock.SumSmall = smallTotal * vInBark / 100;
                    model.Stock.SumBusiness = allBusiness * vInBark / 100;
                    model.Stock.SumFirewood = (firewoodFuel + waste) * vInBark / 100;
                    model.Stock.SumWaste = waste * vInBark / 100;

                    model.Stock.LiquidStock = model.Stock.SumBusiness + model.Stock.SumFirewood;
                    model.Stock.RootStock = model.Stock.SumBusiness + model.Stock.SumFirewood + model.Stock.SumWaste;
                }
            }
            catch (Exception ex)
            {
                //TODO LOGGER
            }
        }
        public void CalculateTotalMoneyPunishment<T>(List<T>? modelList, ForestAreaData? forestAreaData)
        {
            if (modelList == null || forestAreaData == null)
            {
                return;
            }

            List<IViolationViewModel> currentModelList = modelList.Cast<IViolationViewModel>().ToList();

            forestAreaData.TotalRootStock = currentModelList.Select(x => x.Stock)
                .Select(x => x.RootStock)
                .Sum();
            forestAreaData.TotalLiquidStock = currentModelList.Select(x => x.Stock)
                .Select(x => x.LiquidStock)
                .Sum();
            forestAreaData.TotalBusinessMoney = currentModelList.Select(x => x.Money)
                .Select(x => x.Business)
                .Sum();
            forestAreaData.TotalFirewoodMoney = currentModelList.Select(x => x.Money)
                .Select(x => x.Firewood)
                .Sum();
            forestAreaData.TotalBusinessAndFirewoodMoney = currentModelList.Select(x => x.Money)
                .Select(x => x.BusinessAndFirewood)
                .Sum();
            forestAreaData.TotalMoney = forestAreaData.TotalBusinessAndFirewoodMoney;

            if (forestAreaData.IsOZU)
            {
                forestAreaData.TotalMoney *= OZUCoefficient;
                forestAreaData.Coefficients.Add($"Коэффициент за ОЗУ ({OZUCoefficient}):", forestAreaData.TotalMoney);
            }
            if (forestAreaData.IsProtectiveForests)
            {
                forestAreaData.TotalMoney *= ProtectiveForestsCoefficient;
                forestAreaData.Coefficients.Add($"Коэффициент за Защитные леса ({ProtectiveForestsCoefficient}):", forestAreaData.TotalMoney);
            }
            if (forestAreaData.IsOOPT)
            {
                forestAreaData.TotalMoney *= OOPTtCoefficient;
                forestAreaData.Coefficients.Add($"Коэффициент за ООПТ ({OOPTtCoefficient}):", forestAreaData.TotalMoney);
            }

            forestAreaData.TotalMoney *= Year2024Coefficient;
            forestAreaData.Coefficients.Add($"Коэффициент за 2024 год ({Year2024Coefficient}):", forestAreaData.TotalMoney);

            forestAreaData.TotalMoney *= MainCoefficient;
            forestAreaData.Coefficients.Add($"Размер ущерба при {MainCoefficient}-кратном увеличении:", forestAreaData.TotalMoney);
        }
    }
}