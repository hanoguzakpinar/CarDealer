namespace CarDealer.Application.DTOs.Cars;

public record CarDto
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
}