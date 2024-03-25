using ForestDamageAssessment.DB.Models;
using ForestDamageAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationController : Controller
    {
        private readonly Violation1Calculate _violation1Calculate;
        private readonly IWebHostEnvironment _appEnvironment;
        public ViolationController(Violation1Calculate violation1Calculate, IWebHostEnvironment appEnvironment)
        {
            _violation1Calculate = violation1Calculate;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BreedsData(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {

            var modelList = new List<Violation1ViewModel>();
            var area = new ForestArea { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < breed.Length; i++)
            {
                double.TryParse(diameter[i], culture, out double resultDiameter);
                double.TryParse(h[i], culture, out double resultH);
                double.TryParse(rankH[i], culture, out double resultRankH);

                var viewModel = new Violation1ViewModel { Breed = breed[i], Diameter = resultDiameter, H = resultH, RankH = resultRankH };

                modelList.Add(viewModel);
            }

            if (modelList.Count > 0)
            {
                return View(await _violation1Calculate.CalculateAsync(modelList, area));
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> BreedsDataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var area = new ForestArea { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };

            if (uploadedFile == null)
            {
                return NotFound();
            }

            if (!uploadedFile.FileName.ToLower().EndsWith(".txt") && !uploadedFile.FileName.ToLower().EndsWith(".csv"))
            {
                return NotFound();
            }

            string path = _appEnvironment.WebRootPath + "/Files/" + uploadedFile.FileName;
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };

            return View("BreedsData", await _violation1Calculate.CalculateFromFileAsync(file, area));
        }
        [HttpPost]
        public IActionResult BreedsDataDetails([FromBody] Violation1ViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return PartialView("_BreedsDataDetailsPartial", model);
        }
    }
}
