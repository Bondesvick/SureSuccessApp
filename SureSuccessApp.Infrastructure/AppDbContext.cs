using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SureSuccessApp.Domain.Entities;
using SureSuccessApp.Domain.Repositories;
using SureSuccessApp.Infrastructure.SchemaDefinitions;

namespace SureSuccessApp.Infrastructure
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "sureSuccess";

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntitySchemaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}