using JetBrains.Annotations;
using ModularWebService.Contracts.Exceptions;

namespace ModularWebService.Domain;

public class User
{
    public User(uint id, string name, int age, string city)
    {
        Validation.NotEmptyOrThrow(name);
        Validation.NotEmptyOrThrow(city);
        Validation.LengthInRangeOrThrow(name, 2, 100);
        Validation.LengthInRangeOrThrow(city, 2, 100);
        ValidateAge(age);

        Id = id;
        Name = name.Trim();
        Age = age;
        City = city.Trim();
    }

    public uint Id { get; private set; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string City { get; private set; }

    private static void ValidateAge(int age)
    {
        const int minAge = 0;
        const int maxAge = 120;

        if (age is < minAge or > maxAge)
        {
            throw new ApplicationValidationException($"Age must be between {minAge} and {maxAge} (inclusive)");
        }
    }

    [UsedImplicitly]
    private User()
    {
        Name = null!;
        Age = 0;
        City = null!;
    }
}