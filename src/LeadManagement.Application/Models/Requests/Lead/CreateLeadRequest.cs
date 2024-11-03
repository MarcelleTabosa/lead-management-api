namespace LeadManagement.Application.Models.Requests.Lead;

public class CreateLeadRequest
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
