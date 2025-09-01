using MediatR;
using ModularWebService.Contracts.Users;

namespace WebServiceModule.Contracts;

public record FetchUsersRequest() : IRequest<List<UserDto>>;
