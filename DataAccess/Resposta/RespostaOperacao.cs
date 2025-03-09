namespace DataAccess.Resposta
{
    public class RespostaOperacao<T>
    {
        public bool Sucesso { get; set; }
        public T Objeto { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public Exception Excecao { get; set; } = new Exception();
    }
}
