using FluentAssertions;
using MoreLinq.Extensions;

namespace Bowling.Tests;

public class FrameExtensionsTests
{
    [TestCase(9, false)]
    [TestCase(10, true)]
    [TestCase(11, false)]
    public void IsLast(int frameNumber, bool expected)
    {
        var frame = new Frame { Number = frameNumber };
        var actual = frame.IsLast();
        actual.Should().Be(expected);
    }

    [TestCase(new[] { 1, 3 }, false)]
    [TestCase(new[] { 7, 2 }, false)]
    [TestCase(new[] { 7, 3 }, true)]
    [TestCase(new[] { 4, 6 }, true)]
    [TestCase(new[] { 0, 10 }, true)]
    [TestCase(new[] { 4 }, false)]
    [TestCase(new[] { 10 }, false)]
    [TestCase(new int[] { }, false)]
    [TestCase(new[] { 2, 5, 3 }, false)]
    public void IsSpare(int[] rolls, bool expected)
    {
        var frame = new Frame();
        rolls.ForEach(frame.Rolls.Add);
        var actual = frame.IsSpare();
        actual.Should().Be(expected);
    }

    [TestCase(1, new int[] { }, false)]
    [TestCase(1, new[] { 2 }, false)]
    [TestCase(1, new[] { 2, 5 }, true)]
    [TestCase(1, new[] { 2, 8 }, true)]
    [TestCase(1, new[] { 10 }, true)]
    [TestCase(10, new[] { 10 }, false)]
    [TestCase(10, new[] { 10, 10 }, false)]
    [TestCase(10, new[] { 10, 10, 10 }, true)]
    [TestCase(10, new[] { 4, 6 }, false)]
    [TestCase(10, new[] { 4, 5 }, true)]
    [TestCase(10, new[] { 4, 6, 7 }, true)]
    public void IsClosed(int frameNumber, int[] rolls, bool expected)
    {
        var frame = new Frame { Number = frameNumber };
        rolls.ForEach(frame.Rolls.Add);
        var actual = frame.IsClosed();
        actual.Should().Be(expected);
    }

    [TestCase(new[] { 4 }, false)]
    [TestCase(new[] { 4, 6 }, false)]
    [TestCase(new[] { 0, 10 }, false)]
    [TestCase(new[] { 10 }, true)]
    public void IsStrike(int[] rolls, bool expected)
    {
        var frame = new Frame();
        rolls.ForEach(frame.Rolls.Add);
        var actual = frame.IsStrike();
        actual.Should().Be(expected);
    }
}