using MoreLinq.Extensions;

namespace Bowling;

internal static class Game
{
    public static void AddRolls(IEnumerable<int> rolls, Frame[] frames)
    {
        rolls.ForEach(r => AddRoll(frames, r));
    }

    private static void AddRoll(Frame[] frames, int roll)
    {
        FindFrameForRoll(frames).AddRoll(roll);
        ScoreCalculator.CalculateScores(frames);
    }

    private static Frame FindFrameForRoll(IEnumerable<Frame> frames)
    {
        return frames.SkipWhile(FrameExtensions.IsClosed).First();
    }
}