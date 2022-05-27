namespace Bowling;

public static class ArgumentParser
{
    public static IEnumerable<int> ParseRolls(IEnumerable<string> args)
    {
        return args.Select(int.Parse);
    }
}