﻿using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.DB.Interfaces;
using System.Globalization;

namespace ForestDamageAssessment.BL.Abstractions
{
    public abstract class ViolationServiceBase
    {
        public ViolationServiceBase(IAssortmentRepository assortmentRepository, IArticleRepository articleRepository)
        {
            _assortmentRepository = assortmentRepository;
            _articleRepository = articleRepository;
        }

        protected readonly IAssortmentRepository _assortmentRepository;
        protected readonly IArticleRepository _articleRepository;
        protected virtual double MainCoefficient { get; } = 50D;
        protected virtual double Year2024Coefficient { get; } = 3.14;
        protected virtual double OZUCoefficient { get; } = 3D;
        protected virtual double ProtectiveForestsCoefficient { get; } = 2D;
        protected virtual double OOPTtCoefficient { get; } = 5D;
        protected virtual int ArticleID { get; } = 1;

        public async Task CalculateStockAsync<T>(List<T>? modelList)
            where T : IViolationViewModel
        {
            if (modelList is null)
            {
                throw new ArgumentNullException(nameof(modelList));
            }

            var culture = new CultureInfo("en-us");

            foreach (var model in modelList)
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
        public void CalculateTotalMoneyPunishment<T>(List<T>? modelList, ForestAreaData? forestAreaData)
        {
            if (modelList == null)
            {
                throw new ArgumentNullException(nameof(modelList));
            }
            if (forestAreaData == null)
            {
                throw new ArgumentNullException(nameof(forestAreaData));
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
            forestAreaData.TotalLargeMoney = currentModelList.Select(x => x.Money)
               .Select(x => x.Large)
               .Sum();
            forestAreaData.TotalAverageMoney = currentModelList.Select(x => x.Money)
               .Select(x => x.Average)
               .Sum();
            forestAreaData.TotalSmallMoney = currentModelList.Select(x => x.Money)
               .Select(x => x.Small)
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
            forestAreaData.Coefficients.Add($"Коэффициент за {forestAreaData.Year} год ({Year2024Coefficient}):", forestAreaData.TotalMoney);

            forestAreaData.TotalMoney *= MainCoefficient;
            forestAreaData.Coefficients.Add($"Размер ущерба при {MainCoefficient}-кратном увеличении:", forestAreaData.TotalMoney);
        }
        public async Task GetArticleInfo(ForestAreaData? forestAreaData)
        {
            if (forestAreaData is null)
            {
                throw new ArgumentNullException(nameof(forestAreaData));
            }

            forestAreaData.ViolationArticle = await _articleRepository.GetArticleAsync(ArticleID);
        }
    }
}