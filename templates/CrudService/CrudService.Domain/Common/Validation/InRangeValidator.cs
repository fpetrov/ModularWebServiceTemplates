using System.Numerics;
using CrudService.Domain.Common.Exceptions;

namespace CrudService.Domain.Common.Validation;

public static partial class Validation
{
    public static void InRangeOrThrow<T>(T field, T min, T max)
        where T : INumber<T>
    {
        if (field < min || field > max)
        {
            throw new ValidationException($"Field {nameof(field)} must be between {min} and {max}.");
        }
    }

    public static void LengthInRangeOrThrow(string field, int min, int max)
        => InRangeOrThrow(field.Length, min, max);
}