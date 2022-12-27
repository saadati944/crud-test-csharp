using Mc2.CrudTest.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Data;

public class CrudTestsContext : DbContext
{
    public CrudTestsContext() : base()
    {
    }

    public CrudTestsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Firstname)
            .HasMaxLength(150);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Lastname)
            .HasMaxLength(150);

        modelBuilder.Entity<Customer>()
            .Property(c => c.BankAccountNumber)
            .HasMaxLength(30);

        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.PhoneNumber);

        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.Email)
            .Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.Email)
            .HasIndex(e => e.Address)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth })
            .IsUnique();
    }

    public DbSet<Customer> Customers { get; set; }
}
