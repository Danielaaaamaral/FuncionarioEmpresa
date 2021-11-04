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
            /// <summary>
            /// Identificador Funcionario
            /// </summary>
        public int IdFuncionario { get; set; }

            [Required]
            [DisplayName("Empresa")]
        /// <summary>
        /// Identificador Empresa
        /// </summary>
        public int IdEmpresa { get; set; }

            [Required]
            [DisplayName("IdCargo")]
        /// <summary>
        /// Identificador Cargo
        /// </summary>
        public int IdCargo { get; set; }

            [Required]
            [StringLength(100)]
            [DisplayName("Nome")]
        /// <summary>
        /// Nome funcionario
        /// </summary>
        public string NomeFuncionario { get; set; }
            [Required]
            [DisplayName("Salario")]
        /// <summary>
        /// Valor Salario
        /// </summary>
        public decimal Salario { get; set; }



    }
}
