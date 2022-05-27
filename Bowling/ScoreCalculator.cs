namespace Bowling;

public static class ScoreCalculator
{
    public static int CalculateFrameScore(Frame frame, IEnumerable<int> nextPins)
    {
        var frameSum = frame.Rolls.Sum();
        var relevantNumberNextRolls = frame switch
        {
            _ when frame.IsLast() => 0,
            _ when frame.IsStrike() => 2,
            _ when frame.IsSpare() => 1,
            _ => 0
        };

        return frameSum + nextPins.Take(relevantNumberNextRolls).Sum();
    }
}