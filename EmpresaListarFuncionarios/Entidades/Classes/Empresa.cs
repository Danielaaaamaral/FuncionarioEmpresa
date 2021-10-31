using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Entidades.Classes
{
    public class Empresa
    {
        [Key]
        [DisplayName("Id")]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        public string NomeEmpresa{ get; set; }
    }
}
