using Application.Dtos;
using Application.Services;
using Application.Services.Crud;
using Application.Services.Interface;
using Deloitte.Controllers.Crud;
using Deloitte.Enums;
using Deloitte.Models;
using Deloitte.Requests;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte.Controllers
{
    public class UsuarioController : CrudController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService service)
        {
            _usuarioService = service;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public async Task<UsuarioViewModel> ConsultarUsuarios([FromBody] PaginacaoRequest request)
        {
            var lista = await _usuarioService.ConsultarTodosAsync(request.limit, request.offset, request.search, request.colOrder, request.dirOrder);
            var count = await _usuarioService.CountAsync(request.search, request.colOrder, request.dirOrder);

            UsuarioViewModel model = new UsuarioViewModel();
            model.ListaUsuarios = lista;
            model.recordsTotal = lista.Count();
            model.recordsFiltered = count;

            return model;
        }

        public async Task<IActionResult> Cadastro()
        {
            UsuarioViewModel model = new UsuarioViewModel();
            model.ModoTela = ModoTela.Cadastrar;

            return View("Cadastro", model);
        }

        public async Task<IActionResult> Editar(int idUsuario)
        {
            UsuarioViewModel model = new UsuarioViewModel();
            model.ModoTela = ModoTela.Editar;
            model.Usuario = await _usuarioService.ConsultarPorIdAsync(idUsuario) ?? new UsuarioDto();

            return View("Cadastro", model);
        }

        public async Task<IActionResult> Visualizar(int idUsuario)
        {
            UsuarioViewModel model = new UsuarioViewModel();
            model.ModoTela = ModoTela.Visualizar;
            model.Usuario = await _usuarioService.ConsultarPorIdAsync(idUsuario) ?? new UsuarioDto();

            return View("Cadastro", model);
        }

        public async Task<IActionResult> Salvar(UsuarioDto usuario)
        {
            if (usuario.Id == 0)
            {
                var resposta = await _usuarioService.CadastrarAsync(usuario);
                if (resposta.Sucesso)
                {
                    AdicionarMessagemSucesso(resposta.Mensagem);
                }
                else
                {
                    AdicionarMessagemErro(resposta.Mensagem);
                }
            }
            else
            {
                var resposta = await _usuarioService.EditarAsync(usuario);
                if (resposta.Sucesso)
                {
                    AdicionarMessagemSucesso(resposta.Mensagem);
                }
                else
                {
                    AdicionarMessagemErro(resposta.Mensagem);
                }
            }
            return View("Index");
        }

        public async Task<IActionResult> Excluir(int idUsuario)
        {
            var usuario = await _usuarioService.ConsultarPorIdAsync(idUsuario);
            var resposta = await _usuarioService.ExcluirAsync(usuario);
            if (resposta.Sucesso)
            {
                AdicionarMessagemSucesso(resposta.Mensagem);
            }
            else
            {
                AdicionarMessagemErro(resposta.Mensagem);
            }

            return View("Index");
        }
    }
}
