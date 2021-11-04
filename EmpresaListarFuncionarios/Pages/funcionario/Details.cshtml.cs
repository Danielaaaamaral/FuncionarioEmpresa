using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Contexto;
using EmpresaListarFuncionarios.Entidades.Dtos;
using EmpresaListarFuncionarios.Repositorio;

namespace EmpresaListarFuncionarios.Pages.funcionario
{
    public class DetailsModel : PageModel
    {
        private readonly EmpresaFuncionarioContext _context;
        private readonly IEmpresaFuncionarioRepositorio _repositorio;

        public DetailsModel(EmpresaFuncionarioContext context, IEmpresaFuncionarioRepositorio repositorio)
        {
            _context = context;
            _repositorio = repositorio;
        }

        public Funcionario Funcionario { get; set; }
        public FuncionarioResponseDto FuncionarioResponseDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario = await _context.Funcionario.FirstOrDefaultAsync(m => m.IdFuncionario == id);
            FuncionarioResponseDto = await _repositorio.BuscarFuncionarioResponsePorId((long) id);

            if (Funcionario == null)
            {
                return NotFound();
            }

            if (FuncionarioResponseDto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
