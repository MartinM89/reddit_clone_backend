public class FetchData
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
}
