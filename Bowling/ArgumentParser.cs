namespace Bowling;

public static class ArgumentParser
{
    public static IEnumerable<int> ParsePins(IEnumerable<string> args)
    {
        return args.Select(int.Parse);
    }
}