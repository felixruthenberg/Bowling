using Bowling;

// TODO: Immutability?!

var rolls = ParsePins(args); // TODO: roll in pin umbenennen
var frames = CreateFrames();
foreach (var pin in rolls)
{
    Game.AddRoll(frames, pin);
    DisplayAdapter.DisplayFrames(frames);
    DisplayAdapter.DisplaySeparator();
}

// TODO: ArgumentParser
IEnumerable<int> ParsePins(IEnumerable<string> args)
{
    return args.Select(int.Parse);
}

// TODO: GameInitializer
Frame[] CreateFrames()
{
    return Enumerable.Range(1, 10).Select(n => new Frame {Number = n}).ToArray();
}