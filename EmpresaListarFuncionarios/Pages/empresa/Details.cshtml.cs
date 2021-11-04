using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Contexto;

namespace EmpresaListarFuncionarios.Pages.empresa
{
    public class DetailsModel : PageModel
    {
        private readonly EmpresaFuncionarioContext _context;

        public DetailsModel(EmpresaFuncionarioContext context)
        {
            _context = context;
        }

        public Empresa Empresa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empresa = await _context.Empresa.FirstOrDefaultAsync(m => m.IdEmpresa == id);

            if (Empresa == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
