using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RodrigoTiendaBack.Business;
using RodrigoTiendaBack.Entities;

namespace RodrigoTiendaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteService.GetAllClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(Cliente cliente)
        {
            var newCliente = await _clienteService.AddCliente(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = newCliente.ClienteID }, newCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteID)
                return BadRequest();

            var updatedCliente = await _clienteService.UpdateCliente(cliente);
            if (updatedCliente == null)
                return NotFound();

            return Ok(updatedCliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var result = await _clienteService.DeleteCliente(id);
            if (!result)
                return NotFound();

            return NoContent();
        }


        [HttpPost("{clienteId}/carrito")]
        public async Task<IActionResult> AgregarAlCarrito(int clienteId, [FromBody] int articuloId)
        {
            var cliente = await _clienteService.GetClienteById(clienteId);
            if (cliente == null)
                return NotFound();

            var articulo = await _articuloService.GetArticuloById(articuloId);
            if (articulo == null)
                return NotFound();

            await _clienteService.AgregarArticuloAlCarrito(clienteId, articuloId);
            return Ok();
        }

        [HttpDelete("{clienteId}/carrito/{articuloId}")]
        public async Task<IActionResult> EliminarDelCarrito(int clienteId, int articuloId)
        {
            var result = await _clienteService.EliminarArticuloDelCarrito(clienteId, articuloId);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{clienteId}/carrito")]
        public async Task<IActionResult> ObtenerCarrito(int clienteId)
        {
            var carrito = await _clienteService.ObtenerCarrito(clienteId);
            if (carrito == null)
                return NotFound();

            return Ok(carrito);
        }


        public async Task AgregarArticuloAlCarrito(int clienteId, int articuloId)
        {
            var clienteArticulo = new ClienteArticulo
            {
                ClienteID = clienteId,
                ArticuloID = articuloId,
                Fecha = DateTime.Now
            };

            _context.ClienteArticulos.Add(clienteArticulo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EliminarArticuloDelCarrito(int clienteId, int articuloId)
        {
            var clienteArticulo = await _context.ClienteArticulos
                .FirstOrDefaultAsync(ca => ca.ClienteID == clienteId && ca.ArticuloID == articuloId);

            if (clienteArticulo == null)
                return false;

            _context.ClienteArticulos.Remove(clienteArticulo);
            await _context.SaveChangesAsync();
            return true;
        }
                
    }
}
