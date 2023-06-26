namespace Domain2.Model.Entity;

public class CarDetailEquipment
{
    public int CarDetailId { get; set; }
    public int CarEquipmentId { get; set; }
    public CarEquipment? CarEquipment { get; set; }
    public CarDetail? CarDetail { get; set; }
}