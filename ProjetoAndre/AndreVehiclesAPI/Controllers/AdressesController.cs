using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreVehiclesAPI.Data;
using Models;

namespace AndreVehiclesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly AndreVehiclesAPIContext _context;

        public AdressesController(AndreVehiclesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adress>>> GetAdress()
        {
          if (_context.Adress == null)
          {
              return NotFound();
          }
            return await _context.Adress.ToListAsync();
        }

        // GET: api/Adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adress>> GetAdress(int id)
        {
          if (_context.Adress == null)
          {
              return NotFound();
          }
            var adress = await _context.Adress.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }

        // PUT: api/Adresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdress(int id, Adress adress)
        {
            if (id != adress.Id)
            {
                return BadRequest();
            }

            _context.Entry(adress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
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

        // POST: api/Adresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adress>> PostAdress(Adress adress)
        {
          if (_context.Adress == null)
          {
              return Problem("Entity set 'AndreVehiclesAPIContext.Adress'  is null.");
          }
            _context.Adress.Add(adress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            if (_context.Adress == null)
            {
                return NotFound();
            }
            var adress = await _context.Adress.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }

            _context.Adress.Remove(adress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdressExists(int id)
        {
            return (_context.Adress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
