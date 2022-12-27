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

    public DbSet<Customer> Customers { get; set; }
}
