﻿using ForestDamageAssessment.DB;
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
            var modelList = new List<Violation1ViewModel>();
            for (int i = 0; i < breed.Length; i++)
            {
                var culture = new CultureInfo("en-us");

                double.TryParse(diameter[i], culture, out double resultDiameter);
                double.TryParse(h[i], culture, out double resultH);
                double.TryParse(rankH[i], culture, out double resultRankH);

                var viewModel = new Violation1ViewModel { Breed = breed[i], Diameter = resultDiameter, H = resultH, RankH = resultRankH };
                viewModel.Area.RegionCode = region;
                viewModel.Area.Year = year;
                viewModel.Area.IsProtectiveForests = isProtectiveForests;
                viewModel.Area.IsOZU = isOZU;
                viewModel.Area.IsOOPT = isOOPT;

                modelList.Add(viewModel);
            }
            

			if (modelList.Count > 0)
            {
				await _violation1Calculate.CalculateAsync(modelList);
                return View(modelList);
            }

            return NotFound();
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
