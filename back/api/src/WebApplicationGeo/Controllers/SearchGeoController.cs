using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationGeo.Data;
using WebApplicationGeo.Models.Entities.Geo;

namespace WebApplicationGeo.Controllers
{
    public class SearchGeoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchGeoController(ApplicationDbContext context)
        {
            _context = context;            
        }
        
        // GET: SearchGeoController
        public async Task<ActionResult> Index()
        {

            var Ch = await _context
                .Cities
                .Include(city => city.Area)
                    .ThenInclude(area => area.Country)
                        .ThenInclude(country => country.Capital)
                .Include(city => city.Area)
                    .ThenInclude(area => area.RegionCapital)
                .Where(c => c.Name == "Чорноморськ")
                .FirstOrDefaultAsync();

            

            // Ch.FirstOrDefaultAsync();
            
            return View();
        }

    }
}
