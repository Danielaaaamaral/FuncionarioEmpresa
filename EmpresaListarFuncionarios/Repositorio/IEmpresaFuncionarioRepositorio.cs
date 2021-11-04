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
        Task<EmpresaResponseDto> BuscarEmpresaResponsePorId(long Id);
        Task<Empresa> BuscarEmpresaPorId(long Id);
        Task DeletarEmpresa(long id);
        Task<EmpresaResponseDto> AtualizarEmpresa(Empresa empresa);
       Task AdicionarEmpresa(Empresa empresa);


        #endregion
        #region Funcionario
        Task<List<FuncionarioResponseDto>> BuscarTodosFuncionarios();
        Task<FuncionarioResponseDto> BuscarFuncionarioResponsePorId(long Id);
        Task<Funcionario> BuscarFuncionarioPorId(long Id);
        Task<FuncionarioResponseDto> AdicionarFuncionario(Funcionario funcionario);
        Task<FuncionarioResponseDto> AtualizarFuncionario(Funcionario funcionario);
        Task DeletarFuncionario(long id);

        #endregion
        
    }
}
