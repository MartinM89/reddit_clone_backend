public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public DateTime Date { get; set; }
    public string Username { get; set; } = default!;
    public string SubRedditName { get; set; } = default!;
    public int CommentCount { get; set; }
    public string Content { get; set; } = default!;
    public bool IsLiked { get; set; }
    public bool IsDisliked { get; set; }
}
