using MediatR;
using Microsoft.EntityFrameworkCore;
using WebServiceModule.Contracts;
using WebServiceModule.Domain;

namespace WebServiceModule.Infrastructure.Handlers.ModuleItems;

public class GetModuleItemsHandler(WebServiceModuleDbContext dbContext)
    : IRequestHandler<GetModuleItemsRequest, List<ModuleItemDto>>
{
    public async Task<List<ModuleItemDto>> Handle(GetModuleItemsRequest request, CancellationToken cancellationToken)
    {
        List<ModuleItem> items = await dbContext.ModuleItems
            .OrderBy(x => x.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items.ConvertAll(DtoMapping.FromModel);
    }
}
