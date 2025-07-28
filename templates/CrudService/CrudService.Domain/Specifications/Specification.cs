using System.Linq.Expressions;

namespace CrudService.Domain.Specifications;

public abstract class Specification<T> : ISpecification<T>
    where T : Entity
{
    public Expression<Func<T, bool>> Criteria { get; protected set; } = _ => true;
    public List<Expression<Func<T, object>>> Includes { get; } = [];
    protected void AddInclude(Expression<Func<T, object>> include) => Includes.Add(include);
}