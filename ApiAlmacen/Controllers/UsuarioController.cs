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
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Getusuario()
        {
            return await _context.usuario.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.usuario.Any(e => e.IdUsuario == id);
        }

        // POST: api/Usuario/Login
        [HttpPost("Login")]
        public async Task<ActionResult<object>> Login([FromBody] LoginModel login)
        {
            try
            {
                var usuario = await _context.usuario
                    .Include(u => u.tipoUsuario)
                    .FirstOrDefaultAsync(u => u.Documento == login.Documento && u.clave == login.Clave);

                if (usuario == null)
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "Documento o clave incorrectos",
                        Usuario = (Usuario)null
                    });
                }

                // Agregar el nombre del tipo de usuario si está disponible
                if (usuario.tipoUsuario != null)
                {
                    usuario.tipoUsuario = usuario.tipoUsuario;
                }

                return new
                {
                    Success = true,
                    Message = "Login exitoso",
                    Usuario = usuario
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = $"Error interno del servidor: {ex.Message}",
                    Usuario = (Usuario)null
                });
            }
        }

        // Clase para recibir los datos de login
        public class LoginModel
        {
            public string Documento { get; set; }
            public string Clave { get; set; }
        }
    }
}