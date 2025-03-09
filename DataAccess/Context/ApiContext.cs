using DataAccess.Config;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
