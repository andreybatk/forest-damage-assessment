using ForestDamageAssessment.DB;
using ForestDamageAssessment.DB.Infrastructure;
using ForestDamageAssessment.DB.Models;
using ForestDamageAssessment.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ForestDamageAssessment.Data
{
    public abstract class ViolationCalculate
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public ViolationCalculate(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
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
                        table = await _context.AssortmentLinden.FirstOrDefaultAsync(
                            x => x.ThicknessLevel == model.ThicknessLevel.ToString() && x.RankH == model.RankH.ToString());
                    }
                    else
                    {
                        table = await _context.Assortment.FirstOrDefaultAsync(
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
                    model.Stock.RootStock = model.Stock.SumLarge + model.Stock.SumAverage + model.Stock.SumSmall
                        + model.Stock.SumFirewood + model.Stock.SumWaste;
                }
            }
            catch (Exception ex)
            {

                //TODO LOGGER
            }
        }
        public async Task<FileModel> GetFileModel(IFormFile uploadedFile)
        {
            var fileModel = new FileModel();

            if (uploadedFile == null)
            {
                return fileModel;
            }

            if (!uploadedFile.FileName.ToLower().EndsWith(".txt") && !uploadedFile.FileName.ToLower().EndsWith(".csv"))
            {
                return fileModel;
            }

            string path = _appEnvironment.WebRootPath + "/Files/" + uploadedFile.FileName;
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            fileModel.Name = uploadedFile.FileName;
            fileModel.Path = path;
            return fileModel;
        }
        public ForestArea GetForestArea(string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = new ForestArea { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            return forestArea;
        }
    }
}