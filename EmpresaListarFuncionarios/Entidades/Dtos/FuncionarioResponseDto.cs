using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Entidades.Dtos
{
    public class FuncionarioResponseDto
    {
        [DisplayName("Id")]
        public int IdFuncionario { get; set; }

        [DisplayName("IdEmpresa")]
        public int IdEmpresa { get; set; }

        [DisplayName("IdCargo")]
        public int IdCargo { get; set; }

        [DisplayName("Cargo")]
        public string Cargo => EnumHelper.GetDescription<CargosEnum>(IdCargo);

        [DisplayName("Nome")]
        public string NomeFuncionario { get; set; }

        [DisplayName("Salario")]
        public decimal Salario { get; set; }

        [DisplayName("Nome Empresa")]
        public string NomeEmpresa { get; set; }

    }
}
