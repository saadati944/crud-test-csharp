namespace Mc2.CrudTest.Domain.Abstractions;

public interface ISpecification<TModel>
{
    public IQueryable<TModel> Apply(IQueryable<TModel> query);
}
