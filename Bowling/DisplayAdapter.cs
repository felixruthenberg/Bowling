namespace Bowling;

public static class DisplayAdapter
{
    public static void DisplayFrames(IEnumerable<Frame> frames)
    {
        foreach (var frame in frames)
        {
            var formattedFrameRolls = string.Join("|", frame.Rolls.Select(p => p.ToString("00")));
            Console.WriteLine(
                $"{frame.Number:00}\t{formattedFrameRolls,-9}\tScore: {frame.Score:00}\tTotal: {frame.TotalScore:000}");
        }
    }

    public static void DisplaySeparator()
    {
        var line = string.Empty.PadRight(50, '-');
        Console.WriteLine(line);
    }
}