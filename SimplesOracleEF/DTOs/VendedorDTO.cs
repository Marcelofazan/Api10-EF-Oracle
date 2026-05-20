using System.ComponentModel.DataAnnotations;

namespace SimplesOracleEF.DTOs
{
    public class VendedorDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}
