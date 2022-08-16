
namespace final_api.Models;

public class User 
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    // public string Email { get; set; }

    public string? Password { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    // OPTIONAL -- want to see if I can connect this to the individual posts (later)
    public string? PhotoUrl { get; set; }

    public DateTime CreatedDate { get; set; }


}