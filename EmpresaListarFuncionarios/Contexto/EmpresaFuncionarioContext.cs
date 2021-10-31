
using EmpresaListarFuncionarios.Entidades.Classes;
using Microsoft.EntityFrameworkCore;



namespace ClienteFornecedor.Contexto
{
    public class EmpresaFuncionarioContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        //construtor
        public EmpresaFuncionarioContext(DbContextOptions<EmpresaFuncionarioContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionario");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
        }
    }
}
