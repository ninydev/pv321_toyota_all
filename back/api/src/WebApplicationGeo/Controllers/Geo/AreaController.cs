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
    public class AreaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Area
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Areas.Include(a => a.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Area/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var areaModelLinq = (from area in _context.Areas
                    where area.Id == id
                    select new 
                    {
                        Area = area,
                        Country = area.Country,
                        Cities = area.Cities
                    })
                .AsEnumerable() // перевод в перечисляемое, чтобы загрузить данные
                .Select(x => x.Area) // извлечение Area после выполнения всех операций
                .FirstOrDefault();

            
            var areaModel = await _context.Areas
                .Include(a => a.Country)
                .Include(a=>a.Cities)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaModel == null)
            {
                return NotFound();
            }

            return View(areaModel);
        }

        // GET: Area/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(
                _context.Countries, "Id", "Name");
            return View();
        }

        // POST: Area/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryId")] AreaModel areaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", areaModel.CountryId);
            return View(areaModel);
        }

        // GET: Area/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaModel = await _context.Areas.FindAsync(id);
            if (areaModel == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", areaModel.CountryId);
            return View(areaModel);
        }

        // POST: Area/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryId")] AreaModel areaModel)
        {
            if (id != areaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaModelExists(areaModel.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", areaModel.CountryId);
            return View(areaModel);
        }

        // GET: Area/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaModel = await _context.Areas
                .Include(a => a.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaModel == null)
            {
                return NotFound();
            }

            return View(areaModel);
        }

        // POST: Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaModel = await _context.Areas.FindAsync(id);
            if (areaModel != null)
            {
                _context.Areas.Remove(areaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaModelExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
