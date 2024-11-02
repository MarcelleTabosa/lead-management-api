namespace LeadManagement.Domain.Entities;

public abstract class Entity
{
    public int Id { get; set; }
    public DateTime CreatedIn { get; set; }

}
