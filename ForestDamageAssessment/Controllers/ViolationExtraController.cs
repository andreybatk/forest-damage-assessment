using ForestDamageAssessment.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationExtraController : Controller
    {
        private readonly IResinFellingService _resinFellingService;

        public ViolationExtraController(IResinFellingService resinFellingService)
        {
            _resinFellingService = resinFellingService;
        }

        [HttpGet]
        public IActionResult ResinFelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResinFellingData(string[] countTon, string[] breed, string region)
        {
            return View(await _resinFellingService.Calculate(countTon, breed, region));
        }
    }
}
