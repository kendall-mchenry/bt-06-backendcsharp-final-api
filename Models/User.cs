
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace final_api.Models;

public class User 
{
    [JsonIgnore]
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    public string? Username { get; set; }

    // public string Email { get; set; }

    [Required]
    public string? Password { get; set; }

    // Delete this? & update DbContext
    public string? City { get; set; }

    public string? State { get; set; }

    // OPTIONAL -- want to see if I can connect this to the individual posts (later)
    public string? PhotoUrl { get; set; }

    public DateTime CreatedDate { get; set; }

    public List<Post> Posts { get; set; }


}