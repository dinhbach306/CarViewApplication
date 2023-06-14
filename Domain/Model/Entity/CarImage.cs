using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarImage : BaseEntity
{
    public byte[]? ImageCar1 { get; set; }
    public byte[]? ImageCar2 { get; set; }
    public byte[]? ImageCar3 { get; set; }
    public byte[]? ImageCar4 { get; set; }
    public byte[]? ImageCar5 { get; set; }
    public CarDetail? CarDetail { get; set; }
    public int CarDetailId { get; set; }
}