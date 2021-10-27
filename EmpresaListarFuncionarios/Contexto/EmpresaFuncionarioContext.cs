using ClienteFornecedor.Entidades.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClienteFornecedor.Contexto
{
    public class EmpresaFuncionarioContext : DbContext
    {
        //public DbSet<Empresa> Empresa { get; set; }
        //public DbSet<Funcionario> Funcionario { get; set; }
   
        //construtor
        public EmpresaFuncionarioContext(DbContextOptions<EmpresaFuncionarioContext> options)
         : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Daniela\\source\\repos\\ClienteFornecedor\\ClienteFornecedor\\Scripts\\DBDados.mdf;Integrated Security=True;Connect Timeout=30");
        //}
    }
}
