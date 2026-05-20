using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplesOracleEF.Data;
using SimplesOracleEF.DTOs;
using SimplesOracleEF.Models;

namespace SimplesOracleEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendedorRespostaDTO>>> GetVendedores()
        {
            var vendedores = await _context.Vendedores
                .Include(f => f.Produtos)
                .Select(f => new VendedorRespostaDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Produtos = f.Produtos.Select(p => new ProdutoResumoDTO
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.Preco
                    }).ToList()
                })
                .ToListAsync();

            return vendedores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendedorRespostaDTO>> GetVendedor(int id)
        {
            var vendedor = await _context.Vendedores
                .Include(f => f.Produtos)
                .Where(f => f.Id == id)
                .Select(f => new VendedorRespostaDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Produtos = f.Produtos.Select(p => new ProdutoResumoDTO
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.Preco
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }


        // PUT: api/Vendedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(int id, VendedorDTO vendedorDto)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            vendedor.Nome = vendedorDto.Nome;

            _context.Entry(vendedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Vendedores
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(VendedorDTO vendedorDto)
        {
            var vendedor = new Vendedor
            {
                Nome = vendedorDto.Nome
            };

            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVendedor), new { id = vendedor.Id }, vendedor);
        }

        private bool VendedorExists(int id)
        {
            return _context.Vendedores.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedor(int id)
        {
            var vendedor = await _context.Vendedores
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (vendedor == null)
            {
                return NotFound();
            }

            if (vendedor.Produtos.Any())
            {
                return BadRequest("Não é possível excluir um vendedor com produtos vinculados.");
            }

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
