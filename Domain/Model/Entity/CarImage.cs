using Domain.Model.Entity.Base;

namespace Domain.Model.Entity;

public class CarImage : BaseEntity
{
    private byte[]? ImageCar1 { get; set; }
    private byte[]? ImageCar2 { get; set; }
    private byte[]? ImageCar3 { get; set; }
    private byte[]? ImageCar4 { get; set; }
    private byte[]? ImageCar5 { get; set; }
    private CarDetail? CarDetail { get; set; }
}