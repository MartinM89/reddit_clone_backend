using System.ComponentModel.DataAnnotations;

public class Post
{
    [Key]
    public int Id { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = default!;

    [Required]
    public string Content { get; set; } = default!;

    [Required]
    public int Likes { get; set; } = default!;

    [Required]
    public int Dislikes { get; set; } = default!;

    public bool IsLiked { get; set; } = default!;

    public bool IsDisliked { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public DateTime Date { get; set; } = default!;

    public User User { get; set; } = default!;
    public SubReddit SubReddit { get; set; } = default!;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public Post(string title, DateTime date, SubReddit subReddit, string content, User user)
    {
        Title = title;
        Date = date;
        SubReddit = subReddit;
        Content = content;
        User = user;
    }

    // Empty constructor for EF
    public Post() { }
}
