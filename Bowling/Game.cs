namespace Bowling;

internal static class Game
{
    public static void AddRoll(Frame[] frames, int pins)
    {
        var frame = FindFrameForRoll(frames);
        AddPins(frame, pins);
        CalculateScores(frames);
    }

    private static void CalculateScores(Frame[] frames)
    {
        var framesAndNextPins = GetFramesAndNextPins(frames);
        foreach (var (frame, pins1, pins2) in framesAndNextPins) CalculateFrameScore(frame, pins1, pins2);
        AddCumulativeScore(frames);
    }

    private static void AddCumulativeScore(Frame[] frames)
    {
        var cum = 0;
        foreach (var frame in frames)
        {
            cum += frame.Score ?? 0;
            frame.TotalScore = cum;
        }
    }

    private static void CalculateFrameScore(Frame frame, int? pins1, int? pins2)
    {
        if (frame.Number == 10)
        {
            frame.Score = frame.Pins.Sum();
        }
        else if (IsStrike(frame))
        {
            frame.Score = frame.Pins.Sum() + pins1 + pins2;
        }
        else if (IsSpare(frame))
        {
            frame.Score = frame.Pins.Sum() + pins1;
        }
        else
        {
            frame.Score = frame.Pins.Sum();
        }
    }

    private static bool IsSpare(Frame frame)
    {
        return frame.Pins.Count == 2 && frame.Pins.Sum() == 10;
    }

    private static bool IsStrike(Frame frame)
    {
        return frame.Pins.Count == 1 && frame.Pins.Sum() == 10;
    }

    private static IEnumerable<(Frame, int?, int?)> GetFramesAndNextPins(Frame[] frames)
    {
        for (var i = 0; i < 10; i++)
        {
            var frame = frames[i];
            var pins = frames.Where(f => f.Number > frame.Number).SelectMany(f => f.Pins).Cast<int?>()
                .Concat(Enumerable.Repeat((int?) null, 2)).Take(2).ToArray();

            yield return (frame, pins[0], pins[1]);
        }
    }


    private static void AddPins(Frame frame, int pins)
    {
        frame.Pins.Add(pins);
    }

    private static Frame FindFrameForRoll(Frame[] frames)
    {
        return frames.SkipWhile(IsClosed).First();
    }

    private static bool IsClosed(Frame frame)
    {
        return frame.Pins.Sum() == 10 && frame.Number < 10 || frame.Number < 10 && frame.Pins.Count == 2 ||
               frame.Number == 10 && frame.Pins.Count == 2 && frame.Pins.Sum() < 10 ||
               frame.Number == 10 && frame.Pins.Count == 3;
    }

    public static void Display(Frame[] frames)
    {
        foreach (var frame in frames)
            Console.WriteLine(
                $"{frame.Number:00}\t{string.Join("|", frame.Pins.Select(p => p.ToString("00"))).PadRight(9)}\t Score: {frame.Score:00}\tTotal: {frame.TotalScore:00}");
    }
}