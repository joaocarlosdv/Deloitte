using Application.Dtos;
using Application.Services.Crud;
using Application.Services.Interface;
using AutoMapper;
using DataAccess.Repo;
using DataAccess.Repo.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class UsuarioService : CrudService<Usuario, UsuarioDto>, IUsuarioService
    {
        private readonly UsuarioRepo usuarioRepo;
        public UsuarioService(IMapper mapper,
                              IUsuarioRepo repositorio,
                              IHttpContextAccessor accessor) : base(mapper, repositorio, accessor)
        {
            usuarioRepo = (UsuarioRepo)repositorio;
        }

        public async Task<List<UsuarioDto>> ConsultarTodosAsync(int limit,
                                                                int offset,
                                                                string? search,
                                                                int colOrder,
                                                                string dirOrder)
        {
            return _mapper.Map<List<UsuarioDto>>(await usuarioRepo.ConsultarTodosAsync(limit, offset, search, colOrder, dirOrder));
        }

        public async Task<int> CountAsync(string? search,
                                          int colOrder,
                                          string dirOrder)
        {
            return await usuarioRepo.CountAsync(search, colOrder, dirOrder);
        }
    }
}
