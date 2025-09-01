namespace ModularWebService.Contracts.Exceptions;

public class ApplicationNotFoundException(string entityName, uint id)
    : ApplicationException($"{entityName} '{id}' not found");