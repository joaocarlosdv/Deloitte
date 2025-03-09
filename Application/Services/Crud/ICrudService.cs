using Application.Dtos;
using Application.Dtos.Crud;
using DataAccess.Resposta;
using Domain.Models.Crud;
using System.Linq.Expressions;

namespace Application.Services.Crud
{
    public interface ICrudService<T, Dto> where T : CrudModel where Dto : CrudDto
    {
        Task<List<Dto>> ConsultarTodosAsync();
        Task<List<Dto>> ConsultarTodosAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);
        Task<Dto?> ConsultarPorIdAsync(int id);
        Task<RespostaOperacaoDto<Dto>> CadastrarAsync(Dto dto);
        Task<RespostaOperacaoDto<Dto>> EditarAsync(Dto entity);
        Task<RespostaOperacaoDto<Dto>> ExcluirAsync(Dto entity);
    }
}
