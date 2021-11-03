using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Entidades.Enum
{
    public enum CargosEnum : int
    {
        [Display(Name = "Administrador")]
        Administrador = 1,

        [Display(Name = "Desenvolvedor")]
        Desenvolvedor = 2,

        [Display(Name = "QA")]
        QA = 3,

        [Display(Name = "Designer")]
        Designer = 4,

        [Display(Name = "Gerente")]
        Gerente = 5,
    }
}
