using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDaFacul.Server.Data;

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
    }
}
