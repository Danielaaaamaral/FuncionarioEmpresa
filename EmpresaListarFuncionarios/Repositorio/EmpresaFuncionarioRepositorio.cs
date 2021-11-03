using AutoMapper;
using ClienteFornecedor.Contexto;
using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Entidades.Dtos;
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
        public async Task AdicionarEmpresa(Empresa empresa)
        {
            try
            {
                _contexto.Empresa.Add(empresa);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<EmpresaResponseDto> BuscarEmpresaResponsePorId(long Id)
        {
            try
            {
                var emp =  _contexto.Empresa.Where(x => x.IdEmpresa == Id).FirstOrDefault();

                return MappRespEmpresa(emp); 
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
                return _contexto.Empresa.Where(x => x.IdEmpresa == Id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> BuscarNomeEmpresaPorId(long Id)
        {
            try
            {
                var emp= _contexto.Empresa.Where(x => x.IdEmpresa == Id).FirstOrDefault();
                return emp.NomeEmpresa;
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
        public async Task<List<EmpresaResponseDto>> BuscarTodosEmpresas()
        {
            try
            {
                var response = new List<EmpresaResponseDto>();
                var Listemp = await _contexto.Empresa.ToListAsync();
                var empResponse = new EmpresaResponseDto();
                foreach (var empresa in Listemp) {
                    
                    var listFuncionarios =await BuscarEmpresasFuncionarios(empresa.IdEmpresa);
                    empResponse = MappRespEmpresa(empresa);
                    foreach (var func in listFuncionarios)
                    {
                        var funcResp = await MappRespFuncionario(func);
                        empResponse.ListFuncionario.Add(funcResp);
                    }
                }
                response.Add(empResponse);
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private async Task<List<Funcionario>> BuscarEmpresasFuncionarios(long idEmpresa)
        {

           return  await _contexto.Funcionario.Where(x => x.IdEmpresa == idEmpresa).ToListAsync();

        }
        private EmpresaResponseDto MappRespEmpresa(Empresa emp)
        {

            EmpresaResponseDto empresarespose = new EmpresaResponseDto
            {
                IdEmpresa = emp.IdEmpresa,
                NomeEmpresa = emp.NomeEmpresa,
                Bairro = emp.Bairro,
                Cep = emp.Cep,
                Cidade = emp.Cidade,
                Complemento = emp.Complemento,
                Logradouro = emp.Logradouro,
                Numero = emp.Numero,
                Uf = emp.Uf,
                ListFuncionario = new List<FuncionarioResponseDto>()
            };
            return empresarespose;
        }
        private async Task<FuncionarioResponseDto> MappRespFuncionario(Funcionario func)
        {

            FuncionarioResponseDto respose = new FuncionarioResponseDto
            {
                IdCargo = func.IdCargo,
                IdEmpresa = func.IdEmpresa,
                IdFuncionario = func.IdFuncionario,
                NomeFuncionario = func.NomeFuncionario,
                Salario=func.Salario,
                NomeEmpresa = await BuscarNomeEmpresaPorId(func.IdEmpresa),
            };
            return respose;
        }
        public async Task DeletarEmpresa(long id)
        {
            try
            {
                var emp = await BuscarEmpresaPorId(id);
                var funcionarios = await BuscarEmpresasFuncionarios(id);
                 foreach(var item in funcionarios)
                  {
                        _contexto.Funcionario.Remove(item);
                        await _contexto.SaveChangesAsync();
                  }

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
        public async Task<FuncionarioResponseDto> AdicionarFuncionario(Funcionario funcionario)
        {
            try
            {
                _contexto.Funcionario.Add(funcionario);

                await _contexto.SaveChangesAsync();
                 var func = await BuscarFuncionarioPorId(funcionario.IdFuncionario);
                return await MappRespFuncionario(func);
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
