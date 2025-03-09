using Domain.Models.Crud;

namespace Domain.Models
{
    public class Usuario : CrudModel
    {
        public string Nome { get; private set; } = string.Empty;
        public decimal ValorHora { get; private set; } = 0;
        public DateTime DataCadastro { get; private set; }
        public Boolean Ativo { get; private set; } = true;
    }
}
