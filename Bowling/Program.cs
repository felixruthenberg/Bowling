using Bowling;

var rolls = ArgumentParser.ParseRolls(args);
var frames = GameInitializer.CreateFrames();
Game.AddRolls(rolls, frames);

DisplayAdapter.DisplayFrames(frames);