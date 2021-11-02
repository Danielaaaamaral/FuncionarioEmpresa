using ClienteFornecedor.Contexto;
using EmpresaListarFuncionarios.Entidades.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Repositorio
{
    public class EmpresaFuncionarioRepositorio : IEmpresaFuncionarioRepositorio, IDisposable
    {
        private EmpresaFuncionarioContext _contexto = null;
        bool disposed = false;
        #region Construtor

        public EmpresaFuncionarioRepositorio(EmpresaFuncionarioContext contexto)
        {
            _contexto = contexto;
        }
        #endregion
        #region empresa
        public async Task<Empresa> AdicionarEmpresa(Empresa empresa)
        {
            try
            {
                _contexto.Empresa.Add(empresa);
                await _contexto.SaveChangesAsync();
                return await BuscarEmpresaPorId(empresa.IdEmpresa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Empresa> BuscarEmpresaPorId(long Id)
        {
            try
            {
                return await _contexto.Empresa.Where(x => x.IdEmpresa == Id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Empresa> AtualizarEmpresa(Empresa empresa)
        {
            try
            {
                _contexto.Entry(empresa).State = EntityState.Modified;
                _contexto.Empresa.Update(empresa);
                await _contexto.SaveChangesAsync();
                return empresa;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<Empresa>> BuscarTodosEmpresas()
        {
            try
            {
                return await _contexto.Empresa.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task DeletarEmpresa(long id)
        {
            try
            {
                var emp = await BuscarEmpresaPorId(id);
                _contexto.Empresa.Remove(emp);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
        #region funcionario
        public async Task<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            try
            {
                _contexto.Funcionario.Add(funcionario);
                await _contexto.SaveChangesAsync();
                return await BuscarFuncionarioPorId(funcionario.IdFuncionario);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Funcionario> AtualizarFuncionario(Funcionario funcionario)
        {
            try
            {
                _contexto.Funcionario.Update(funcionario);
                await _contexto.SaveChangesAsync();
                return funcionario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Funcionario> BuscarFuncionarioPorId(long Id)
        {
            try
            {
                return await _contexto.Funcionario.Where(x => x.IdFuncionario == Id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<Funcionario>> BuscarTodosFuncionarios()
        {
            try
            {
                return await _contexto.Funcionario.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletarFuncionario(long id)
        {
            try
            {
                var funcionario = await BuscarFuncionarioPorId(id);
                _contexto.Funcionario.Remove(funcionario);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
       
        #region dispose
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                //libera recursos gerenciados pela CLR
            }
            //else: libera recursos não gerenciados pela CLR
            disposed = true;
        }
        #endregion

    }
}
