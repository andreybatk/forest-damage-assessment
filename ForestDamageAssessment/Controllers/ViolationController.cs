using ForestDamageAssessment.Data;
using ForestDamageAssessment.Infrastructure;
using ForestDamageAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationController : Controller
    {
        private readonly IViolationCalculate<TreeFellingViolationCalculate, ITreeViewModel> _treeFellingViolationCalculate;
        private readonly IViolationCalculate<BushFellingViolationCalculate, IBushViewModel> _bushFellingViolationCalculate;
        private readonly IWebHostEnvironment _appEnvironment;
        public ViolationController(IViolationCalculate<TreeFellingViolationCalculate, ITreeViewModel> treeFellingViolationCalculate,
            IViolationCalculate<BushFellingViolationCalculate, IBushViewModel> bushFellingViolationCalculate,
            IWebHostEnvironment appEnvironment)
        {
            _treeFellingViolationCalculate = treeFellingViolationCalculate;
            _bushFellingViolationCalculate = bushFellingViolationCalculate;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult TreeFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TreeFellingData(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var modelList = new List<ITreeViewModel>();
            var forestArea = new ForestArea { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var culture = new CultureInfo("en-us");

            for (int i = 0; i < breed.Length; i++)
            {
                double.TryParse(diameter[i], culture, out double resultDiameter);
                double.TryParse(h[i], culture, out double resultH);
                double.TryParse(rankH[i], culture, out double resultRankH);

                var viewModel = new TreeViewModel { Breed = breed[i], Diameter = resultDiameter, H = resultH, RankH = resultRankH };

                modelList.Add(viewModel);
            }

            return View(await _treeFellingViolationCalculate.CalculateAsync(modelList, forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> TreeFellingDataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var fileModel = await _treeFellingViolationCalculate.GetFileModelAsync(uploadedFile);
            var forestArea = _treeFellingViolationCalculate.GetForestArea(region, year, isOZU, isProtectiveForests, isOOPT);

            return View("TreeFellingData", await _treeFellingViolationCalculate.CalculateFromFileAsync(fileModel, forestArea));
        }
        [HttpPost]
        public IActionResult TreeFellingDataDetails([FromBody] TreeViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return PartialView("_TreeFellingDataDetailsPartial", model);
        }
        [HttpGet]
        public IActionResult BushFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BushFellingData(int[] count, string[] breed, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var modelList = new List<IBushViewModel>();
            var forestArea = new ForestArea { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };

            for (int i = 0; i < breed.Length; i++)
            {
                var viewModel = new BushViewModel { Breed = breed[i], BushCount = count[i], BreedBush = breedBush[i], BushType = bushType[i] };

                modelList.Add(viewModel);
            }

            return View(await _bushFellingViolationCalculate.CalculateAsync(modelList, forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> BushFellingDataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var fileModel = await _bushFellingViolationCalculate.GetFileModelAsync(uploadedFile);
            var forestArea = _bushFellingViolationCalculate.GetForestArea(region, year, isOZU, isProtectiveForests, isOOPT);

            return View("BushFellingData", await _bushFellingViolationCalculate.CalculateFromFileAsync(fileModel, forestArea));
        }
        [HttpPost]
        public IActionResult BushFellingDataDetails([FromBody] BushViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return PartialView("_BushFellingDataDetailsPartial", model);
        }
        [HttpGet]
        public IActionResult GetStream()
        {
            string path = _appEnvironment.WebRootPath + "/Files/" + "диплом.txt";
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "text/plain";
            string file_name = "Сформированный файл диплом.txt";
            return File(fs, file_type, file_name);
        }
    }
}