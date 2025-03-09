using Application.Dtos;
using Application.Services.Crud;
using Domain.Models;

namespace Application.Services.Interface
{
    public interface IUsuarioService : ICrudService<Usuario, UsuarioDto>
    {
        Task<List<UsuarioDto>> ConsultarTodosAsync(int limit, int offset, string? search, int colOrder, string dirOrder);
        Task<int> CountAsync(string? search, int colOrder, string dirOrder);
    }
}
