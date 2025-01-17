﻿using Microsoft.EntityFrameworkCore;
using visitor_management_api.Models;

namespace visitor_management_api.Data
{
    public class VisitorAppContext : DbContext
    {
        public VisitorAppContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>()
                .HasMany<Visit>(v => v.Visits)
                .WithOne(v => v.Visitor)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasMany<Visit>(v => v.Visits)
                .WithOne(v => v.Employee)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}