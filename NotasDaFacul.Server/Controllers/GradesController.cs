using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDaFacul.Server.Data;
using NotasDaFacul.Server.Models;

namespace NotasDaFacul.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly GradesContext _context;

        public GradesController(GradesContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradesModel>>> GetGradesModel()
        {
            return await _context.GradesModel.OrderBy(entry => entry.Date.Year)
                .ThenBy(entry => entry.Date.Month)
                .ThenBy(entry => entry.Date.Day)
                .ToListAsync();
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradesModel>> GetGradesModel(int id)
        {
            var gradesModel = await _context.GradesModel.FindAsync(id);

            if (gradesModel == null)
            {
                return NotFound();
            }

            return gradesModel;
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradesModel(int id, GradesModel gradesModel)
        {
            if (id != gradesModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(gradesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradesModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GradesModel>> PostGradesModel(GradesModel gradesModel)
        {
            _context.GradesModel.Add(gradesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradesModel", new { id = gradesModel.Id }, gradesModel);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradesModel(int id)
        {
            var gradesModel = await _context.GradesModel.FindAsync(id);
            if (gradesModel == null)
            {
                return NotFound();
            }

            _context.GradesModel.Remove(gradesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradesModelExists(int id)
        {
            return _context.GradesModel.Any(e => e.Id == id);
        }
    }
}
