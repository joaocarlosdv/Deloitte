using DataAccess.Context;
using DataAccess.Repo.CrudRepo;
using DataAccess.Repo.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repo
{
    public class UsuarioRepo : CrudRepository<Usuario>, IUsuarioRepo
    {
        public UsuarioRepo(ApiContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Usuario>> ConsultarTodosAsync(int limit,
                                                             int offset,
                                                             string? search,
                                                             int colOrder,
                                                             string dirOrder)
        {
            var query = dbContext.Set<Usuario>()
                    .Where(x => 
                           string.IsNullOrEmpty(search) || (
                           x.Id.ToString().Contains(search) ||
                           x.Nome!.Contains(search) ||
                           x.ValorHora.ToString().Contains(search) ||
                           x.DataCadastro.ToString().Contains(search)
                           ))
                    .AsNoTracking();

            switch (colOrder)
            {
                case 0:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
                    break;
                case 1:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.Nome) : query.OrderByDescending(x => x.Nome);
                    break;
                case 2:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.ValorHora) : query.OrderByDescending(x => x.ValorHora);
                    break;
                case 3:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.DataCadastro) : query.OrderByDescending(x => x.DataCadastro);
                    break;
                case 4:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.Ativo) : query.OrderByDescending(x => x.Ativo);
                    break;
                default:
                    query = query.OrderBy(x => x.Id); 
                    break;
            }

            return await query
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
        }

        public async Task<int> CountAsync(string? search,
                                          int colOrder,
                                          string dirOrder)
        {
            var query = dbContext.Set<Usuario>()
                    .Where(x =>
                           string.IsNullOrEmpty(search) || (
                           x.Id.ToString().Contains(search) ||
                           x.Nome!.Contains(search) ||
                           x.ValorHora.ToString().Contains(search) ||
                           x.DataCadastro.ToString().Contains(search)
                           ))
                    .AsNoTracking();

            switch (colOrder)
            {
                case 0:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
                    break;
                case 1:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.Nome) : query.OrderByDescending(x => x.Nome);
                    break;
                case 2:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.ValorHora) : query.OrderByDescending(x => x.ValorHora);
                    break;
                case 3:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.DataCadastro) : query.OrderByDescending(x => x.DataCadastro);
                    break;
                case 4:
                    query = dirOrder == "asc" ? query.OrderBy(x => x.Ativo) : query.OrderByDescending(x => x.Ativo);
                    break;
                default:
                    query = query.OrderBy(x => x.Id);
                    break;
            }

            return await query.CountAsync();
        }
    }
}
