using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationGeo.Data;
using WebApplicationGeo.Models.Entities.Geo;

namespace WebApplicationGeo.Controllers.Geo
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: City
        public async Task<IActionResult> Index()
        {
            var data = _context.Cities
                .Include(c => c.Area);
            return View(await data.ToListAsync());
        }

        // GET: City/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            // SELECT * FROM Cities WHERE Cities.id = $city_id 
            CityModel currentCity =  await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);

            // SELECT * FROM Areas WHERE Areas.id = $area_id
            AreaModel cityArea = await 
                _context.Areas.Where(a => a.Id == currentCity.AreaId).FirstOrDefaultAsync();
            

            // SELECT * FROM Cities
            // JOIN Areas ON Area.id = Cities.area_id 
            var cityModel = await _context.Cities
                .Include(city => city.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityModel == null)
            {
                return NotFound();
            }

            return View(cityModel);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            ViewData["Areas"] 
                = new SelectList(_context.Areas, "Id", "Name");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AreaId")] CityModel cityModel)
        {

                if (ModelState.IsValid)
                {
                    _context.Add(cityModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            return View(cityModel);
        }

        // GET: City/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityModel = await _context.Cities.FindAsync(id);
            if (cityModel == null)
            {
                return NotFound();
            }
            return View(cityModel);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AreaId,Area")] CityModel cityModel)
        {
            if (id != cityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityModelExists(cityModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cityModel);
        }

        // GET: City/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityModel = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityModel == null)
            {
                return NotFound();
            }

            return View(cityModel);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityModel = await _context.Cities.FindAsync(id);
            if (cityModel != null)
            {
                _context.Cities.Remove(cityModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityModelExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
