using MediatR;
using ModularWebService.Contracts.Users;
using WebServiceModule.Contracts;

namespace WebServiceModule.Infrastructure.Handlers;

public class FetchUsersHandler(IMediator mediator) : IRequestHandler<FetchUsersRequest, List<UserDto>>
{
    // Пример взаимодействия с исходным проектом.
    public Task<List<UserDto>> Handle(FetchUsersRequest request, CancellationToken cancellationToken) =>
        mediator.Send(new GetUsersRequest(), cancellationToken);
}
