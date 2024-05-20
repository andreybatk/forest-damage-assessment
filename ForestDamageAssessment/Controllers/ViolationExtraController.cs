using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationExtraController : Controller
    {
        private readonly IResinFellingService _resinFellingService;
        private readonly IForestResourceFellingService _forestResourceFellingService;
        private readonly IForestUseService _forestUseService;
        private readonly IFoodResourceFellingService _foodResourceFellingService;
        private readonly IPlacementOfObjectsService _placementOfObjectsService;
        private readonly IRemovalOfSoilsService _removalOfSoilsService;
        private readonly IRemovalOfAnthillsService _removalOfAnthillsService;
        private readonly IDamageToObjectsService _damageToObjectsService;
        private readonly IRemovalOfSignsService _removalOfSignService;
        private readonly IForestPollutionService<ForestPollutionService> _forestPollutionService;
        private readonly IForestPollutionService<ForestPollution2Service> _forestPollution2Service;

        public ViolationExtraController(IResinFellingService resinFellingService, IForestResourceFellingService forestResourceFellingService, IForestUseService forestUseService, IFoodResourceFellingService foodResourceFellingService, IPlacementOfObjectsService placementOfObjectsService, IRemovalOfSoilsService removalOfSoilsService, IRemovalOfAnthillsService removalOfAnthillsService, IDamageToObjectsService damageToObjectsService, IRemovalOfSignsService removalOfSignService, IForestPollutionService<ForestPollutionService> forestPollutionService, IForestPollutionService<ForestPollution2Service> forestPollution2Service)
        {
            _resinFellingService = resinFellingService;
            _forestResourceFellingService = forestResourceFellingService;
            _forestUseService = forestUseService;
            _foodResourceFellingService = foodResourceFellingService;
            _placementOfObjectsService = placementOfObjectsService;
            _removalOfSoilsService = removalOfSoilsService;
            _removalOfAnthillsService = removalOfAnthillsService;
            _damageToObjectsService = damageToObjectsService;
            _removalOfSignService = removalOfSignService;
            _forestPollutionService = forestPollutionService;
            _forestPollution2Service = forestPollution2Service;
        }

        [HttpGet]
        public IActionResult ResinFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResinFellingData(string[] countTon, string[] breed, string region)
        {
            return View(await _resinFellingService.CalculateAsync(countTon, breed, region));
        }
        [HttpGet]
        public IActionResult ForestResourceFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForestResourceFellingData(string[] stumps, string[] bark, string[] lub, string[] birchBark, string[] firPaw,
            string[] pinePaw, string[] sprucePaw, string[] brushwood, string[] forestFloor, string region)
        {
            return View(await _forestResourceFellingService.CalculateAsync(stumps, bark, lub, birchBark, firPaw,
            pinePaw, sprucePaw, brushwood, forestFloor, region));
        }
        [HttpGet]
        public IActionResult FoodResourceFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FoodResourceFellingData(string[] treeSap, string[] wildFuits, string[] wildBerries, string[] wildMushrooms, string[] wildNuts,
            string[] seeds, string[] medicinalPlants, string region)
        {
            return View(await _foodResourceFellingService.CalculateAsync(treeSap, wildFuits, wildBerries, wildMushrooms, wildNuts,
             seeds, medicinalPlants, region));
        }
        [HttpGet]
        public IActionResult ForestUse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForestUseData(string square, string price, bool isViolation1, bool isViolation2, bool isViolation3, string region)
        {
            return View(await _forestUseService.CalculateAsync(square, price, isViolation1, isViolation2, isViolation3, region));
        }
        [HttpGet]
        public IActionResult PlacementOfObjects()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PlacementOfObjectsData(string square, string price, string priceCleaning)
        {
            return View(await _placementOfObjectsService.CalculateAsync(square, price, priceCleaning));
        }
        [HttpGet]
        public IActionResult RemovalOfAnthills()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemovalOfAnthillsData(string[] diameter, string mainForestBreed, string region)
        {
            return View(await _removalOfAnthillsService.CalculateAsync(diameter, mainForestBreed, region));
        }
        [HttpGet]
        public IActionResult RemovalOfSoils()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemovalOfSoilsData(string square, int vehicleCount, string mainForestBreed, string region)
        {
            return View(await _removalOfSoilsService.CalculateAsync(square, vehicleCount, mainForestBreed, region));
        }
        [HttpGet]
        public IActionResult ForestPollution()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForestPollutionData(string priceCleaning)
        {
            return View("ForestPollutionData", await _forestPollutionService.CalculateAsync(priceCleaning));
        }
        [HttpGet]
        public IActionResult ForestPollution2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForestPollution2Data(string priceCleaning)
        {
            return View("ForestPollutionData", await _forestPollution2Service.CalculateAsync(priceCleaning));
        }
        [HttpGet]
        public IActionResult RemovalOfSigns()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemovalOfSignsData(string price)
        {
            return View(await _removalOfSignService.CalculateAsync(price));
        }
        [HttpGet]
        public IActionResult DamageToObjects()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DamageToObjectsData(string price)
        {
            return View(await _damageToObjectsService.CalculateAsync(price));
        }
    }
}
