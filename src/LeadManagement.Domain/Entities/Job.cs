namespace LeadManagement.Domain.Entities;

public class Job : Entity
{
    public string Description { get; set; }
    public string Suburb { get; set; }
    public double Price { get; set; }
    public StatusJob Accepted { get; set; }
    public int JobCategoryId { get; set; }
    public JobCategory JobCategory { get; set; }
    public int LeadId { get; set; }
    public Lead Lead { get; set; }
}

public enum StatusJob
{
    NotAccepted = 0,
    Accepted = 1,
    Declined = 2
}