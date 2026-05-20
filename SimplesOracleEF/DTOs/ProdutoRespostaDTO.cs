using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SimplesOracleEF.DTOs
{
    public class ProdutoRespostaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public int VendedorId { get; set; }
        public string VendedorNome { get; set; }
    }
}
