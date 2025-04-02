using System.Reflection;

namespace Domain.Common.Models;

public abstract class Enumeration : IComparable
{

    private readonly string[] _aliases = [];

    public string Name { get; private set; }

    public int Id { get; private set; }

    protected Enumeration(int id, string name, params string[] aliases)
    {
        (Id, Name) = (id, name);

        if (aliases.Length > 0)
        {
            _aliases = aliases;
        }
    }

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                    .Select(f => f.GetValue(null))
                    .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
        return absoluteDifference;
    }

    public static T FromValue<T>(int value) where T : Enumeration
    {
        var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName) where T : Enumeration
    {
        var matchingItem = Parse<T, string>(displayName, "display name", item => string.Equals(item.Name, displayName, StringComparison.OrdinalIgnoreCase) ||
                                                                                  item._aliases.Any(alias => string.Equals(alias, displayName, StringComparison.OrdinalIgnoreCase)));
        return matchingItem;
    }

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        return matchingItem ?? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
    }

    public int CompareTo(object? other) => Id.CompareTo(((Enumeration?)other)?.Id);
}