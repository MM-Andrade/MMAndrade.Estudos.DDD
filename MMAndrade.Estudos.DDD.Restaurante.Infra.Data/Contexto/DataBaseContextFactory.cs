using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Contexto
{
    /// <summary>
    /// classe para possibilitar a utilização do DatabaseContext em tempo de execução
    /// </summary>
    public class DataBaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=DDDApplication;User Id=dddapp;Password=x>V#mR8K)3s-BQ");

            return new DatabaseContext(optionsBuilder.Options);

        }
    }
}
