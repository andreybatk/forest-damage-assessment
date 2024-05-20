using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Exceptions;
using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using System.Globalization;

namespace ForestDamageAssessment.BL.Services
{
    public class BushFellingViolationService : ViolationServiceBase, IExtendedViolationService<BushFellingViolationService, IBushViewModel>
    {
        private const string _coniferous = "Хвойная";
        private const string _deciduous = "Лиственная";
        private readonly ITaxPriceRepository _taxPriceRepository;

        public BushFellingViolationService(ITaxPriceRepository taxPriceRepository, IAssortmentRepository assortmentRepository, IArticleRepository articleRepository)
            : base(assortmentRepository, articleRepository)
        {
            _taxPriceRepository = taxPriceRepository;
        }

        protected override double MainCoefficient => 10D;
        protected override int ArticleID => 2;
        protected virtual int ConiferousDiameter { get; } = 16;
        protected virtual int DeciduousDiameter { get; } = 20;

        public async Task<ForestArea<IBushViewModel>> CalculateAsync(ForestArea<IBushViewModel> forestArea)
        {
            await GetArticleInfo(forestArea.ForestData);
            InitDefaultValues(forestArea.ModelList);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        public async Task<ForestArea<IBushViewModel>> CalculateFromFileAsync(FileModel fileModel, ForestArea<IBushViewModel> forestArea)
        {
            forestArea.ModelList = new List<IBushViewModel>();
            var culture = new CultureInfo("en-us");

            if (fileModel is null)
            {
                throw new ArgumentNullException(nameof(fileModel));
            }

            if (!File.Exists(fileModel.Path))
            {
                throw new FileNotFoundException(nameof(fileModel));
            }

            try
            {
                using (StreamReader reader = new StreamReader(fileModel.Path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        var data = line.Trim(';').Split(';');

                        if (data.Length != 3)
                        {
                            throw new FileModelFormatDataException(nameof(fileModel));
                        }

                        int.TryParse(data[0], culture, out int count);

                        var viewModel = new BushViewModel { BushCount = count, BreedBush = data[1], BushType = data[2], Breed = forestArea.ForestData.MainForestBreed };
                        forestArea.ModelList.Add(viewModel);
                    }
                }
            }
            catch (Exception)
            {
                //TODO LOGGER
            }

            await GetArticleInfo(forestArea.ForestData);
            InitDefaultValues(forestArea.ModelList);
            await CalculateStockAsync(forestArea.ModelList);
            await CalculateMoneyPunishmentAsync(forestArea);
            CalculateTotalMoneyPunishment(forestArea.ModelList, forestArea.ForestData);

            return forestArea;
        }
        private async Task CalculateMoneyPunishmentAsync(ForestArea<IBushViewModel> forestArea)
        {
            if (forestArea.ModelList is null)
            {
                throw new ArgumentNullException(nameof(forestArea.ModelList));
            }
            try
            {
                foreach (var model in forestArea.ModelList)
                {
                    var taxPrice = await _taxPriceRepository.GetTaxPriceAsync(model.Breed, forestArea.ForestData.Region);

                    if (taxPrice == null)
                    {
                        continue;
                    }

                    var culture = new CultureInfo("en-us");
                    double bushCount = Convert.ToDouble(model.BushCount);
                    double.TryParse(taxPrice.PriceLarge, culture, out double priceLarge);
                    double.TryParse(taxPrice.Firewood, culture, out double priceFirewood);

                    model.Money.TaxPriceLarge = priceLarge;
                    model.Money.TaxPriceFirewood = priceFirewood;
                    model.Money.Business = model.Stock.SumBusiness * priceLarge * bushCount;
                    model.Money.Firewood = priceFirewood * model.Stock.SumFirewood * bushCount;
                    model.Money.BusinessAndFirewood = model.Money.Business + model.Money.Firewood;
                }
            }
            catch (Exception)
            {
                //TODO LOGGER
            }
        }
        private void InitDefaultValues(List<IBushViewModel>? modelList)
        {
            if (modelList is null)
            {
                throw new ArgumentNullException(nameof(modelList));
            }

            foreach (var model in modelList)
            {
                model.RankH = 1D;
                if (model.BushType == _coniferous)
                {
                    model.ThicknessLevel = ConiferousDiameter;
                }
                if (model.BushType == _deciduous)
                {
                    model.ThicknessLevel = DeciduousDiameter;
                }
            }
        }
    }
}