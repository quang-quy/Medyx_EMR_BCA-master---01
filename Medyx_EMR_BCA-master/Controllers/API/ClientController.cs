using Microsoft.AspNetCore.Mvc;


namespace Medyx_EMR_BCA.Controllers.API
{
    public class ClientController : Controller
    {

        public ActionResult Index()
        {
            return File("~/index.html", "text/html");
        }
    }
}