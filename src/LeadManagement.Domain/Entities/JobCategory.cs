namespace LeadManagement.Domain.Entities;

public class JobCategory : Entity
{
    public string Category { get; set; }
    public List<Job> Jobs { get; set; }
}
