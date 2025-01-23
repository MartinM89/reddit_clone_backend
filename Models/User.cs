using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = default!;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<SubReddit> SubReddits { get; set; } = new List<SubReddit>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public User(string username)
    {
        Username = username;
    }

    // Empty constructor for EF
    public User() { }
}
