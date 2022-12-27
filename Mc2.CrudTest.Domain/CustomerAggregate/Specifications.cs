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
        return query.OrderBy(c => c.Lastname).ThenBy(c => c.Firstname).ThenBy(c => c.Email.Address);
    }
}

public class HasEmailSpecification : ISpecification<Customer>
{
    private string _email;

    public HasEmailSpecification(string email)
    {
        _email = email;
    }

    public IQueryable<Customer> Apply(IQueryable<Customer> query)
    {
        return query.Where(c => c.Email.Address == _email);
    }
}

public class HasNameAndDateOfBirthSpecification : ISpecification<Customer>
{
    private string _firstname;
    private string _lastname;
    private DateTime _dateOfBirth;

    public HasNameAndDateOfBirthSpecification(string firstname, string lastname, DateTime dateOfBirth)
    {
        _firstname = firstname;
        _lastname = lastname;
        _dateOfBirth = dateOfBirth;
    }

    public IQueryable<Customer> Apply(IQueryable<Customer> query)
    {
        return query.Where(c => c.Firstname == _firstname && c.Lastname == _lastname && c.DateOfBirth == _dateOfBirth);
    }
}
