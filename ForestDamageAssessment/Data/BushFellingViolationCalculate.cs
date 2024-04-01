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

        public BushFellingViolationCalculate(ApplicationDbContext context) : base(context)
        {
        }

        protected override double MainCoefficient => 10D;
        protected virtual int ConiferousDiameter { get; } = 16;
        protected virtual int DeciduousDiameter { get; } = 20;

        public async Task<ForestAreaViewModel<IBushViewModel>> CalculateAsync(ForestAreaViewModel<IBushViewModel> forestArea)
        {
            InitDefaultValues(forestArea.ModelList);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        public async Task<ForestAreaViewModel<IBushViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestAreaViewModel<IBushViewModel> forestArea)
        {
            forestArea.ModelList = new List<IBushViewModel>();
            var culture = new CultureInfo("en-us");

            if (fileModel == null)
            {
                return forestArea;
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
                    forestArea.ModelList.Add(viewModel);
                }
            }

            InitDefaultValues(forestArea.ModelList);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        private async Task CalculateMoneyPunishmentAsync(ForestAreaViewModel<IBushViewModel> forestArea)
        {
            try
            {
                foreach (var model in forestArea.ModelList)
                {
                    var table = await _context.TaxPrices.FirstOrDefaultAsync(
                        x => x.SubjectRF == forestArea.ForestData.Region && x.Breed == model.Breed);

                    if (table == null)
                    {
                        continue;
                    }

                    var culture = new CultureInfo("en-us");

                    double.TryParse(table.PriceAverage, culture, out double priceAverage);
                    double.TryParse(table.Firewood, culture, out double priceFirewood);
                    double bushCount = Convert.ToDouble(model.BushCount);

                    model.Money.TaxPriceBusiness = priceAverage;
                    model.Money.TaxPriceFirewood = priceFirewood;
                    model.Money.Business = priceAverage * model.Stock.SumBusiness * bushCount;
                    model.Money.Firewood = priceFirewood * model.Stock.SumFirewood * bushCount;
                    model.Money.BusinessAndFirewood = model.Money.Business + model.Money.Firewood;
                }
            }
            catch (Exception ex)
            {
                //TODO LOGGER
            }
        }
        private void InitDefaultValues(List<IBushViewModel> modelList)
        {
            try
            {
                foreach (var model in modelList)
                {
                    model.RankH = 1D;
                    if (model.BushType == _coniferous)
                    {
                        model.Breed = "Сосна"; // наибольшая ставка платы среди хвойных пород
                        model.ThicknessLevel = ConiferousDiameter;
                    }
                    if (model.BushType == _deciduous)
                    {
                        model.Breed = "Клен"; // наибольшая ставка платы среди лиственных пород
                        model.ThicknessLevel = DeciduousDiameter;
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