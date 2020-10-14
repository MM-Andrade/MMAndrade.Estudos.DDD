using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;
using MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Mapeamentos;
using System;
using System.Linq;

namespace MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Contexto
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Prato> Pratos { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            if (Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();         //AutoMigration. Verifica se não há pendencias de migrations, se existir, aplica quando o contexto é excutado.
        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //aplica a configuração de tabela definido em "PratoMap"
            modelBuilder.ApplyConfiguration(new PratoMap());
        }
    }
}
