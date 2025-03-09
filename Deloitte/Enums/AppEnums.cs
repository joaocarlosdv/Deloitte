using System.ComponentModel.DataAnnotations;

namespace Deloitte.Enums
{
    public enum ModoTela
    {
        [Display(Name = "Visualizar")]
        Visualizar = 0,
        [Display(Name = "Cadastrar")]
        Cadastrar = 1,
        [Display(Name = "Editar")]
        Editar = 2,
    }
}
