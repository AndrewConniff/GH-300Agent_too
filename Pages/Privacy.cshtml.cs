using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GH_300Agent_too.Pages;

public class PrivacyModel : PageModel
{
    public List<Employee>? Employees { get; set; }

    public void OnGet()
    {
        var file = Path.Combine(Directory.GetCurrentDirectory(), "sampledata.json");
        if (System.IO.File.Exists(file))
        {
            var json = System.IO.File.ReadAllText(file);
            Employees = JsonSerializer.Deserialize<List<Employee>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        else
        {
            Employees = new List<Employee>();
        }
    }

    public class Employee
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HiringDate { get; set; }
        public string? Department { get; set; }
        [JsonPropertyName("Job Title")]
        public string? JobTitle { get; set; }
    }
}

