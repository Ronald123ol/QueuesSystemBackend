using Microsoft.EntityFrameworkCore;
using QueuesSystem.Domain.Entities;
using QueuesSystem.Infrastructure.Context.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Infrastructure.Context
{
    public interface IQueuesDbContext
    {
        public DbSet<T> GetDbSet<T>() where T : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
    public class QueuesDbContext : DbContext, IQueuesDbContext
    {
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Queue> Queues { get; set; } = null!;
        public DbSet<PersonQueue> PeopleQueues { get; set; } = null!;

        public QueuesDbContext(DbContextOptions<QueuesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddPeopleMapping();
            modelBuilder.AddQueuesMapping();
            modelBuilder.AddPeopleQueuesMapping();
        }

        public DbSet<T> GetDbSet<T>() where T : BaseEntity => Set<T>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
