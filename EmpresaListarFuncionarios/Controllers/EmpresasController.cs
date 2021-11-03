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
using Microsoft.AspNetCore.Authorization;
using EmpresaListarFuncionarios.Entidades.Dtos;

namespace EmpresaListarFuncionarios.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaFuncionarioRepositorio _repositorio;
        private EmpresaFuncionarioContext _context;

        public EmpresasController(IEmpresaFuncionarioRepositorio repositorio, EmpresaFuncionarioContext context)
        {
            this._repositorio = repositorio;
            this._context = context;
        }

      // GET: api/Empresas
        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<EmpresaResponseDto>> GetEmpresa()
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
        public async Task<EmpresaResponseDto> GetEmpresa(int id)
        {
            try
            {
                var empresa = await _repositorio.BuscarEmpresaResponsePorId(id);

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
        public async Task PostEmpresa([FromBody]Empresa empresa)
        {
            try
            {
                 await _repositorio.AdicionarEmpresa(empresa);
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
