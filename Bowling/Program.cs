using Bowling;

// TODO: Immutability?!

var pins = ArgumentParser.ParseRolls(args);
var frames = GameInitializer.CreateFrames();


foreach (var pin in pins)
{
    Game.AddRoll(frames, pin);
    DisplayAdapter.DisplayFrames(frames);
    DisplayAdapter.DisplaySeparator();
}