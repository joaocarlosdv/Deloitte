using Application.Dtos;
using Deloitte.Enums;

namespace Deloitte.Models
{
    public class UsuarioViewModel
    {
        public List<UsuarioDto> ListaUsuarios { get; set; } = new List<UsuarioDto>();
        public int recordsTotal { get; set; } = 0;
        public int recordsFiltered { get; set; } = 0;
        public UsuarioDto Usuario { get; set; } = new UsuarioDto();
        public ModoTela ModoTela { get; set; }
    }
}
