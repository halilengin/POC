using Common;
using Data.Entity;
using Framework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Data
{
    public class POCContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public POCContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectString = _configuration.GetConnectionString(Constant.DefaultConnectionStringName);
            optionsBuilder.UseInMemoryDatabase(Constant.DefaultConnectionStringName);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterAllEntities(modelBuilder);
        }

        private void RegisterAllEntities(ModelBuilder modelBuilder)
        {
            var entityTypes = Assembly.Load("Data").GetExportedTypes().Where(c => c.IsClass &&
                                    !c.IsAbstract &&
                                    c.IsPublic &&
                                    typeof(BaseEntity).IsAssignableFrom(c));

            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}
