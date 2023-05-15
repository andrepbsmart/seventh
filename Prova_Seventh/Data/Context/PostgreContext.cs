using System;

using Microsoft.EntityFrameworkCore;

using Prova.Data.Mapping;
using Prova.Domain.Entities;

namespace Prova.Data.Context
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {

        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new ServerMap());
            modelbuilder.ApplyConfiguration(new VideoMap());

            base.OnModelCreating(modelbuilder);
        }
    }
}
