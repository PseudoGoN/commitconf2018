using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PythonSucks.Data.Mappings;
using PythonSucks.Repository;

using System;
using System.Collections.Generic;
using System.Text;

namespace PythonSucks.Data
{
    public class PythonSucksDbContext : IdentityDbContext
    {
        
        public PythonSucksDbContext(DbContextOptions<PythonSucksDbContext> options) : base(options)
        { }

        public new DbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HaterMapping());
            modelBuilder.ApplyConfiguration(new ReasonMapping());
            modelBuilder.ApplyConfiguration(new VoteMapping());
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);

        }
        
    }
}
