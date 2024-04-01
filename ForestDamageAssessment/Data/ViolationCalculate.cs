using ForestDamageAssessment.DB;
using ForestDamageAssessment.DB.Infrastructure;
using ForestDamageAssessment.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ForestDamageAssessment.Data
{
    public abstract class ViolationCalculate
    {
        public ViolationCalculate(ApplicationDbContext context)
        {
            _context = context;
        }

        protected readonly ApplicationDbContext _context;
        protected virtual double MainCoefficient { get; } = 50D;
        protected virtual double Year2024Coefficient { get; } = 3.14;
        protected virtual double OZUCoefficient { get; } = 3D;
        protected virtual double ProtectiveForestsCoefficient { get; } = 2D;
        protected virtual double OOPTtCoefficient { get; } = 5D;

        public async Task CalculateStockAsync<T>(List<T> modelList)
        {
            try
            {
                var culture = new CultureInfo("en-us");
                IAssortmentTable? table;

                List<IViolationViewModel> currentModelList = modelList.Cast<IViolationViewModel>().ToList();

                foreach (var model in currentModelList)
                {
                    if (model.Breed.ToLower() == "липа")
                    {
                        table = await _context.AssortmentsLinden.FirstOrDefaultAsync(
                            x => x.ThicknessLevel == model.ThicknessLevel.ToString() && x.RankH == model.RankH.ToString());
                    }
                    else if (model.Breed.ToLower() == "ива древовидная" || (model.Breed.ToLower() == "ольха черная") || (model.Breed.ToLower() == "осокорь"))
                    {
                        table = await _context.AssortmentsExtra.FirstOrDefaultAsync(
                            x => x.ThicknessLevel == model.ThicknessLevel.ToString() && x.RankH == model.RankH.ToString());
                    }
                    else
                    {
                        table = await _context.Assortments.FirstOrDefaultAsync(
                            x => x.Breed == model.Breed && x.ThicknessLevel == model.ThicknessLevel.ToString());
                    }

                    if (table == null)
                    {
                        continue;
                    }

                    double.TryParse(table.LargeTotal, culture, out double largeTotal);
                    double.TryParse(table.VInBark, culture, out double vInBark);
                    double.TryParse(table.Average1Total, culture, out double average1Total);
                    double.TryParse(table.Average2Total, culture, out double average2Total);
                    double.TryParse(table.SmallTotal, culture, out double smallTotal);
                    double.TryParse(table.AllBusiness, culture, out double allBusiness);
                    double.TryParse(table.FirewoodFuel, culture, out double firewoodFuel);
                    double.TryParse(table.Waste, culture, out double waste);

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
        public void CalculateTotalMoneyPunishment<T>(List<T> modelList, ForestAreaData? forestAreaData)
        {
            if (forestAreaData == null)
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