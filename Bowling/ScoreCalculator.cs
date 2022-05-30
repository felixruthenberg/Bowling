namespace Bowling;

public static class ScoreCalculator
{
    public static void CalculateScores(Frame[] frames)
    {
        var framesAndNextPins = GetFramesAndNextPins(frames);
        AddFramesScores(framesAndNextPins);
        AddCumulativeScore(frames);
    }

    private static void AddFramesScores(IEnumerable<(Frame, IEnumerable<int>)> framesAndNextPins)
    {
        foreach (var (frame, nextPins) in framesAndNextPins)
        {
            frame.Score = CalculateFrameScore(frame, nextPins);
        }
    }

    private static void AddCumulativeScore(IEnumerable<Frame> frames)
    {
        var cumulativeScore = 0;
        foreach (var frame in frames)
        {
            cumulativeScore += frame.Score ?? 0;
            frame.TotalScore = cumulativeScore;
        }
    }

    private static IEnumerable<(Frame, IEnumerable<int>)> GetFramesAndNextPins(Frame[] frames)
    {
        var query = from frame in frames
            let nextFrames = frames.Where(f => f.Number > frame.Number)
            let nextRolls = nextFrames.SelectMany(f => f.Rolls)
            select (frame, nextRolls);
        return query;
    }

    private static int CalculateFrameScore(Frame frame, IEnumerable<int> nextPins)
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