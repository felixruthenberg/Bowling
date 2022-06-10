namespace Bowling;

public static class Interactors
{
    public static Frame[] PlayGame(string[] args)
    {
        var rolls = ArgumentParser.ParseRolls(args);
        var frames = GameInitializer.CreateFrames();
        Game.AddRolls(frames, rolls);
        return frames;
    }
}