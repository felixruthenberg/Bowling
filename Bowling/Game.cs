namespace Bowling;

internal static class Game
{
    // TODO: Calculate / Add Score schärfen
    // TODO: Pins / roll schärfen 
    public static void AddRoll(Frame[] frames, int pins)
    {
        var frame = FindFrameForRoll(frames);
        AddPins(frame, pins);
        CalculateScores(frames);
    }

    private static void CalculateScores(Frame[] frames)
    {
        var framesAndNextPins = GetFramesAndNextPins(frames);
        AddFramesScores(framesAndNextPins);
        AddCumulativeScore(frames);
    }

    private static void AddFramesScores(IEnumerable<(Frame, IEnumerable<int>)> framesAndNextPins)
    {
        foreach (var (frame, nextPins) in framesAndNextPins)
        {
            frame.Score = ScoreCalculator.CalculateFrameScore(frame, nextPins);
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

    // TODO: ScoreCalculator

    private static Frame FindFrameForRoll(IEnumerable<Frame> frames)
    {
        return frames.SkipWhile(FrameExtensions.IsClosed).First();
    }


    private static IEnumerable<(Frame, IEnumerable<int>)> GetFramesAndNextPins(Frame[] frames)
    {
        var query = from frame in frames
            let nextFrames = frames.Where(f => f.Number > frame.Number)
            let nextRolls = nextFrames.SelectMany(f => f.Rolls)
            select (frame, nextRolls);
        return query;
    }


    private static void AddPins(Frame frame, int pins)
    {
        frame.Rolls.Add(pins);
    }
}