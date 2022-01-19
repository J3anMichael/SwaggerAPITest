#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBMKSwaggerAPI.Models;

namespace DBMKSwaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBMKItemsController : ControllerBase
    {
        private readonly DBMKContext _context;

        public DBMKItemsController(DBMKContext context)
        {
            _context = context;
        }

        // GET: api/DBMKItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DBMK>>> GetDBMK()
        {
            return await _context.DBMK.ToListAsync();
        }

        // GET: api/DBMKItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DBMK>> GetDBMK(long id)
        {
            var dBMK = await _context.DBMK.FindAsync(id);

            if (dBMK == null)
            {
                return NotFound();
            }

            return dBMK;
        }

        // PUT: api/DBMKItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDBMK(long id, DBMK dBMK)
        {
            if (id != dBMK.Id)
            {
                return BadRequest();
            }

            _context.Entry(dBMK).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBMKExists(id))
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

        // POST: api/DBMKItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DBMK>> PostDBMK(DBMK dBMK)
        {
            _context.DBMK.Add(dBMK);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDBMK", new { id = dBMK.Id }, dBMK);
        }

        // DELETE: api/DBMKItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDBMK(long id)
        {
            var dBMK = await _context.DBMK.FindAsync(id);
            if (dBMK == null)
            {
                return NotFound();
            }

            _context.DBMK.Remove(dBMK);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DBMKExists(long id)
        {
            return _context.DBMK.Any(e => e.Id == id);
        }
    }
}
