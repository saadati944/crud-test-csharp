using Mc2.CrudTest.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerAggregate;

public class AllCustomersSpecification : ISpecification<Customer>
{
    public IQueryable<Customer> Apply(IQueryable<Customer> query)
    {
        return query;
    }
}
