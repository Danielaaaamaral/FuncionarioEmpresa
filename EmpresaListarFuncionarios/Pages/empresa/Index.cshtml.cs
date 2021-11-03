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
    public class IndexModel : PageModel
    {
        private readonly ClienteFornecedor.Contexto.EmpresaFuncionarioContext _context;

        public IndexModel(ClienteFornecedor.Contexto.EmpresaFuncionarioContext context)
        {
            _context = context;
        }

        public IList<Empresa> Empresa { get;set; }

        public async Task OnGetAsync()
        {
            Empresa = await _context.Empresa.ToListAsync();
        }
    }
}
