using CrudService.Domain;
using CrudService.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CrudService.Infrastructure;

internal static class SpecificationEvaluator
{
    public static IQueryable<T> Evaluate<T>(this IQueryable<T> q, ISpecification<T> spec) where T : Entity 
        => spec.Includes.Aggregate(q.Where(spec.Criteria), (cur, inc) 
            => cur.Include(inc));
}
