using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClienteFornecedor.Contexto;
using EmpresaListarFuncionarios.Entidades.Classes;

namespace EmpresaListarFuncionarios.Pages.empresa
{
    public class EditModel : PageModel
    {
        private readonly ClienteFornecedor.Contexto.EmpresaFuncionarioContext _context;

        public EditModel(ClienteFornecedor.Contexto.EmpresaFuncionarioContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(Empresa.IdEmpresa))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.IdEmpresa == id);
        }
    }
}
