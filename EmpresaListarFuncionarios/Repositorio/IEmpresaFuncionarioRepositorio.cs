using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Entidades.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Repositorio
{
    public interface IEmpresaFuncionarioRepositorio
    {
        #region Empresa
        Task<List<EmpresaResponseDto>> BuscarTodosEmpresas();
        Task<Empresa> BuscarEmpresaPorId(long Id);
        Task DeletarEmpresa(long id);
        Task<Empresa> AtualizarEmpresa(Empresa empresa);
       Task AdicionarEmpresa(Empresa empresa);
        Task<EmpresaResponseDto> BuscarEmpresaResponsePorId(long Id);

        #endregion
        #region Funcionario
        Task<List<Funcionario>> BuscarTodosFuncionarios();
        Task<Funcionario> BuscarFuncionarioPorId(long Id);
        Task<FuncionarioResponseDto> AdicionarFuncionario(Funcionario funcionario);
        Task<Funcionario> AtualizarFuncionario(Funcionario funcionario);
        Task DeletarFuncionario(long id);

        #endregion
        
    }
}
