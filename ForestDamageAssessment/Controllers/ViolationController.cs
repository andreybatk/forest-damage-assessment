using ForestDamageAssessment.DB;
using ForestDamageAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationController : Controller
    {
        private readonly Violation1Calculate _violation1Calculate;
        public ViolationController(Violation1Calculate violation1Calculate)
        {
            _violation1Calculate = violation1Calculate;
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
           
            return View(await _violation1Calculate.CalculateAsync(
                breed, diameter, h, rankH, region, year, isOZU, isProtectiveForests, isOOPT));
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
