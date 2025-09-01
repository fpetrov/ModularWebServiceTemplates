using ModularWebService.Contracts.Users;
using ModularWebService.Domain;

namespace ModularWebService.Infrastructure.Handlers.Users;

public class DtoMapping
{
    public static UserDto FromModel(User model) =>
        new(model.Id, model.Name, model.Age, model.City);
}