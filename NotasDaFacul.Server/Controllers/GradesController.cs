using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDaFacul.Server.Data;
using NotasDaFacul.Server.Models;

namespace NotasDaFacul.Server.Controllers
{
    public class GradesController : Controller
    {
        private readonly ILogger<GradesController> _logger;
        private readonly GradesContext _context;

        public GradesController(ILogger<GradesController> logger, GradesContext context)
        {
            _logger = logger;
            _context = context;
        }

        /* [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        } */

        public async Task<IActionResult> IndexAsync()
        {
            var gradesData = _context.GradesModel
                .OrderBy(entry => entry.Date.Year)
                .ThenBy(entry => entry.Date.Month)
                .ThenBy(entry => entry.Date.Day)
                .ToListAsync();

            return View(await gradesData);
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradesModel = await _context.GradesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gradesModel == null)
            {
                return NotFound();
            }

            return View(gradesModel);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Course,Grade,Date")] GradesModel gradesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradesModel);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradesModel = await _context.GradesModel.FindAsync(id);
            if (gradesModel == null)
            {
                return NotFound();
            }
            return View(gradesModel);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Course,Grade,Date")] GradesModel gradesModel)
        {
            if (id != gradesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradesModelExists(gradesModel.Id))
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
            return View(gradesModel);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradesModel = await _context.GradesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gradesModel == null)
            {
                return NotFound();
            }

            return View(gradesModel);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gradesModel = await _context.GradesModel.FindAsync(id);
            if (gradesModel != null)
            {
                _context.GradesModel.Remove(gradesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradesModelExists(int id)
        {
            return _context.GradesModel.Any(e => e.Id == id);
        }
    }
}
