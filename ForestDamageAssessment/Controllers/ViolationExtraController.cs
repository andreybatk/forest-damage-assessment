using ForestDamageAssessment.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationExtraController : Controller
    {
        private readonly IResinFellingService _resinFellingService;
        private readonly IForestResourceFellingService _forestResourceFellingService;
        private readonly IForestUseFellingService _forestUseFellingService;
        private readonly IFoodResourceFellingService _foodResourceFellingService;

        public ViolationExtraController(IResinFellingService resinFellingService, IForestResourceFellingService forestResourceFellingService, IForestUseFellingService forestUseFellingService, IFoodResourceFellingService foodResourceFellingService)
        {
            _resinFellingService = resinFellingService;
            _forestResourceFellingService = forestResourceFellingService;
            _forestUseFellingService = forestUseFellingService;
            _foodResourceFellingService = foodResourceFellingService;
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
        public IActionResult ForestUseFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForestUseFellingData(string[] square, string[] price, bool isViolation1, bool isViolation2, bool isViolation3, string region)
        {
            return View(await _forestUseFellingService.CalculateAsync(square, price, isViolation1, isViolation2, isViolation3, region));
        }
    }
}
