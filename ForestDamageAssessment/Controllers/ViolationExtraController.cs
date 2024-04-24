using Microsoft.AspNetCore.Mvc;

namespace ForestDamageAssessment.Controllers
{
    public class ViolationExtraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
