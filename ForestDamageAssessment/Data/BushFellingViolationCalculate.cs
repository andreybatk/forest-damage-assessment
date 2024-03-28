using ForestDamageAssessment.DB;
using ForestDamageAssessment.DB.Models;
using ForestDamageAssessment.Infrastructure;
using ForestDamageAssessment.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ForestDamageAssessment.Data
{
    public class BushFellingViolationCalculate : ViolationCalculate, IViolationCalculate<BushFellingViolationCalculate, IBushViewModel>
    {
        private const string _coniferous = "Хвойная";
        private const string _deciduous = "Лиственная";

        public BushFellingViolationCalculate(ApplicationDbContext context, IWebHostEnvironment appEnvironment) : base(context, appEnvironment)
        {
        }

        protected override double MainCoefficient => 10D;

        public async Task<List<IBushViewModel>> CalculateAsync(List<IBushViewModel> modelList, ForestArea forestArea)
        {
            InitDefaultValues(modelList);
            await CalculateStockAsync(modelList);
            await CalculateMoneyPunishmentAsync(modelList, forestArea);

            return modelList;
        }
        public async Task<List<IBushViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestArea forestArea)
        {
            var modelList = new List<IBushViewModel>();
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

                    int.TryParse(data[0], culture, out int count);

                    var viewModel = new BushViewModel { BushCount = count, BreedBush = data[1], BushType = data[2], Breed = data[3] };
                    modelList.Add(viewModel);
                }
            }

            InitDefaultValues(modelList);
            await CalculateStockAsync(modelList);
            await CalculateMoneyPunishmentAsync(modelList, forestArea);

            return modelList;
        }
        private async Task CalculateMoneyPunishmentAsync(List<IBushViewModel> modelList, ForestArea forestArea)
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
                    double bushCount = Convert.ToDouble(model.BushCount);

                    model.Money.Business = priceAverage * model.Stock.SumBusiness * MainCoefficient * Year2024Coefficient * bushCount;
                    model.Money.Firewood = priceFirewood * model.Stock.SumFirewood * MainCoefficient * Year2024Coefficient * bushCount;

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
        private static void InitDefaultValues(List<IBushViewModel> modelList)
        {
            try
            {
                foreach (var model in modelList)
                {
                    model.RankH = 1D;
                    if (model.BushType == _coniferous)
                    {
                        model.ThicknessLevel = 16;
                    }
                    if (model.BushType == _deciduous)
                    {
                        model.ThicknessLevel = 20;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO LOGGER
            }
        }
    }
}