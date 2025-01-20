using System.ComponentModel.DataAnnotations;

public class Post
{
    [Key]
    public int Id { get; set; } = default!;

    [Required]
    public int Rating { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Submitted { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string SubReddit { get; set; } = default!;

    [Required]
    public int CommentAmount { get; set; } = default!;

    // public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public Post(
        int id,
        int rating,
        string title,
        string submitted,
        string username,
        string subReddit,
        int commentAmount
    )
    {
        Id = id;
        Rating = rating;
        Title = title;
        Submitted = submitted;
        Username = username;
        SubReddit = subReddit;
        CommentAmount = commentAmount;
    }

    // Empty constructor for EF
    public Post() { }
}
