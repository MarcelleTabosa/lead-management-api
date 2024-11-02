namespace LeadManagement.Domain.Entities;

public class Lead : Entity
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<Job> Jobs { get; set; }
}
