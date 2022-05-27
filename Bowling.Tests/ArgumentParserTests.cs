using FluentAssertions;

namespace Bowling.Tests;

public class ArgumentParserTests
{
    [Test]
    public void ParseRollsShouldReturnNumbers()
    {
        var testData = new[] { "1", "3", "10", "3", "0", "1" };
        var actual = ArgumentParser.ParseRolls(testData);
        var expected = new[] { 1, 3, 10, 3, 0, 1 };
        actual.Should().BeEquivalentTo(expected);
    }
}