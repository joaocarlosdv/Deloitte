using Application.Dtos;
using Application.Dtos.Crud;
using AutoMapper;
using DataAccess.Repo.CrudRepo;
using DataAccess.Resposta;
using Domain.Models.Crud;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Application.Services.Crud
{
    public class CrudService<T, Dto> : ICrudService<T, Dto> where T : CrudModel where Dto : CrudDto
    {

        public readonly IMapper _mapper;
        public readonly ICrudRepository<T> _repositorio;
        public readonly IHttpContextAccessor _accessor;

        public CrudService(IMapper mapper, ICrudRepository<T> repositorio, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _repositorio = repositorio;
            _accessor = accessor;
        }

        public virtual async Task<List<Dto>> ConsultarTodosAsync()
        {
            return _mapper.Map<List<Dto>>(await _repositorio.ConsultarTodosAsync());            
        }

        public virtual async Task<List<Dto>> ConsultarTodosAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            return _mapper.Map<List<Dto>>(await _repositorio.ConsultarTodosAsync(predicate, includes));
        }

        public virtual async Task<Dto?> ConsultarPorIdAsync(int id)
        {
            return _mapper.Map<Dto>(await _repositorio.ConsultarPorIdAsync(id));
        }

        public virtual async Task<RespostaOperacaoDto<Dto>> CadastrarAsync(Dto dto)
        {
            return _mapper.Map<RespostaOperacaoDto<Dto>>(await _repositorio.CadastrarAsync(_mapper.Map<T>(dto)));
        }  

        public virtual async Task<RespostaOperacaoDto<Dto>> EditarAsync(Dto dto)
        {
            return _mapper.Map<RespostaOperacaoDto<Dto>>(await _repositorio.EditarAsync(_mapper.Map<T>(dto)));
        }

        public virtual async Task<RespostaOperacaoDto<Dto>> ExcluirAsync(Dto dto)
        {
            return _mapper.Map<RespostaOperacaoDto<Dto>>(await _repositorio.ExcluirAsync(_mapper.Map<T>(dto)));
        }
    }
}
