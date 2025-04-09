using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAlmacen.Context;
using ApiAlmacen.Models;

namespace ApiAlmacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsignacionClienteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionCliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionCliente>>> GetasignacionCliente()
        {
            return await _context.asignacionCliente.ToListAsync();
        }

        // GET: api/AsignacionCliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionCliente>> GetAsignacionCliente(int id)
        {
            var asignacionCliente = await _context.asignacionCliente.FindAsync(id);

            if (asignacionCliente == null)
            {
                return NotFound();
            }

            return asignacionCliente;
        }

        // PUT: api/AsignacionCliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionCliente(int id, AsignacionCliente asignacionCliente)
        {
            if (id != asignacionCliente.IdAsignacion)
            {
                return BadRequest();
            }

            _context.Entry(asignacionCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionClienteExists(id))
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

        // POST: api/AsignacionCliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignacionCliente>> PostAsignacionCliente(AsignacionCliente asignacionCliente)
        {
            _context.asignacionCliente.Add(asignacionCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignacionCliente", new { id = asignacionCliente.IdAsignacion }, asignacionCliente);
        }

        // DELETE: api/AsignacionCliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionCliente(int id)
        {
            var asignacionCliente = await _context.asignacionCliente.FindAsync(id);
            if (asignacionCliente == null)
            {
                return NotFound();
            }

            _context.asignacionCliente.Remove(asignacionCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionClienteExists(int id)
        {
            return _context.asignacionCliente.Any(e => e.IdAsignacion == id);
        }
    }
}
