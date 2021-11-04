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

namespace EmpresaListarFuncionarios.Pages.empresa
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

        public IList<Empresa> Empresa { get;set; }
        public IList<EmpresaResponseDto> EmpresaResponseDto { get; set; }

        public async Task OnGetAsync()
        {
            Empresa = await _context.Empresa.ToListAsync();
            EmpresaResponseDto = await _repositorio.BuscarTodosEmpresas();
        }
    }
}
