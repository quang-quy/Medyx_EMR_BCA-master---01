using Microsoft.AspNetCore.Mvc;

namespace Medyx_EMR_BCA.Controllers.API
{
    public class HomeAPIController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Index.cshtml");
        }
    }
}
