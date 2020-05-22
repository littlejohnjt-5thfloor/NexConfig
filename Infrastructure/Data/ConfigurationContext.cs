using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Data
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options)
            : base(options) { }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Pass> Passes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AccessToken> AccessTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
