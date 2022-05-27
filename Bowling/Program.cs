using Bowling;

var rolls = ParsePins(args);
var frames = CreateFrames();
foreach (var pin in rolls) Game.AddRoll(frames, pin);
Game.Display(frames);


IEnumerable<int> ParsePins(IEnumerable<string> args)
{
    return args.Select(int.Parse);
}

Frame[] CreateFrames()
{
    return Enumerable.Range(1, 10).Select(n => new Frame {Number = n}).ToArray();
}