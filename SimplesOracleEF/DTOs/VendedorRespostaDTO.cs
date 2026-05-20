using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SimplesOracleEF.DTOs
{
    public class VendedorRespostaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<ProdutoResumoDTO> Produtos { get; set; }
    }
}
