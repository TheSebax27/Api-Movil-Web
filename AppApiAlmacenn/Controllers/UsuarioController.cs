using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppApiAlmacenn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppApiAlmacenn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AlmacenDbContext _context;
        public UsuarioController(AlmacenDbContext context)
        {
            _context = context;
        }


        [HttpGet("clientes/{idVendedor}")]
        public async Task<IActionResult> GetClientesAsignados(int idVendedor)
        {
            var clientes = await _context.ClienteVendedors
                .Where(cv => cv.IdVendedor == idVendedor)
                .Include(cv => cv.IdClienteNavigation)
                .Select(cv => new {
                        cv.IdClienteNavigation.IdUsuario,
                        cv.IdClienteNavigation.Documento,
                        cv.IdClienteNavigation.Nombres,
                        cv.IdClienteNavigation.Apellidos,
                        cv.IdClienteNavigation.Direccion,
                        cv.IdClienteNavigation.TelefonoFijo,
                        cv.IdClienteNavigation.Celular,
                        cv.IdClienteNavigation.Email,
                        cv.IdClienteNavigation.Ubicacion
                  })

                .ToListAsync();

            return Ok(clientes);
        }


        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetClienteById(int idCliente)
        {
            var cliente = await _context.Usuarios
                .Where(u => u.IdUsuario == idCliente && u.IdTipo == 3) // tipo cliente
                .Select(u => new {
                    u.IdUsuario,
                    u.Documento,
                    u.Nombres,
                    u.Apellidos,
                    u.Direccion,
                    u.TelefonoFijo,
                    u.Celular,
                    u.Email,
                    u.Ubicacion
                })
                .FirstOrDefaultAsync();

            if (cliente == null)
                return NotFound("Cliente no encontrado.");

            return Ok(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarVisita([FromBody] RegistrarVisitaDTO visitaDto)
        {
            var visita = new Visita
            {
                IdVendedor = visitaDto.IdVendedor,
                IdCliente = visitaDto.IdCliente,
                FechaVisita = DateTime.Now,
                Observaciones = visitaDto.Observaciones
            };

            _context.Visitas.Add(visita);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Visita registrada correctamente." });
        }



        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Documento) || string.IsNullOrEmpty(loginModel.Clave))
            {
                return BadRequest("Documento and Password are required.");
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(c => c.Documento == loginModel.Documento);
            if (usuario == null)
            {
                return Unauthorized(new
                {
                    Message = "Documento no encontrado.",
                    Success = false,
                    IdCliente = 0
                });
            }

            if (usuario.Clave != loginModel.Clave)
            {
                return Unauthorized(new
                {
                    Message = "Clave incorrecta.",
                    Success = false,
                    IdCliente = 0
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "Login exitoso.",
                Usuario = new
                {
                    usuario.IdUsuario,
                    usuario.Documento,
                    usuario.Nombres,
                    usuario.Apellidos,
                    usuario.IdTipo
                }
            });


        }
    }


}
