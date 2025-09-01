using ModularWebService.Contracts.Exceptions;

namespace ModularWebService.Domain;

public static class Validation
{
    public static void NotEmptyOrThrow(string field)
    {
        if (string.IsNullOrWhiteSpace(field))
        {
            throw new ApplicationValidationException($"{nameof(field)} must be non‑empty string.");
        }
    }

    public static void LengthInRangeOrThrow(string field, int min, int max)
    {
        if (field.Length < min || field.Length > max)
        {
            throw new ApplicationValidationException($"{nameof(field)} length must be between {min} and {max}.");
        }
    }
}