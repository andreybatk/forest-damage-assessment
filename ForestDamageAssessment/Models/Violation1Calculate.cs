using ForestDamageAssessment.DB;
using ForestDamageAssessment.DB.Infrastructure;
using ForestDamageAssessment.DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ForestDamageAssessment.Models
{
	public class Violation1Calculate
	{
		private readonly ApplicationDbContext _context;
		private readonly static double CuttingTreesCoefficient = 50D;
		private readonly static double Year2023Coefficient = 2.94;
		private readonly static double OZUCoefficient = 3D;
		private readonly static double ProtectiveForestsCoefficient = 2D;
		private readonly static double OOPTtCoefficient = 5D;

		public Violation1Calculate(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task CalculateAsync(List<Violation1ViewModel> modelList)
		{
			try
			{
				await CalculateDiameterAsync(modelList);

				foreach (var model in modelList)
				{
					IAssortmentTable? table;

					if (model.Breed.ToLower() == "липа")
					{
						table = await _context.AssortmentLinden.FirstOrDefaultAsync(
							x => x.ThicknessLevel == model.ThicknessLevel.ToString() && x.H == model.H.ToString());
					}
					else
					{
						table = await _context.Assortment.FirstOrDefaultAsync(
							x => x.ThicknessLevel == model.ThicknessLevel.ToString() && x.H == model.H.ToString());
					}

					if (table != null)
					{
						var culture = new CultureInfo("en-us");

						double.TryParse(table.LargeTotal, culture, out double largeTotal);
						double.TryParse(table.VInBark, culture, out double vInBark);
						double.TryParse(table.Average1Total, culture, out double average1Total);
						double.TryParse(table.Average2Total, culture, out double average2Total);
						double.TryParse(table.SmallTotal, culture, out double smallTotal);
						double.TryParse(table.AllBusiness, culture, out double allBusiness);
						double.TryParse(table.FirewoodFuel, culture, out double firewoodFuel);
						double.TryParse(table.Waste, culture, out double waste);

						model.Stock.SumLarge = largeTotal * vInBark / 100;
						model.Stock.SumAverage = (average1Total + average2Total) * vInBark / 100;
						model.Stock.SumSmall = smallTotal * vInBark / 100;
						model.Stock.SumBusiness = allBusiness * vInBark / 100;
						model.Stock.SumFirewood = (firewoodFuel + waste) * vInBark / 100;
						model.Stock.SumWaste = waste * vInBark / 100;

						model.Stock.LiquidStock = model.Stock.SumBusiness + model.Stock.SumFirewood;
						model.Stock.RootStock = model.Stock.SumLarge + model.Stock.SumAverage + model.Stock.SumSmall
							+ model.Stock.SumFirewood + model.Stock.SumWaste;

						await CalculateMoneyPunishment(model);
					}
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}
		private async Task CalculateMoneyPunishment(Violation1ViewModel model)
		{
			var table = await _context.TaxPrice.FirstOrDefaultAsync(
				x => x.TaxPriceCode == model.Area.RegionCode && x.Breed == model.Breed);

			if (table != null)
			{
				var culture = new CultureInfo("en-us");

				double.TryParse(table.PriceAverage, culture, out double priceAverage);
				double.TryParse(table.Firewood, culture, out double priceFirewood);

				model.Money.Business = priceAverage * model.Stock.SumBusiness * CuttingTreesCoefficient * Year2023Coefficient;
				model.Money.Firewood = priceFirewood * model.Stock.SumFirewood * CuttingTreesCoefficient * Year2023Coefficient;

				if (model.Area.IsOZU)
				{
					model.Money.Business *= OZUCoefficient;
					model.Money.Firewood *= OZUCoefficient;
				}
				if (model.Area.IsProtectiveForests)
				{
					model.Money.Business *= ProtectiveForestsCoefficient;
					model.Money.Firewood *= ProtectiveForestsCoefficient;
				}
				if (model.Area.IsOOPT)
				{
					model.Money.Business *= OOPTtCoefficient;
					model.Money.Firewood *= OOPTtCoefficient;
				}
			}

		}
		private async Task CalculateDiameterAsync(List<Violation1ViewModel> modelList)
		{
			try
			{
				foreach (var model in modelList)
				{
					var breedDiameter = await _context.BreedDiameterModel.FirstOrDefaultAsync(x => x.Breed == model.Breed);

					if (breedDiameter != null)
					{
						double DimeterPercent =
							double.Parse(breedDiameter.C1) * Math.Pow(model.H, double.Parse(breedDiameter.C2))
							- double.Parse(breedDiameter.C3) * Math.Exp(-double.Parse(breedDiameter.C4) * model.H);

						model.CalculatedDiameter = Math.Round(((model.Diameter * 100) / DimeterPercent));
						model.ThicknessLevel = await GetThicknessLevelAsync(model.CalculatedDiameter);
					}
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}
		private async Task<int?> GetThicknessLevelAsync(double diameter)
		{
			if (diameter != 0)
			{
				var thicknessLevel = await _context.STD.FirstOrDefaultAsync(x => x.ThicknessLevel == diameter || x.ThicknessLevel == diameter + 1 || x.ThicknessLevel == diameter + 2 || x.ThicknessLevel == diameter + 3 || x.ThicknessLevel == diameter + 4);
				return thicknessLevel?.ThicknessLevel;
			}

			return null;
		}
	}
}
