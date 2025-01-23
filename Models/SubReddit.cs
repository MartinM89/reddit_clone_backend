using System.ComponentModel.DataAnnotations;

public class SubReddit
{
    [Key]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<User> Users { get; set; } = new List<User>();

    public SubReddit(string name)
    {
        Name = name;
    }

    // Empty constructor for EF
    public SubReddit() { }
}
