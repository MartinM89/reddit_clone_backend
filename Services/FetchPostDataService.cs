using Microsoft.EntityFrameworkCore;

public class FetchPostService
{
    public static PostAndCommentDto GetPost(int id)
    {
        try
        {
            using var db = new AppContext();
            var post = db
                .Posts.Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(p => p.User)
                .Include(p => p.SubReddit)
                .Select(p => new PostAndCommentDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    UserName = p.User.Username,
                    Date = p.Date,
                    SubRedditName = p.SubReddit.Name,
                    Content = p.Content,
                    Likes = p.Likes,
                    Dislikes = p.Dislikes,
                    IsLiked = p.IsLiked,
                    IsDisliked = p.IsDisliked,
                    Comments = p
                        .Comments.Select(c => new CommentDto
                        {
                            UserName = c.User.Username,
                            Content = c.Content,
                            Date = c.Date,
                            Likes = c.Likes,
                            Dislikes = c.Dislikes,
                            IsLiked = c.IsLiked,
                            IsDisliked = c.IsDisliked,
                        })
                        .ToList(),
                })
                .FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                throw new Exception("Post not found");
            }

            return post;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching post: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
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
                    IsLiked = p.IsLiked,
                    IsDisliked = p.IsDisliked,
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
        try
        {
            using AppContext db = new();

            User? user = db.Users.FirstOrDefault(u => u.Username == userName);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // db.Attach(user);

            SubReddit? subReddit = db.SubReddits.FirstOrDefault(sr => sr.Name == subRedditName);

            if (subReddit == null)
            {
                throw new Exception("Subreddit not found");
            }

            // db.Attach(subReddit);

            Post post =
                new()
                {
                    Title = title,
                    Likes = 0,
                    Dislikes = 0,
                    Date = DateTime.UtcNow,
                    User = user,
                    SubReddit = subReddit,
                    Content = content,
                };

            db.Posts.Add(post);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                throw new Exception("Could not add post", ex.InnerException);
            }
            throw new Exception("Could not add post", ex);
        }
    }

    // Not used in the website
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

    // Not used in the website
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

    public static List<User> GetUsers()
    {
        try
        {
            using var db = new AppContext();
            var users = db.Users.ToList();

            if (users == null || users.Count == 0)
            {
                throw new Exception("Users not found");
            }

            return users;
        }
        catch (Exception)
        {
            throw new Exception("Could not fetch users");
        }
    }

    public static void AddComment(string userName, string content, string postId)
    {
        try
        {
            using AppContext db = new();

            User? user = db.Users.FirstOrDefault(u => u.Username == userName);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            db.Attach(user);

            Post? post = db.Posts.FirstOrDefault(p => p.Id == int.Parse(postId));

            if (post == null)
            {
                throw new Exception("Post not found");
            }

            Comment comment = new Comment
            {
                Content = content,
                Date = DateTime.UtcNow,
                Likes = 0,
                Dislikes = 0,
                User = user,
                Post = post,
            };

            db.Comments.Add(comment);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                throw new Exception("Could not add post", ex.InnerException);
            }
            throw new Exception("Could not add post", ex);
        }
    }

    public static void LikePost(PostOrCommentIdDto postId)
    {
        try
        {
            using AppContext db = new();

            Post? post = db.Posts.FirstOrDefault(p => p.Id == postId.PostOrCommentId);

            if (post == null)
            {
                throw new Exception("Post not found");
            }

            if (post.IsLiked == false)
            {
                post.Likes += 1;
                post.IsLiked = true;
                post.IsDisliked = false;
            }
            else
            {
                post.Likes -= 1;
                post.IsLiked = false;
            }

            db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not like post", ex);
        }
    }

    public static void DislikePost(PostOrCommentIdDto postId)
    {
        try
        {
            using AppContext db = new();

            Post? post = db.Posts.FirstOrDefault(p => p.Id == postId.PostOrCommentId);

            if (post == null)
            {
                throw new Exception("Post not found");
            }

            if (post.IsDisliked == false)
            {
                post.Likes -= 1;
                post.IsLiked = false;
                post.IsDisliked = true;
            }
            else
            {
                post.Likes += 1;
                post.IsDisliked = false;
            }

            db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not dislike post", ex);
        }
    }

    public static void LikeComment(PostOrCommentIdDto commentId)
    {
        try
        {
            using AppContext db = new();

            Comment? comment = db.Comments.FirstOrDefault(p => p.Id == commentId.PostOrCommentId);

            if (comment == null)
            {
                throw new Exception("Post not found");
            }

            if (comment.IsLiked == false)
            {
                comment.Likes += 1;
                comment.IsLiked = true;
                comment.IsDisliked = false;
            }
            else
            {
                comment.Likes -= 1;
                comment.IsLiked = false;
            }

            db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not like post", ex);
        }
    }

    public static void DislikeComment(PostOrCommentIdDto commentId)
    {
        try
        {
            using AppContext db = new();

            Comment? comment = db.Comments.FirstOrDefault(p => p.Id == commentId.PostOrCommentId);

            if (comment == null)
            {
                throw new Exception("Post not found");
            }

            if (comment.IsDisliked == false)
            {
                comment.Likes -= 1;
                comment.IsLiked = false;
                comment.IsDisliked = true;
            }
            else
            {
                comment.Likes += 1;
                comment.IsDisliked = false;
            }

            db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not dislike post", ex);
        }
    }
}
