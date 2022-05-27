namespace Bowling;

internal class Frame
{
    public IList<int> Pins { get; set; } = new List<int>();
    public int? Score { get; set; }
    public int TotalScore { get; set; }
    public int Number { get; set; }
}