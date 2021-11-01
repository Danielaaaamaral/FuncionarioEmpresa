using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteFornecedor.Contexto;
using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Repositorio;

namespace EmpresaListarFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private IEmpresaFuncionarioRepositorio _repositorio;

        public EmpresasController(IEmpresaFuncionarioRepositorio repositorio, EmpresaFuncionarioContext context)
        {
            this._repositorio = repositorio;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresa()
        {
            try
            {
                return await _repositorio.BuscarTodosEmpresas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            try
            {
                var empresa = await _repositorio.BuscarEmpresaPorId(id);

                if (empresa == null)
                {
                    throw new Exception("Empresa não encontrada");
                }

                return empresa;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<Empresa> PutEmpresa([FromBody]Empresa empresa)
        {
            try
            {
                return await _repositorio.AtualizarEmpresa(empresa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // POST: api/Empresas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<Empresa> PostEmpresa([FromBody]Empresa empresa)
        {
            try
            {
                return await _repositorio.AdicionarEmpresa(empresa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task DeleteEmpresa(int id)
        {
            try
            {
                 await _repositorio.DeletarEmpresa(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
    }
}
