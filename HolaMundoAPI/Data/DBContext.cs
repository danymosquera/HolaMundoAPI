using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolaMundoAPI.Data.Models;

namespace HolaMundoAPI.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));

            base.OnModelCreating(modelBuilder);
        }

    }
}
