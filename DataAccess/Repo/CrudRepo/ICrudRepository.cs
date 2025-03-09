using DataAccess.Resposta;
using Domain.Models.Crud;
using System.Linq.Expressions;

namespace DataAccess.Repo.CrudRepo
{
    public interface ICrudRepository<T> where T : CrudModel
    {
        Task<List<T>> ConsultarTodosAsync();
        Task<List<T>> ConsultarTodosAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);
        Task<T?> ConsultarPorIdAsync(int id);
        Task<RespostaOperacao<T>> CadastrarAsync(T entity);
        Task<RespostaOperacao<T>> EditarAsync(T entity);
        Task<RespostaOperacao<T>> ExcluirAsync(T entity);
    }
}
