using FluentAssertions;
using MoreLinq.Extensions;

namespace Bowling.Tests;

public class FrameExtensionsTests
{
    [TestCase(9, false)]
    [TestCase(10, true)]
    [TestCase(11,false)]
    public void IsLast(int frameNumber, bool expected)
    {
        var frame = new Frame{Number = frameNumber};
        var actual = frame.IsLast();
        actual.Should().Be(expected);
    }

    [TestCase(new[]{1, 3}, false)]
    [TestCase(new[]{7, 2}, false)]
    [TestCase(new[]{7, 3}, true)]
    [TestCase(new[]{4, 6}, true)]
    [TestCase(new[]{4}, false)]
    [TestCase(new[]{10}, false)]
    [TestCase(new int[]{}, false)]
    [TestCase(new[]{2,5,3}, false)]
    public void IsSpare(int[] pins, bool expected)
    {
        var frame = new Frame();
        pins.ForEach(frame.Pins.Add);
        var actual = frame.IsSpare();
        actual.Should().Be(expected);
    }
}