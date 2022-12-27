using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Abstractions;

public interface ISpecification<TModel>
{
    public IQueryable<TModel> Apply(IQueryable<TModel> query);
}
