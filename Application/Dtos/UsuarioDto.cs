using Application.Dtos.Crud;

namespace Application.Dtos
{
    public class UsuarioDto : CrudDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal ValorHora { get; set; } = 0;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public Boolean Ativo { get; set; }
    }
}
