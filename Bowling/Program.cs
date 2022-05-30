using Bowling;
using MoreLinq;

var rolls = ArgumentParser.ParseRolls(args);
var frames = GameInitializer.CreateFrames();
rolls.ForEach(r => Game.AddRoll(frames, r));

DisplayAdapter.DisplayFrames(frames);