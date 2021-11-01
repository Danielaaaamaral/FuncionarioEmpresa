using EmpresaListarFuncionarios.Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Repositorio
{
    public interface IEmpresaFuncionarioRepositorio
    {
        #region Empresa
        Task<List<Empresa>> BuscarTodosEmpresas();
        Task<Empresa> BuscarEmpresaPorId(long Id);
        Task DeletarEmpresa(long id);
        Task<Empresa> AtualizarEmpresa(Empresa empresa);
        Task<Empresa> AdicionarEmpresa(Empresa empresa);
        #endregion
        #region Funcionario
        Task<List<Funcionario>> BuscarTodosFuncionarios();
        Task<Funcionario> BuscarFuncionarioPorId(long Id);
        Task<Funcionario> AdicionarFuncionario(Funcionario funcionario);
        Task<Funcionario> AtualizarFuncionario(Funcionario funcionario);
        Task DeletarFuncionario(long id);

        #endregion
        #region Endereco
        Task<Endereco> BuscarEnderecoPorId(long Id);
        Task<Endereco> AdicionarEndereco(Endereco endereco);
        Task DeletarEndereco(long id);

        #endregion
    }
}
