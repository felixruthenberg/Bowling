﻿namespace Bowling;

public class Frame
{
    public IList<int> Pins { get; } = new List<int>();
    public int? Score { get; set; }
    public int TotalScore { get; set; }
    public int Number { get; init; }
}