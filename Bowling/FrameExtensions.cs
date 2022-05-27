namespace Bowling;

public static class FrameExtensions
{
    public static bool IsLast(this Frame frame)
    {
        return frame.Number == 10;
    }

    public static bool IsSpare(this Frame frame)
    {
        return frame.Rolls.Count == 2 && frame.TotalPins() == 10;
    }

    public static bool IsStrike(this Frame frame)
    {
        return frame.Rolls.Count == 1 && frame.TotalPins() == 10;
    }

    public static bool IsClosed(this Frame frame)
    {
        var isLast = frame.IsLast();
        var isStrike = frame.IsStrike();
        var has2Rolls = frame.HasNumberOfRolls(2);
        var has3Rolls = frame.HasNumberOfRolls(3);
        var frameScoreLessThan10 = frame.Rolls.Sum() < 10;

        return (isLast is false && isStrike) ||
               (isLast is false && has2Rolls) ||
               (isLast && has2Rolls && frameScoreLessThan10) ||
               (isLast && has3Rolls);
    }

    private static bool HasNumberOfRolls(this Frame frame, int number)
    {
        return frame.Rolls.Count == number;
    }

    private static int TotalPins(this Frame frame)
    {
        return frame.Rolls.Sum();
    }
}