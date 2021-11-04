using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpresaListarFuncionarios.Entidades.Classes;
using EmpresaListarFuncionarios.Contexto;

namespace EmpresaListarFuncionarios.Pages.funcionario
{
    public class IndexModel : PageModel
    {
        private readonly EmpresaFuncionarioContext _context;

        public IndexModel(EmpresaFuncionarioContext context)
        {
            _context = context;
        }

        public IList<Funcionario> Funcionario { get;set; }

        public async Task OnGetAsync()
        {
            Funcionario = await _context.Funcionario.ToListAsync();
        }
    }
}
