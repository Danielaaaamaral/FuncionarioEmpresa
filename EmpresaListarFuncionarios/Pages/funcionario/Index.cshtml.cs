using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Contexto;
using EmpresaListarFuncionarios.Repositorio;
using EmpresaListarFuncionarios.Entidades.Dtos;

namespace EmpresaListarFuncionarios.Pages.funcionario
{
    public class IndexModel : PageModel
    {
        private readonly EmpresaFuncionarioContext _context;
        private readonly IEmpresaFuncionarioRepositorio _repositorio;

        public IndexModel(EmpresaFuncionarioContext context, IEmpresaFuncionarioRepositorio repositorio)
        {
            _context = context;
            _repositorio = repositorio;
        }

        public IList<Funcionario> Funcionario { get;set; }
        public IList<FuncionarioResponseDto> FuncionarioResponseDto { get; set; }

        public async Task OnGetAsync()
        {
            Funcionario = await _context.Funcionario.ToListAsync();
            FuncionarioResponseDto = await _repositorio.BuscarTodosFuncionarios();
        }
    }
}
