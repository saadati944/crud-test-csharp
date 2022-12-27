using Mc2.CrudTest.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Dtos;

public class CustomersDTO
{
    public int Total;
    public List<Customer> Customers { get; set; }
}
