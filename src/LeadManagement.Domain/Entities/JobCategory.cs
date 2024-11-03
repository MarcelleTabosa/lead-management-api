using System.Text.Json.Serialization;

namespace LeadManagement.Domain.Entities;

public class JobCategory : Entity
{
    public string Category { get; set; }
    [JsonIgnore]
    public List<Job> Jobs { get; set; }
}
