
using EmpresaListarFuncionarios.Entidades.Classes;
using Microsoft.EntityFrameworkCore;



namespace EmpresaListarFuncionarios.Contexto
{
    public class EmpresaFuncionarioContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

        //construtor
        /// <summary>
        /// Constutor Context
        /// </summary>
        public EmpresaFuncionarioContext(DbContextOptions<EmpresaFuncionarioContext> options)
         : base(options)
        {
        }

    }
}
