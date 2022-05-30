using Bowling;
using MoreLinq;

// TODO: Immutability?!

var rolls = ArgumentParser.ParseRolls(args);
var frames = GameInitializer.CreateFrames();
rolls.ForEach(r => Game.AddRoll(frames, r));

DisplayAdapter.DisplayFrames(frames);