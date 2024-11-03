namespace LeadManagement.Application.Models.Requests.Lead;

public class UpdateLeadRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
