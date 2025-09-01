using MediatR;

namespace ModularWebService.Contracts.Users;

public record GetUserRequest(
    uint Id)
    : IRequest<UserDto>;