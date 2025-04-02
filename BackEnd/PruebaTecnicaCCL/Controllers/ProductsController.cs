using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaCCL.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PostgresContext _context;

        public ProductsController(PostgresContext context)
        {
            _context = context;
        }

        [HttpGet("inventario")]
        public async Task<ActionResult<IEnumerable<Producto>>> ConsultarInventario()
        {
            var identity = HttpContext.User.Identity;
            if (identity == null || !identity.IsAuthenticated)
            {
                return Unauthorized(new { mensaje = "No tienes permisos para acceder" });
            }

            var inventario = await _context.Productos.ToListAsync();
            return Ok(inventario);
        }
    }
}
