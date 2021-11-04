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
        /// <summary>
        /// Identificador Empresa
        /// </summary>
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        /// <summary>
        /// Nome Empresa.
        /// </summary>
        public string NomeEmpresa{ get; set; }


        [StringLength(100)]
        [DisplayName("Endereço")]
        /// <summary>
        /// Endereço
        /// </summary>
        public string Logradouro { get; set; }

        [StringLength(10)]
        [DisplayName("Número")]
        /// <summary>
        /// numero
        /// </summary>
        public string Numero { get; set; }

        [StringLength(9)]
        [DisplayName("Cep")]
        /// <summary>
        /// CEP
        /// </summary>
        public string Cep { get; set; }

        [StringLength(100)]
        [DisplayName("Cidade")]
        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; set; }

        [StringLength(2)]
        [DisplayName("UF")]
        /// <summary>
        /// Estado
        /// </summary>
        public string Uf { get; set; }

        [StringLength(100)]
        [DisplayName("Bairro")]
        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; set; }

        [StringLength(60)]
        [DisplayName("Complemento")]
        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }

      
    }
}
