using MediatR;

namespace WebServiceModule.Contracts;

public record GetModuleItemsRequest : IRequest<List<ModuleItemDto>>;
