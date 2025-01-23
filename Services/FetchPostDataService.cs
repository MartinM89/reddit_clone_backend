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

    public static List<Post> GetAllPosts()
    {
        try
        {
            using var db = new AppContext();
            var posts = db.Posts.ToList();

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

    public static void AddPost(string title)
    {
        Post post =
            new()
            {
                Title = title,
                Likes = 10,
                Dislikes = 5,
                Date = DateTime.Now,
                User = new User("fresh_baker"),
                SubReddit = new SubReddit("r/programming"),
                Comments =
                [
                    new()
                    {
                        Content = "This is a comment",
                        Date = DateTime.Now,
                        Likes = 5,
                        Dislikes = 1,
                        User = new User("fresh_baker"),
                    },
                    new()
                    {
                        Content = "This is another comment",
                        Date = DateTime.Now,
                        Likes = 3,
                        Dislikes = 2,
                        User = new User("fresh_baker"),
                    },
                ],
            };

        try
        {
            using var db = new AppContext();

            db.Posts.Add(post);
            db.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Could not delete post");
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
            throw new Exception("Could not delete post");
        }
    }
}
