using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Entidades.Classes
{
    public class Funcionario
    {
       
            [Key]
            [UIHint("Id")]
            [DisplayName("Id")]
            public int IdFuncionario { get; set; }

            [Required]
            [DisplayName("Empresa")]
            public int IdEmpresa { get; set; }

            [Required]
            [DisplayName("Cargo")]
            public string Cargo { get; set; }

            [Required]
            [StringLength(100)]
            [DisplayName("Nome")]
            public string NomeFuncionario { get; set; }
            [Required]
            [DisplayName("Salario")]
            public decimal Salario { get; set; }


        }
}
