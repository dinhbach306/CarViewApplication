namespace Domain.Model.Entity.Base;

public class BaseEntity
{
    public int Id { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 
       
    public DateTime ModifiedDate { get;  set; } = DateTime.UtcNow;

    public int Version { get; set; }
    
    public bool IsDeleted { get; set; }
}