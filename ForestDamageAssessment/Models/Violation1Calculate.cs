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

                    if(table != null)
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

                        model.BreedStock.SumLarge = largeTotal * vInBark / 100;
                        model.BreedStock.SumAverage = (average1Total + average2Total) * vInBark / 100;
                        model.BreedStock.SumSmall = smallTotal * vInBark / 100;
                        model.BreedStock.SumBusiness = allBusiness * vInBark / 100;
                        model.BreedStock.SumFirewood = (firewoodFuel + waste) * vInBark / 100;
                        model.BreedStock.SumWaste = waste * vInBark / 100;

                        model.BreedStock.LiquidStock = model.BreedStock.SumBusiness + model.BreedStock.SumFirewood;
                        model.BreedStock.RootStock = model.BreedStock.SumLarge + model.BreedStock.SumAverage + model.BreedStock.SumSmall
                            + model.BreedStock.SumFirewood + model.BreedStock.SumWaste;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
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
        private async Task<int?> GetThicknessLevelAsync(double? diameter)
        {
            if(diameter != null)
            {
                var thicknessLevel = await _context.STD.FirstOrDefaultAsync(x => x.ThicknessLevel == diameter + 1 || x.ThicknessLevel == diameter + 2 || x.ThicknessLevel == diameter + 3 || x.ThicknessLevel == diameter + 4);
                return thicknessLevel?.ThicknessLevel;
            }

            return null;
        }
    }
}
