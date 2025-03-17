using System.Reflection;

namespace BankApp.Server.Tests;
public static class Program
{
    public static int Main()
    {
        // TODO: implement main logic
        return default !;
    }

    private static IReadOnlyList<TestCase> DiscoverTests()
    {
        // TODO: implement discover tests logic
        return default !;
    }

    private sealed record TestCase(Type TestClass, MethodInfo Method);
}