using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ContextDb : DbContext
    {
        private string _connectionString;

        public ContextDb(DbContextOptions options, string connectionString = null)
            : base(options)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                options.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(options);
        }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}