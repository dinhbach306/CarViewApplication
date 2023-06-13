﻿namespace Domain.Model.Entity.Base;

public class BaseEntity
{
    public int Id { get; set; }
       
    public DateTime CreatedDate { get; set; }
       
    public DateTime ModifiedDate { get;  set; }

    public int Version { get; set; }
    
    public string? CreatedBy { get;set; }
    
    public string? ModifiedBy { get;set; }
}