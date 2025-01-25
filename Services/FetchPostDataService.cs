using Microsoft.EntityFrameworkCore;

public class FetchPostService
{
    public static Post GetPost(int id)
    {
        try
        {
            using var db = new AppContext();
            var post = db.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                throw new Exception("Post not found");
            }

            return post;
        }
        catch (Exception)
        {
            throw new Exception("Could not fetch post");
        }
    }

    public static List<PostDto> GetAllPosts()
    {
        try
        {
            using var db = new AppContext();
            var posts = db
                .Posts.Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.SubReddit)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Likes = p.Likes,
                    Dislikes = p.Dislikes,
                    Date = p.Date,
                    Username = p.User.Username,
                    SubRedditName = p.SubReddit.Name,
                    CommentCount = p.Comments.Count,
                    Content = p.Content,
                })
                .ToList();

            if (posts == null || posts.Count == 0)
            {
                throw new Exception("Posts not found");
            }

            return posts;
        }
        catch (Exception)
        {
            throw new Exception("Could not fetch posts");
        }
    }

    public static void AddPost(string title, string userName, string subRedditName, string content)
    {
        Post post =
            new()
            {
                Title = title,
                Likes = 0,
                Dislikes = 0,
                Date = DateTime.Now,
                User = new(userName),
                SubReddit = new("r/" + subRedditName),
                Content = content,
            };

        try
        {
            using var db = new AppContext();

            db.Posts.Add(post);
            db.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Could not add post");
        }
    }

    public static void DeletePost(int id)
    {
        try
        {
            using var db = new AppContext();

            var post = db.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                throw new Exception("Post not found");
            }

            db.Posts.Remove(post);
        }
        catch (Exception)
        {
            throw new Exception("Could not delete post");
        }
    }

    // var post = new Post { Id = id };
    // db.Posts.Attach(post);
    // db.Posts.Remove(post);

    public static void UpdatePost(int id, string title, int likes, int dislikes)
    {
        Post post = new Post
        {
            Id = id,
            Likes = likes,
            Dislikes = dislikes,
            Title = title,
            Date = DateTime.Now,
            User = new("fresh_baker"),
            SubReddit = new("r/programming"),
        };

        try
        {
            using var db = new AppContext();

            db.Posts.Update(post);
            db.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Could not update post");
        }
    }

    public static List<SubReddit> GetSubreddits()
    {
        try
        {
            using var db = new AppContext();
            var subreddits = db.SubReddits.ToList();

            if (subreddits == null || subreddits.Count == 0)
            {
                throw new Exception("Subreddits not found");
            }

            return subreddits;
        }
        catch (Exception)
        {
            throw new Exception("Could not fetch subreddits");
        }
    }
}
