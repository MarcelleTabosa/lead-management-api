namespace LeadManagement.Application.Models.Requests.Job;

public class UpdateJobRequest
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Suburb { get; set; }
    public double Price { get; set; }
    public bool Accepted { get; set; }
    public int JobCategoryId { get; set; }
    public int LeadId { get; set; }
}