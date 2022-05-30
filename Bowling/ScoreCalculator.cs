namespace Bowling;

public static class ScoreCalculator
{
    public static void CalculateScores(Frame[] frames)
    {
        var framesAndNextRolls = GetFramesAndNextRolls(frames);
        AddFramesScores(framesAndNextRolls);
        AddCumulativeScore(frames);
    }

    private static void AddFramesScores(IEnumerable<(Frame, IEnumerable<int>)> framesAndNextRolls)
    {
        foreach (var (frame, nextRolls) in framesAndNextRolls)
        {
            frame.Score = CalculateFrameScore(frame, nextRolls);
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

    private static IEnumerable<(Frame, IEnumerable<int>)> GetFramesAndNextRolls(Frame[] frames)
    {
        var query = from frame in frames
            let nextFrames = frames.Where(f => f.Number > frame.Number)
            let nextRolls = nextFrames.SelectMany(f => f.Rolls)
            select (frame, nextRolls);
        return query;
    }

    private static int CalculateFrameScore(Frame frame, IEnumerable<int> nextRolls)
    {
        var frameSum = frame.Rolls.Sum();
        var relevantNumberNextRolls = frame switch
        {
            _ when frame.IsLast() => 0,
            _ when frame.IsStrike() => 2,
            _ when frame.IsSpare() => 1,
            _ => 0
        };

        return frameSum + nextRolls.Take(relevantNumberNextRolls).Sum();
    }
}