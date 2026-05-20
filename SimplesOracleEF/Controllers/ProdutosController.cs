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
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoRespostaDTO>>> GetProdutos()
        {
            var produtos = await _context.Produtos
                .Include(p => p.Vendedor)
                .Select(p => new ProdutoRespostaDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    VendedorId = p.VendedorId,
                    VendedorNome = p.Vendedor.Nome
                })
                .ToListAsync();

            return produtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoRespostaDTO>> GetProduto(int id)
        {
            var produto = await _context.Produtos
                .Include(p => p.Vendedor)
                .Where(p => p.Id == id)
                .Select(p => new ProdutoRespostaDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    VendedorId = p.VendedorId,
                    VendedorNome = p.Vendedor.Nome
                })
                .FirstOrDefaultAsync();

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }


        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, ProdutosDTO produtoDto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            // Verifica se o novo Vendedor existe
            var vendedor = await _context.Vendedores.FindAsync(produtoDto.VendedorId);
            if (vendedor == null)
            {
                return BadRequest("Vendedor não encontrado.");
            }

            produto.Nome = produtoDto.Nome;
            produto.Preco = produtoDto.Preco;
            produto.VendedorId = produtoDto.VendedorId;

            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(ProdutosDTO produtoDto)
        {
            // Verifica se o vendedor existe
            var vendedor = await _context.Vendedores.FindAsync(produtoDto.VendedorId);
            if (vendedor == null)
            {
                return BadRequest("Vendedor não encontrado.");
            }

            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Preco = produtoDto.Preco,
                VendedorId = produtoDto.VendedorId
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }


        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
