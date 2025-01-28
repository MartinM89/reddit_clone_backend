public class PostAndCommentDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public DateTime Date { get; set; }
    public string SubRedditName { get; set; } = default!;
    public string Content { get; set; } = default!;
    public int Likes { get; set; } = default!;
    public int Dislikes { get; set; } = default!;
    public bool IsLiked { get; set; }
    public bool IsDisliked { get; set; }
    public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
}

public class CommentDto
{
    public string Content { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public DateTime Date { get; set; }
    public int Likes { get; set; } = default!;
    public int Dislikes { get; set; } = default!;
    public bool IsLiked { get; set; }
    public bool IsDisliked { get; set; }
}
