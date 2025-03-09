namespace Deloitte.Requests
{
    public class PaginacaoRequest
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string search { get; set; } = string.Empty;
        public int colOrder { get; set; }
        public string? dirOrder { get; set; } = string.Empty;
    }
}
