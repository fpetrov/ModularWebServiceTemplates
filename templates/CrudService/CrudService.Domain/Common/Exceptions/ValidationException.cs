namespace CrudService.Domain.Common.Exceptions;

public class ValidationException(string message) : Exception(message);