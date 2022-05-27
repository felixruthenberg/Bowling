namespace Bowling;

public static class DisplayAdapter
{
    public static void DisplayFrames(Frame[] frames)
    {
        foreach (var frame in frames)
            Console.WriteLine(
                $"{frame.Number:00}\t{string.Join("|", frame.Pins.Select(p => p.ToString("00"))).PadRight(9)}\t Score: {frame.Score:00}\tTotal: {frame.TotalScore:000}");
    }

    public static void DisplaySeparator()
    {
        var line = string.Empty.PadRight(50, '-');
        Console.WriteLine(line);
    }
}