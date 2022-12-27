using Mc2.CrudTest.Application.Dtos;
using Mc2.CrudTest.Domain.CustomerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Queries;

public class GetCustomersQuery : IRequest<CustomersDTO>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}

