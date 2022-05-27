using FluentAssertions;
using FluentAssertions.Execution;

namespace Bowling.Tests;

public class GameInitializerTests
{
    [Test]
    public void CreateFrameShouldInitializeFrames()
    {
        var actual = GameInitializer.CreateFrames();

        using var _ = new AssertionScope();
        actual.Should().HaveCount(10);
        actual[0].Number.Should().Be(1);
        actual[^1].Number.Should().Be(10);
        actual.Should().BeInAscendingOrder(f => f.Number);
    }
}