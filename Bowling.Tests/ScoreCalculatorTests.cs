using MoreLinq.Extensions;

namespace Bowling.Tests;

public class ScoreCalculatorTests
{
    [TestCase(new[] {1, 3}, new int[] { }, 4)]
    [TestCase(new[] {1, 3}, new[] {10}, 4)]
    [TestCase(new[] {10}, new[] {10}, 20)]
    [TestCase(new[] {10}, new[] {10, 10}, 30)]
    [TestCase(new[] {10}, new[] {10, 10, 10}, 30)]
    [TestCase(new[] {0}, new int[] { }, 0)]
    [TestCase(new[] {0, 10}, new[] {1, 2}, 11)]
    [TestCase(new[] {10}, new[] {0, 8}, 18)]
    public void CalculateFrameScore(int[] frameRolls, int[] nextRolls, int expected)
    {
        var frame = new Frame();
        frameRolls.ForEach(frame.Rolls.Add);
        // TODO: Tests
        Assert.Fail(" // TODO: Tests");
        // var actual = ScoreCalculator.CalculateScores(frame, nextRolls);

        // actual.Should().Be(expected);
    }
}