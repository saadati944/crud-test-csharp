using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Domain.CustomerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Queries;

public class GetCustomerQuery : IRequest<Customer>
{
    public Guid ID { get; set; }
}
