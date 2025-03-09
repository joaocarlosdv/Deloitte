using DataAccess.Repo.CrudRepo;
using Domain.Models;

namespace DataAccess.Repo.Interfaces
{
    public interface IUsuarioRepo : ICrudRepository<Usuario>
    {
        Task<List<Usuario>> ConsultarTodosAsync(int limit, int offset, string? search, int colOrder, string dirOrder);
        Task<int> CountAsync(string? search, int colOrder, string dirOrder);
    }
}
