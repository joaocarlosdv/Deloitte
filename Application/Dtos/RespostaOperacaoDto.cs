namespace Application.Dtos
{
    public class RespostaOperacaoDto<Dto>
    {
        public bool Sucesso { get; set; }
        public Dto Objeto { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public Exception Excecao { get; set; } = new Exception();
    }
}
