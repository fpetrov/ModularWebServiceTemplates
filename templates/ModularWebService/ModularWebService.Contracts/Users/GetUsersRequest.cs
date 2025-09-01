using MediatR;

namespace ModularWebService.Contracts.Users;

public record GetUsersRequest(List<uint>? UserIds = null) : IRequest<List<UserDto>>;