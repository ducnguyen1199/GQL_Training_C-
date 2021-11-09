using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Training.Data.Models;

namespace Training.Data
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId);

            builder
                .Entity<Department>()
                .HasMany(d => d.Users)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId);

            //Data seeding
            builder
                .Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    Name = "NCDUC",
                    DepartmentId = 1,
                },
                new User
                {
                    Id = 2,
                    Name = "Nguyen Van A",
                    DepartmentId = 1,
                },
                new User
                {
                    Id = 3,
                    Name = "ABC",
                    DepartmentId = 2,
                });

            builder
                .Entity<Department>()
                .HasData(
                new Department
                {
                    Id = 1,
                    Name = "PG2-DC13",
                },
                new Department
                {
                    Id = 2,
                    Name = "Data-Gene",
                });
        }
    }
}
