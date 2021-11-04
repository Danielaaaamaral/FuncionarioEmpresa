using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Repositorio;
using EmpresaListarFuncionarios.Entidades.Dtos;
using EmpresaListarFuncionarios.Contexto;

namespace FuncionarioListarFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IEmpresaFuncionarioRepositorio _repositorio;
        private EmpresaFuncionarioContext _context;
        /// <summary>
        /// Construtor Funcionario 
        /// </summary>
        public FuncionariosController(IEmpresaFuncionarioRepositorio repositorio, EmpresaFuncionarioContext context)
        {
            this._repositorio = repositorio;
            this._context = context;
        }


        // GET: api/Funcionarios
        /// <summary>
        /// Lista todos Funcionarios
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioResponseDto>>> GetFuncionario()
        {
            try
            {
                return await _repositorio.BuscarTodosFuncionarios();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Funcionarios/5
        /// <summary>
        /// Lista funcionario por id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioResponseDto>> GetFuncionario(int id)
        {
            try
            {
                var Funcionario = await _repositorio.BuscarFuncionarioResponsePorId(id);

                if (Funcionario == null)
                {
                    throw new Exception("Funcionario não encontrado");
                }

                return Funcionario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // PUT: api/Funcionarios/5
        /// <summary>
        /// atualizar funcionario
        /// </summary>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<FuncionarioResponseDto> PutFuncionario([FromBody] Funcionario Funcionario)
        {
            try
            {
                return await _repositorio.AtualizarFuncionario(Funcionario);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // POST: api/Funcionarios
        /// <summary>
        /// Adicionar funcionario
        /// </summary>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<FuncionarioResponseDto> PostFuncionario([FromBody] Funcionario Funcionario)
        {
            try
            {
                return await _repositorio.AdicionarFuncionario(Funcionario);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // DELETE: api/Funcionarios/5
        /// <summary>
        /// Apagar Funcionario.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task DeleteFuncionario(int id)
        {
            try
            {
                await _repositorio.DeletarFuncionario(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
