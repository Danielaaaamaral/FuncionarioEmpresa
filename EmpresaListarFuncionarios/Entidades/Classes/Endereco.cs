using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Entidades.Classes
{
    public class Endereco
    {

        [Key]
        [UIHint("Id")]
        [DisplayName("Id")]
        public int IdEndereco { get; set; }

        [StringLength(100)]
        [DisplayName("Endereço")]
        public string Logradouro { get; set; }

        [StringLength(10)]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [StringLength(9)]
        [DisplayName("Cep")]
        public string Cep { get; set; }

        [StringLength(100)]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [StringLength(2)]
        [DisplayName("UF")]
        public string Uf { get; set; }

        [StringLength(100)]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [StringLength(60)]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }
    }
}
