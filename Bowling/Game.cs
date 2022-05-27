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

    private static void AddFramesScores(IEnumerable<(Frame, IEnumerable<int?>)> framesAndNextPins)
    {
        // TODO: R# für Klammern auch bei einzeiliger foreach
        foreach (var (frame, nextPins) in framesAndNextPins) frame.Score = CalculateFrameScore(frame, nextPins);
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

    private static int? CalculateFrameScore(Frame frame, IEnumerable<int?> nextPins)
    {
        var frameSum = frame.Pins.Sum();
        var relevantNumberNextFrames = frame switch
        {
            _ when frame.IsLast() => 0,
            _ when frame.IsStrike() => 2,
            _ when frame.IsSpare() => 1,
            _ => 0
        };

        return frameSum + nextPins.Take(relevantNumberNextFrames).Sum();
    }

    private static Frame FindFrameForRoll(Frame[] frames)
    {
        return frames.SkipWhile(FrameExtensions.IsClosed).First();
    }



    private static IEnumerable<(Frame, IEnumerable<int?>)> GetFramesAndNextPins(Frame[] frames)
    {
        foreach (var frame in frames)
        {
            var pins = frames.Where(f => f.Number > frame.Number)
                .SelectMany(f => f.Pins).Cast<int?>()
                .Concat(Enumerable.Repeat((int?) null, 2)).Take(2).ToArray();

            yield return (frame, pins);
        }
    }


    private static void AddPins(Frame frame, int pins)
    {
        frame.Pins.Add(pins);
    }


    // TODO: DisplayAdapter
    public static void Display(Frame[] frames)
    {
        foreach (var frame in frames)
            Console.WriteLine(
                $"{frame.Number:00}\t{string.Join("|", frame.Pins.Select(p => p.ToString("00"))).PadRight(9)}\t Score: {frame.Score:00}\tTotal: {frame.TotalScore:00}");
    }
}