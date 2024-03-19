using ForestDamageAssessment.DB;
using ForestDamageAssessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ViolationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Violation1ViewModel model)
        {

            return View();
        }
    }
}
