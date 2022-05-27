using FluentAssertions;

namespace Bowling.Tests;

public class FrameExtensionsTests
{
    [TestCase(9, false)]
    [TestCase(10, true)]
    [TestCase(11,false)]
    public void IsLastShouldOnlyBeTrueForFrameNumber10(int frameNumber, bool expected)
    {
        var frame = new Frame{Number = frameNumber};
        var actual = frame.IsLast();
        actual.Should().Be(expected);
    }
}