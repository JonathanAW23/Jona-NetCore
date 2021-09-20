using Microsoft.EntityFrameworkCore;
using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Person>()
                .HasOne<Account>(p => p.Account)
                .WithOne(a => a.Person)
                .HasForeignKey<Account>(a => a.NIK);

            modelBuilder.Entity<Account>()
                .HasOne<Profiling>(a => a.Profiling)
                .WithOne(p => p.Account)
                .HasForeignKey<Profiling>(p => p.NIK);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(ar => ar.Account);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.AccountRoles)
                .WithOne(ar => ar.Role);

            modelBuilder.Entity<AccountRole>()
                .HasKey(a => new { a.NIK, a.Role_Id });

            modelBuilder.Entity<Profiling>()
                .HasOne<Education>(p => p.Education)
                .WithMany(e => e.Profilings)
                .HasForeignKey(p => p.Education_Id);

            modelBuilder.Entity<Education>()
                .HasOne<University>(e => e.University)
                .WithMany(u => u.Educations)
                .HasForeignKey(e => e.University_Id);

        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
