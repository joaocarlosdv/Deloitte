using DataAccess.Context;
using DataAccess.Resposta;
using Domain.Models.Crud;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repo.CrudRepo
{
    public class CrudRepository<T> : ICrudRepository<T> where T : CrudModel
    {
        protected readonly ApiContext dbContext;
        protected DbSet<T> DbSet => dbContext.Set<T>();

        public CrudRepository(ApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private static void ClearDbContextState(DbContext context)
        {
            var entries = context.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached;
            }
        }

        public virtual async Task<List<T>> ConsultarTodosAsync()
        {
            try
            {
                return await dbContext.Set<T>()
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public virtual async Task<List<T>> ConsultarTodosAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            var query = dbContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            try
            {
                return await query.Where(predicate).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public virtual async Task<T?> ConsultarPorIdAsync(int id)
        {
            try
            {
                return await dbContext.Set<T>()
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<RespostaOperacao<T>> CadastrarAsync(T entity)
        {
            var resposta = new RespostaOperacao<T>();

            try
            {
                dbContext.Set<T>().Add(entity);
                await dbContext.SaveChangesAsync();

                resposta.Objeto = entity;
                resposta.Sucesso = true;
                resposta.Mensagem = "Cadastro efetuado com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                ClearDbContextState(dbContext);

                resposta.Objeto = entity;
                resposta.Sucesso = false;
                resposta.Mensagem = "Erro ao efetuar a operação Cadastrar";
                resposta.Excecao = ex;

                return resposta;
            }
        }

        public virtual async Task<RespostaOperacao<T>> EditarAsync(T entity)
        {
            var resposta = new RespostaOperacao<T>();

            try
            {
                var entry = dbContext.Entry(entity);
                entry.State = EntityState.Modified;
                await dbContext.SaveChangesAsync();

                resposta.Objeto = entity;
                resposta.Sucesso = true;
                resposta.Mensagem = "Alteração realizada com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                ClearDbContextState(dbContext);

                resposta.Objeto = entity;
                resposta.Sucesso = false;
                resposta.Mensagem = "Erro ao efetuar a operação Editar";
                resposta.Excecao = ex;

                return resposta;
            }
        }

        public virtual async Task<RespostaOperacao<T>> ExcluirAsync(T entity)
        {
            var resposta = new RespostaOperacao<T>();

            try
            {
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();

                resposta.Objeto = entity;
                resposta.Sucesso = true;
                resposta.Mensagem = "Exclusão realizada com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                ClearDbContextState(dbContext);

                resposta.Objeto = entity;
                resposta.Sucesso = false;
                resposta.Mensagem = "Erro ao efetuar a operação Excluir";
                resposta.Excecao = ex;

                return resposta;
            }
        }
    }
}
