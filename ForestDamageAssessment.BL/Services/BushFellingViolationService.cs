using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class BushFellingViolationService : ViolationService, IViolationService<BushFellingViolationService, IBushViewModel>
    {
        private const string _coniferous = "Хвойная";
        private const string _deciduous = "Лиственная";
        private readonly ITaxPriceRepository _taxPriceRepository;

        public BushFellingViolationService(IAssortmentRepository assortmentRepository, ITaxPriceRepository taxPriceRepository) : base(assortmentRepository)
        {
            _taxPriceRepository = taxPriceRepository;
        }

        protected override double MainCoefficient => 10D;
        protected virtual int ConiferousDiameter { get; } = 16;
        protected virtual int DeciduousDiameter { get; } = 20;

        public async Task<ForestAreaModel<IBushViewModel>> CalculateAsync(ForestAreaModel<IBushViewModel> forestArea)
        {
            InitDefaultValues(forestArea.ModelList);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        public async Task<ForestAreaModel<IBushViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestAreaModel<IBushViewModel> forestArea)
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
        private async Task CalculateMoneyPunishmentAsync(ForestAreaModel<IBushViewModel> forestArea)
        {
            try
            {
                if (forestArea.ModelList == null)
                {
                    return;
                }

                foreach (var model in forestArea.ModelList)
                {
                    var taxPrice = await _taxPriceRepository.GetTaxPriceAsync(model.Breed, forestArea.ForestData.Region);

                    if (taxPrice == null)
                    {
                        continue;
                    }

                    var culture = new CultureInfo("en-us");

                    double.TryParse(taxPrice.PriceAverage, culture, out double priceAverage);
                    double.TryParse(taxPrice.Firewood, culture, out double priceFirewood);
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
        private void InitDefaultValues(List<IBushViewModel>? modelList)
        {
            if (modelList == null)
            {
                return;
            }

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
    }
}