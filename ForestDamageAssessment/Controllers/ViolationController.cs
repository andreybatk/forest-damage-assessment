using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationController : Controller
    {
        private readonly IViolationService<TreeFellingViolationService, ITreeViewModel> _treeFellingViolationService;
        private readonly IViolationService<TreeFellingViolation2Service, ITreeViewModel> _treeFellingViolation2Service;
        private readonly IViolationService<BushFellingViolationService, IBushViewModel> _bushFellingViolationService;
        private readonly IViolationService<BushFellingViolation2Service, IBushViewModel> _bushFellingViolation2Service;
        private readonly IForestAreaModelService _forestAreaViewModelService;
        private readonly IFileModelService _fileModelService;

        public ViolationController(IViolationService<TreeFellingViolationService, ITreeViewModel> treeFellingViolationService,
            IViolationService<TreeFellingViolation2Service, ITreeViewModel> treeFellingViolation2Service,
            IViolationService<BushFellingViolationService, IBushViewModel> bushFellingViolationService,
            IViolationService<BushFellingViolation2Service, IBushViewModel> bushFellingViolation2Service,
            IForestAreaModelService forestAreaViewModelService,
            IFileModelService fileModelService)
        {
            _treeFellingViolationService = treeFellingViolationService;
            _treeFellingViolation2Service = treeFellingViolation2Service;
            _bushFellingViolationService = bushFellingViolationService;
            _bushFellingViolation2Service = bushFellingViolation2Service;
            _forestAreaViewModelService = forestAreaViewModelService;
            _fileModelService = fileModelService;
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
            var forestArea = _forestAreaViewModelService.CreateForestAreaViewModel(breed, diameter, h, rankH, region, year, isOZU, isProtectiveForests, isOOPT);

            return View(await _treeFellingViolationService.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> TreeFellingDataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestAreaModel<ITreeViewModel> { ForestData = forestData };
            var fileModel = await _fileModelService.CreateFileModelAsync(uploadedFile);

            return View("TreeFellingData", await _treeFellingViolationService.CalculateFromFileAsync(fileModel, forestArea));
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
        public IActionResult TreeFelling2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TreeFelling2Data(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestAreaViewModel(breed, diameter, h, rankH, region, year, isOZU, isProtectiveForests, isOOPT);

            return View("TreeFellingData", await _treeFellingViolation2Service.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> TreeFelling2DataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestAreaModel<ITreeViewModel> { ForestData = forestData };
            var fileModel = await _fileModelService.CreateFileModelAsync(uploadedFile);

            return View("TreeFellingData", await _treeFellingViolation2Service.CalculateFromFileAsync(fileModel, forestArea));
        }
        [HttpGet]
        public IActionResult BushFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BushFellingData(int[] count, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestAreaViewModel(count, breedBush, bushType, region, year, isOZU, isProtectiveForests, isOOPT);

            return View(await _bushFellingViolationService.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> BushFellingDataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestAreaModel<IBushViewModel> { ForestData = forestData };
            var fileModel = await _fileModelService.CreateFileModelAsync(uploadedFile);

            return View("BushFellingData", await _bushFellingViolationService.CalculateFromFileAsync(fileModel, forestArea));
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
        public IActionResult BushFelling2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BushFelling2Data(int[] count, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestAreaViewModel(count, breedBush, bushType, region, year, isOZU, isProtectiveForests, isOOPT);

            return View("BushFellingData", await _bushFellingViolation2Service.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> BushFelling2DataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestAreaModel<IBushViewModel> { ForestData = forestData };
            var fileModel = await _fileModelService.CreateFileModelAsync(uploadedFile);

            return View("BushFellingData", await _bushFellingViolation2Service.CalculateFromFileAsync(fileModel, forestArea));
        }
        //[HttpGet]
        //public IActionResult GetStream()
        //{
        //    string path = _appEnvironment.WebRootPath + "/Files/" + "диплом.txt";
        //    FileStream fs = new FileStream(path, FileMode.Open);
        //    string file_type = "text/plain";
        //    string file_name = "Сформированный файл диплом.txt";
        //    return File(fs, file_type, file_name);
        //}
    }
}