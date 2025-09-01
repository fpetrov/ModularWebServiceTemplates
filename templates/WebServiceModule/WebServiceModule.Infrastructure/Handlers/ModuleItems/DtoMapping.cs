using WebServiceModule.Contracts;
using WebServiceModule.Domain;

namespace WebServiceModule.Infrastructure.Handlers.ModuleItems;

public static class DtoMapping
{
    public static ModuleItemDto FromModel(ModuleItem model) =>
        new(model.Id, model.Name);
}
