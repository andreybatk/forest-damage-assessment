using ForestDamageAssessment.DB;
using ForestDamageAssessment.DB.Models;
using ForestDamageAssessment.Infrastructure;
using ForestDamageAssessment.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ForestDamageAssessment.Data
{
    public class TreeFellingViolationCalculate : ViolationCalculate, IViolationCalculate<TreeFellingViolationCalculate, ITreeViewModel>
    {
        public TreeFellingViolationCalculate(ApplicationDbContext context, IWebHostEnvironment appEnvironment) : base(context, appEnvironment)
        {
        }

        public async Task<List<ITreeViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestArea forestArea)
        {
            var modelList = new List<ITreeViewModel>();
            var culture = new CultureInfo("en-us");

            if (fileModel == null)
            {
                return modelList;
            }

            using (StreamReader reader = new StreamReader(fileModel.Path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var data = line.Split(';');
                    if (data.Length < 3)
                    {
                        continue;
                    }
                    double.TryParse(data[1], culture, out double resultDiameter);
                    double.TryParse(data[2], culture, out double resultH);
                    double.TryParse(data[3], culture, out double resultRankH);

                    var viewModel = new TreeViewModel { Breed = data[0], Diameter = resultDiameter, H = resultH, RankH = resultRankH };
                    modelList.Add(viewModel);
                }
            }

            await CalculateDiameterAsync(modelList);
            await CalculateStockAsync(modelList);
            await CalculateMoneyPunishmentAsync(modelList, forestArea);

            return modelList;
        }
        public async Task<List<ITreeViewModel>> CalculateAsync(List<ITreeViewModel> modelList, ForestArea forestArea)
        {
            await CalculateDiameterAsync(modelList);
            await CalculateStockAsync(modelList);
            await CalculateMoneyPunishmentAsync(modelList, forestArea);

            return modelList;
        }
        private async Task CalculateMoneyPunishmentAsync(List<ITreeViewModel> modelList, ForestArea forestArea)
        {
            try
            {
                foreach (var model in modelList)
                {
                    var table = await _context.TaxPrices.FirstOrDefaultAsync(
                        x => x.SubjectRF == forestArea.Region && x.Breed == model.Breed);

                    if (table == null)
                    {
                        continue;
                    }

                    var culture = new CultureInfo("en-us");

                    double.TryParse(table.PriceAverage, culture, out double priceAverage);
                    double.TryParse(table.Firewood, culture, out double priceFirewood);

                    model.Money.Business = priceAverage * model.Stock.SumBusiness * MainCoefficient * Year2024Coefficient;
                    model.Money.Firewood = priceFirewood * model.Stock.SumFirewood * MainCoefficient * Year2024Coefficient;

                    if (forestArea.IsOZU)
                    {
                        model.Money.Business *= OZUCoefficient;
                        model.Money.Firewood *= OZUCoefficient;
                    }
                    if (forestArea.IsProtectiveForests)
                    {
                        model.Money.Business *= ProtectiveForestsCoefficient;
                        model.Money.Firewood *= ProtectiveForestsCoefficient;
                    }
                    if (forestArea.IsOOPT)
                    {
                        model.Money.Business *= OOPTtCoefficient;
                        model.Money.Firewood *= OOPTtCoefficient;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO LOGGER
            }
        }
        private async Task CalculateDiameterAsync(List<ITreeViewModel> modelList)
        {
            try
            {
                foreach (var model in modelList)
                {
                    var breedDiameter = await _context.BreedDiameterModels.FirstOrDefaultAsync(x => x.Breed == model.Breed);

                    if (breedDiameter == null)
                    {
                        continue;
                    }

                    double DimeterPercent =
                        double.Parse(breedDiameter.C1) * Math.Pow(model.H, double.Parse(breedDiameter.C2))
                        - double.Parse(breedDiameter.C3) * Math.Exp(-double.Parse(breedDiameter.C4) * model.H);

                    model.CalculatedDiameter = Math.Round(model.Diameter * 100 / DimeterPercent);
                    model.ThicknessLevel = await GetThicknessLevelAsync(model.CalculatedDiameter);
                }
            }
            catch (Exception ex)
            {
                //TODO LOGGER
            }
        }
        private async Task<int?> GetThicknessLevelAsync(double diameter)
        {
            if (diameter == 0)
            {
                return null;
            }

            var thicknessLevel = await _context.STDs.FirstOrDefaultAsync(x => x.ThicknessLevel == diameter || x.ThicknessLevel == diameter + 1 || x.ThicknessLevel == diameter + 2 || x.ThicknessLevel == diameter + 3 || x.ThicknessLevel == diameter + 4);
            return thicknessLevel?.ThicknessLevel;
        }
    }
}