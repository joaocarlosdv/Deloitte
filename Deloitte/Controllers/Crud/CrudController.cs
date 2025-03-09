using Microsoft.AspNetCore.Mvc;

namespace Deloitte.Controllers.Crud
{
    public class CrudController : Controller
    {
        public void AdicionarMessagemErro(string message) => TempData["erro"] = message;
        public void AdicionarMessagemAlerta(string message) => TempData["alerta"] = message;
        public void AdicionarMessagemSucesso(string message) => TempData["sucesso"] = message;
    }
}
