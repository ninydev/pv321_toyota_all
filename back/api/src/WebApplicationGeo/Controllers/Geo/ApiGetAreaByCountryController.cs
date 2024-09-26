using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationGeo.Data;
using WebApplicationGeo.Models.Entities.Geo;

namespace WebApplicationGeo.Controllers.Geo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGetAreaByCountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        
        public ApiGetAreaByCountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("{countryId}")]
        public async 
            Task<ActionResult<IEnumerable<AreaModel>>> 
            GetAreasByCountry(int countryId)
        {
            
            // SELECT * FROM tblName
            // WHERE tblName.id = {id}
            var areas = _context.Areas
                .Where(a => a.CountryId == countryId);

            return areas.ToList();

        }
  
    }
}