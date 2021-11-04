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
    public class DeleteModel : PageModel
    {
        private readonly EmpresaFuncionarioContext _context;
        private readonly IEmpresaFuncionarioRepositorio _repositorio;

        public DeleteModel(EmpresaFuncionarioContext context, IEmpresaFuncionarioRepositorio repositorio)
        {
            _context = context;
            _repositorio = repositorio;
        }

        [BindProperty]
        public Funcionario Funcionario { get; set; }
        public FuncionarioResponseDto FuncionarioResponseDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario = await _context.Funcionario.FirstOrDefaultAsync(m => m.IdFuncionario == id);
            FuncionarioResponseDto = await _repositorio.BuscarFuncionarioResponsePorId((long)id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario = await _context.Funcionario.FindAsync(id);

            if (Funcionario != null)
            {
                _context.Funcionario.Remove(Funcionario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
