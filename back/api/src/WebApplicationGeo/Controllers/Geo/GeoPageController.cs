using Microsoft.AspNetCore.Mvc;

namespace WebApplicationGeo.Controllers.Geo
{

    public class GeoPageController : Controller
    {
        public IActionResult SomePage()
        {
            return View();
        }
    }

}