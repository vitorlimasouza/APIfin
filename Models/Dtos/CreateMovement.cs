namespace APIfin.Models.Dtos;

public class CreateMovementDto
{
    public string Name { get; set; }
    public float Value { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
}