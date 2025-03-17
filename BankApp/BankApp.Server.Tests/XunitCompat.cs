using System.Collections;

namespace Xunit;
[AttributeUsage(AttributeTargets.Method)]
public sealed class FactAttribute : Attribute
{
}

public static class Assert
{
    public static void True(bool condition, string? message = null)
    {
        // TODO: implement true logic
        ;
    }

    public static void False(bool condition, string? message = null)
    {
        // TODO: implement false logic
        ;
    }

    public static void Null(object? value, string? message = null)
    {
        // TODO: implement null logic
        ;
    }

    public static void NotNull(object? value, string? message = null)
    {
        // TODO: implement not null logic
        ;
    }

    public static void Equal<T>(T expected, T actual)
    {
        // TODO: implement equal logic
        ;
    }

    public static void Equal<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
        // TODO: implement equal logic
        ;
    }

    public static void StartsWith(string expectedStart, string? actual)
    {
        // TODO: implement starts with logic
        ;
    }

    public static void Contains(string expectedSubstring, string? actualString)
    {
        // TODO: implement contains logic
        ;
    }

    public static void Contains<T>(IEnumerable<T> collection, Predicate<T> match)
    {
        // TODO: implement contains logic
        ;
    }

    public static void DoesNotContain<T>(IEnumerable<T> collection, Predicate<T> match)
    {
        // TODO: implement does not contain logic
        ;
    }

    private static void AssertEnumerablesEqual(IEnumerable expected, IEnumerable actual)
    {
        // TODO: implement assert enumerables equal logic
        ;
    }
}