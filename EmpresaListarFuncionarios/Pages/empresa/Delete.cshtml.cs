using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClienteFornecedor.Contexto;
using EmpresaListarFuncionarios.Entidades.Classes;

namespace EmpresaListarFuncionarios.Pages.empresa
{
    public class DeleteModel : PageModel
    {
        private readonly ClienteFornecedor.Contexto.EmpresaFuncionarioContext _context;

        public DeleteModel(ClienteFornecedor.Contexto.EmpresaFuncionarioContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empresa = await _context.Empresa.FindAsync(id);

            if (Empresa != null)
            {
                _context.Empresa.Remove(Empresa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
