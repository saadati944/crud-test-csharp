﻿using Mc2.CrudTest.Application.Dtos;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Handlers;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, CustomersDTO>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<CustomersDTO> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        // TODO: add filter parameters

        return Task.FromResult(new CustomersDTO
        {
            Total = _customerRepository.GetCount(),
            Customers = _customerRepository.GetCustomers().Skip(request.Page * request.PageSize).Take(request.PageSize).ToList()
        });
    }
}