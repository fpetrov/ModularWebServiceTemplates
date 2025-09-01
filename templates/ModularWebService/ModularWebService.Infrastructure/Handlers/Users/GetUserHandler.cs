using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularWebService.Contracts.Exceptions;
using ModularWebService.Contracts.Users;
using ModularWebService.Domain;

namespace ModularWebService.Infrastructure.Handlers.Users;

public class GetUserHandler(ApplicationDbContext dbContext) : IRequestHandler<GetUserRequest, UserDto>
{
    public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        User? user = await dbContext.Users
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new ApplicationNotFoundException("User", request.Id);
        }

        return DtoMapping.FromModel(user);
    }
}