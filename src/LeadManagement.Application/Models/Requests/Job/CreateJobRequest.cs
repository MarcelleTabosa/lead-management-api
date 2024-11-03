namespace LeadManagement.Application.Models.Requests.Job;

public class CreateJobRequest
{
    public string Description { get; set; }
    public string Suburb { get; set; }
    public double Price { get; set; }
    public int JobCategoryId { get; set; }
    public int LeadId { get; set; }
}
