using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularWebService.Contracts.Users;
using ModularWebService.Domain;

namespace ModularWebService.Infrastructure.Handlers.Users;

public class GetUsersHandler(ApplicationDbContext dbContext) : IRequestHandler<GetUsersRequest, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        IQueryable<User> query = dbContext.Users;

        if (request.UserIds is { Count: > 0 })
        {
            uint[] ids = request.UserIds.Distinct().ToArray();
            query = query.Where(s => ids.Contains(s.Id));
        }

        List<User> users = await query
            .OrderBy(x => x.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users.ConvertAll(DtoMapping.FromModel);
    }
}