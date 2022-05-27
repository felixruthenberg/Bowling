namespace Bowling;

public static class GameInitializer
{
    public static Frame[] CreateFrames()
    {
        return Enumerable.Range(1, 10).Select(n => new Frame { Number = n }).ToArray();
    }
}