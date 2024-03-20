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
        public async Task<IActionResult> CalculateViolation1(string[] breed, string[] diameter, string[] h, string[] rankH)
        {
            var modelList = new List<Violation1ViewModel>();
            for (int i = 0; i < breed.Length; i++)
            {
                var culture = new CultureInfo("en-us");

                double.TryParse(diameter[i], culture, out double resultDiameter);
                double.TryParse(h[i], culture, out double resultH);
                double.TryParse(rankH[i], culture, out double resultRankH);

                modelList.Add(new Violation1ViewModel { Breed = breed[i], Diameter = resultDiameter, H = resultH, RankH = resultRankH });
            }
            
            if(modelList.Count > 0)
            {
                var resultModel = await _violation1Calculate.CalculateAsync(modelList);
                return View("BreedsData", resultModel);
            }

            return NotFound();
        }
        //[HttpGet]
        //public IActionResult BreedsData()
        //{
        //    return View();
        //}
    }
}
