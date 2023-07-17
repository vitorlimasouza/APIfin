namespace APIfin.Models;

public class Movement
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Value { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public int IdPeriod { get; set; }
    public Period Period { get; set; } = null;
}