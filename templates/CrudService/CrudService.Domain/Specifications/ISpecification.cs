using System.Linq.Expressions;

namespace CrudService.Domain.Specifications;

public interface ISpecification<T>
    where T : Entity
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
}