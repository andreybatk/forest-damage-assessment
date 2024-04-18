using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationController : Controller
    {
        private readonly IExtendedViolationService<TreeFellingViolationService, ITreeViewModel> _treeFellingViolationService;
        private readonly IExtendedViolationService<TreeFellingViolation2Service, ITreeViewModel> _treeFellingViolation2Service;
        private readonly IExtendedViolationService<BushFellingViolationService, IBushViewModel> _bushFellingViolationService;
        private readonly IExtendedViolationService<BushFellingViolation2Service, IBushViewModel> _bushFellingViolation2Service;
        private readonly IViolationService<DeadFellingViolationService, ITreeViewModel> _deadFellingViolationService;
        private readonly ISeedlingsService _seedlingsService;
        private readonly IForestAreaService _forestAreaViewModelService;
        private readonly IFileModelService _fileModelService;

        public ViolationController(IExtendedViolationService<TreeFellingViolationService, ITreeViewModel> treeFellingViolationService,
            IExtendedViolationService<TreeFellingViolation2Service, ITreeViewModel> treeFellingViolation2Service,
            IExtendedViolationService<BushFellingViolationService, IBushViewModel> bushFellingViolationService,
            IExtendedViolationService<BushFellingViolation2Service, IBushViewModel> bushFellingViolation2Service,
            IViolationService<DeadFellingViolationService, ITreeViewModel> deadFellingViolationService,
            ISeedlingsService seedlingsService,
            IForestAreaService forestAreaViewModelService,
            IFileModelService fileModelService)
        {
            _treeFellingViolationService = treeFellingViolationService;
            _treeFellingViolation2Service = treeFellingViolation2Service;
            _bushFellingViolationService = bushFellingViolationService;
            _bushFellingViolation2Service = bushFellingViolation2Service;
            _deadFellingViolationService = deadFellingViolationService;
            _seedlingsService = seedlingsService;
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
            var forestArea = _forestAreaViewModelService.CreateForestArea(breed, diameter, h, rankH, region, year, isOZU, isProtectiveForests, isOOPT);

            return View(await _treeFellingViolationService.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> TreeFellingDataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestArea<ITreeViewModel> { ForestData = forestData };
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
            var forestArea = _forestAreaViewModelService.CreateForestArea(breed, diameter, h, rankH, region, year, isOZU, isProtectiveForests, isOOPT);

            return View("TreeFellingData", await _treeFellingViolation2Service.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> TreeFelling2DataFromFile(IFormFile uploadedFile,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestData = new ForestAreaData { Region = region, Year = year, IsOZU = isOZU, IsProtectiveForests = isProtectiveForests, IsOOPT = isOOPT };
            var forestArea = new ForestArea<ITreeViewModel> { ForestData = forestData };
            var fileModel = await _fileModelService.CreateFileModelAsync(uploadedFile);

            return View("TreeFellingData", await _treeFellingViolation2Service.CalculateFromFileAsync(fileModel, forestArea));
        }
        [HttpGet]
        public IActionResult BushFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BushFellingData(int[] count, string mainForestBreed, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestArea(count, mainForestBreed, breedBush, bushType, region, year, isOZU, isProtectiveForests, isOOPT);

            return View(await _bushFellingViolationService.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> BushFellingDataFromFile(IFormFile uploadedFile,
            string mainForestBreed, string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestArea(mainForestBreed, region, year, isOZU, isProtectiveForests, isOOPT);
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
        public async Task<IActionResult> BushFelling2Data(int[] count, string mainForestBreed, string[] breedBush, string[] bushType,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestArea(count, mainForestBreed, breedBush, bushType, region, year, isOZU, isProtectiveForests, isOOPT);

            return View("BushFellingData", await _bushFellingViolation2Service.CalculateAsync(forestArea));
        }
        [HttpPost]
        public async Task<IActionResult> BushFelling2DataFromFile(IFormFile uploadedFile,
            string mainForestBreed, string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestArea(mainForestBreed, region, year, isOZU, isProtectiveForests, isOOPT);
            var fileModel = await _fileModelService.CreateFileModelAsync(uploadedFile);

            return View("BushFellingData", await _bushFellingViolation2Service.CalculateFromFileAsync(fileModel, forestArea));
        }
        [HttpGet]
        public IActionResult DeadFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeadFellingData(string[] breed, string[] diameter, string[] h, string[] rankH,
            string region, string year, bool isOZU, bool isProtectiveForests, bool isOOPT)
        {
            var forestArea = _forestAreaViewModelService.CreateForestArea(breed, diameter, h, rankH, region, year, isOZU, isProtectiveForests, isOOPT);

            return View(await _deadFellingViolationService.CalculateAsync(forestArea));
        }
        [HttpGet]
        public IActionResult SeedlingsFelling()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SeedlingsFellingData(int[] count, string[] breed, string[] price)
        {
            return View(_seedlingsService.Calculate(count, breed, price));
        }
    }
}