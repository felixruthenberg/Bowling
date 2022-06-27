using FluentAssertions;
using MoreLinq.Extensions;

namespace Bowling.Tests;

public class ScoreCalculatorTests
{
    [TestCase(new[] {1, 3}, new int[] { }, new int[] { }, 4, 4)]
    [TestCase(new[] {1, 3}, new[] {10}, new int[] { }, 4, 14)]
    [TestCase(new[] {10}, new[] {10}, new int[] { }, 20, 30)]
    [TestCase(new[] {10}, new[] {10}, new[] {10}, 30, 50)]
    [TestCase(new[] {0}, new int[] { }, new int[] { }, 0, 0)]
    [TestCase(new[] {0, 10}, new[] {1, 2}, new int[] { }, 11, 14)]
    [TestCase(new[] {10}, new[] {0, 8}, new int[] { }, 18, 26)]
    public void CalculateFrameScore(int[] firstFrameRolls,
        int[] secondFrameRolls,
        int[] thirdFrameRolls,
        int expectedFirstFrameScore, int expectedSecondFrameScore)
    {
        var firstFrame = new Frame {Number = 1};
        firstFrameRolls.ForEach(firstFrame.Rolls.Add);

        var secondFrame = new Frame {Number = 2};
        secondFrameRolls.ForEach(secondFrame.Rolls.Add);

        var thirdFrame = new Frame {Number = 3};
        thirdFrameRolls.ForEach(thirdFrame.Rolls.Add);

        ScoreCalculator.CalculateScores(new[] {firstFrame, secondFrame, thirdFrame});

        firstFrame.TotalScore.Should().Be(expectedFirstFrameScore);
        secondFrame.TotalScore.Should().Be(expectedSecondFrameScore);
    }
}