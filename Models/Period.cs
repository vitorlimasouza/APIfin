namespace APIfin.Models;

public class Period
{
    public int Id { get; set; }
    public int Month {get; set;}
    public int Year {get; set;}
    public List<Movement> Movements {get; set;} = new List<Movement>();
}