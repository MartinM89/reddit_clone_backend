using System.ComponentModel.DataAnnotations;

public class Comment
{
    [Key]
    public int Id { get; set; } = default!;

    [Required]
    public string Content { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public DateTime Date { get; set; } = default!;

    [Required]
    public int Likes { get; set; } = default!;

    [Required]
    public int Dislikes { get; set; } = default!;

    public Post Post { get; set; } = default!;
    public User User { get; set; } = default!;

    public Comment(string content, DateTime date, int likes, int dislikes)
    {
        Content = content;
        Date = date;
        Likes = likes;
        Dislikes = dislikes;
    }

    // Empty constructor for EF
    public Comment() { }
}
