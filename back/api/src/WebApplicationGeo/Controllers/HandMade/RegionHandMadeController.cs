using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplicationGeo.Data;
using WebApplicationGeo.Models.Entities.Geo;

namespace WebApplicationGeo.Controllers.HandMade;

public class RegionHandMadeController : Controller
{


    /// <summary>
    /// Користувач звернувся за формою
    /// </summary>
    /// <returns>html сторинка з формою</returns>
    public IActionResult ShowForm()
    {
        return View();
    }

    
    /// <summary>
    /// Користувач заповнив форму - а тут я чекаю форму
    /// </summary>
    /// <param name="name">Я чекаю тільки Ім'я</param>
    /// <returns> Повертаюсь до форми </returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveToDataBase(string name)
    {
        if (name.Length < 3 || name.Length > 20)
        {
            return RedirectToAction(nameof(ShowForm));
        }
        RegionModel newModel = new RegionModel();
        newModel.Name = name;
        _context.Add(newModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ShowForm));
    } 
    
    
    private readonly ApplicationDbContext _context;

    public RegionHandMadeController(ApplicationDbContext context)
    {
        _context = context;
    }
}