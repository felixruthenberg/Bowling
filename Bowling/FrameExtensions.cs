namespace Bowling;

public static class FrameExtensions
{
    public static bool IsLast(this Frame frame)
    {
        return frame.Number == 10;
    }

    public static bool IsSpare(this Frame frame)
    {
        return frame.Pins.Count == 2 && frame.Pins.Sum() == 10;
    }

    public static bool IsStrike(this Frame frame)
    {
        return frame.Pins.Count == 1 && frame.Pins.Sum() == 10;
    }

    public static bool IsClosed(this Frame frame)
    {
        // TODO: Use frame extensions
        return frame.Pins.Sum() == 10 && frame.Number < 10 || frame.Number < 10 && frame.Pins.Count == 2 ||
               frame.Number == 10 && frame.Pins.Count == 2 && frame.Pins.Sum() < 10 ||
               frame.Number == 10 && frame.Pins.Count == 3;
    }
}