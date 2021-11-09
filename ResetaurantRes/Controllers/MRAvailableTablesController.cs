using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRestautrantRes;
using BRestaurantRes.Data;

namespace ResetaurantRes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MRAvailableTablesController : ControllerBase
    {
        private readonly ResetaurantResContext _context;

        public MRAvailableTablesController(ResetaurantResContext context)
        {
            _context = context;
        }

        // GET: api/MRAvailableTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MRAvailableTables>>> GetMRAvailableTables()
        {
            return await _context.MRAvailableTables.ToListAsync();
        }

        // GET: api/MRAvailableTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MRAvailableTables>> GetMRAvailableTables(int id)
        {
            var mRAvailableTables = await _context.MRAvailableTables.FindAsync(id);

            if (mRAvailableTables == null)
            {
                return NotFound();
            }

            return mRAvailableTables;
        }

        // PUT: api/MRAvailableTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMRAvailableTables(int id, MRAvailableTables mRAvailableTables)
        {
            if (id != mRAvailableTables.RtableId)
            {
                return BadRequest();
            }

            _context.Entry(mRAvailableTables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MRAvailableTablesExists(id))
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

        // POST: api/MRAvailableTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MRAvailableTables>> PostMRAvailableTables(MRAvailableTables mRAvailableTables)
        {
            _context.MRAvailableTables.Add(mRAvailableTables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMRAvailableTables", new { id = mRAvailableTables.RtableId }, mRAvailableTables);
        }

        // DELETE: api/MRAvailableTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMRAvailableTables(int id)
        {
            var mRAvailableTables = await _context.MRAvailableTables.FindAsync(id);
            if (mRAvailableTables == null)
            {
                return NotFound();
            }

            _context.MRAvailableTables.Remove(mRAvailableTables);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MRAvailableTablesExists(int id)
        {
            return _context.MRAvailableTables.Any(e => e.RtableId == id);
        }
    }
}
