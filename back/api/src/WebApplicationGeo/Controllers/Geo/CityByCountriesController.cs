using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationGeo.Data;

namespace WebApplicationGeo.Controllers.Geo
{

    public class CityByCountriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public CityByCountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(
            int? CountryId,
            int? AreaId,
            int? CityId
            )
        {
            
            var countryList = _context.Countries.ToList();
            ViewBag.Countries = new SelectList(countryList, "Id", "Name", CountryId);

            if (CountryId != null)
            {
                var areaList = _context.Areas.Where(a => a.CountryId == CountryId).ToList();
                ViewBag.Areas = new SelectList(areaList, "Id", "Name", AreaId);
            }

            if (AreaId != null)
            {
                var cityList = _context.Cities.Where(c => c.AreaId == AreaId).ToList();
                ViewBag.Cities = new SelectList(cityList, "Id", "Name", CityId);
            }
            
            return View();
        }
    }
}