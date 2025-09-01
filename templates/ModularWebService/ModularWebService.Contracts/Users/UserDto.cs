namespace ModularWebService.Contracts.Users;

public record UserDto(
    uint Id,
    string Name,
    int Age,
    string City);