using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PostgresPostController : ControllerBase
{
    [HttpGet]
    [Route("getpost")]
    public IActionResult GetPost(int id)
    {
        try
        {
            var post = FetchPostService.GetPost(id);
            return Ok(post);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't get post. {ex.Message}" });
        }
    }

    [HttpGet]
    [Route("getallposts")]
    public IActionResult GetAllPosts()
    {
        try
        {
            var posts = FetchPostService.GetAllPosts();
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't get all posts. {ex.Message}" });
        }
    }

    [HttpPost]
    [Route("addpost")]
    public IActionResult AddPost([FromBody] PostData postData)
    {
        try
        {
            FetchPostService.AddPost(
                postData.Title,
                postData.UserName,
                postData.SubRedditName,
                postData.Content
            );

            return Ok(new { Message = "Post added" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't add post. {ex.Message}" });
        }
    }

    [HttpDelete]
    [Route("deletepost")]
    public IActionResult DeletePost(int id)
    {
        try
        {
            FetchPostService.DeletePost(id);
            return Ok(new { Message = "Post deleted" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't delete post. {ex.Message}" });
        }
    }

    [HttpPut]
    [Route("updatepost")]
    public IActionResult UpdatePost(int id, string title, int likes, int dislikes)
    {
        try
        {
            FetchPostService.UpdatePost(id, title, likes, dislikes);
            return Ok(new { Message = "Post updated" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't update post. {ex.Message}" });
        }
    }

    [HttpGet]
    [Route("getsubreddits")]
    public IActionResult GetSubreddits()
    {
        try
        {
            var subreddits = FetchPostService.GetSubreddits();
            return Ok(subreddits);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't get subreddits. {ex.Message}" });
        }
    }

    [HttpGet]
    [Route("getusers")]
    public IActionResult GetUsers()
    {
        try
        {
            var users = FetchPostService.GetUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't get users. {ex.Message}" });
        }
    }

    [HttpPost]
    [Route("addcomment")]
    public IActionResult AddComment([FromBody] CommentDataDto commentData)
    {
        try
        {
            FetchPostService.AddComment(
                commentData.UserName,
                commentData.Content,
                commentData.PostId
            );

            return Ok(new { Message = "Comment added" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't add comment. {ex.Message}" });
        }
    }

    [HttpPost]
    [Route("likepost")]
    public IActionResult LikePost(PostOrCommentIdDto postId)
    {
        try
        {
            FetchPostService.LikePost(postId);

            return Ok(new { message = "Post liked" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't like post. {ex.Message}" });

            throw;
        }
    }

    [HttpPost]
    [Route("dislikepost")]
    public IActionResult DislikePost(PostOrCommentIdDto postId)
    {
        try
        {
            FetchPostService.DislikePost(postId);

            return Ok(new { message = "Post disliked" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't dislike post. {ex.Message}" });

            throw;
        }
    }

    [HttpPost]
    [Route("likecomment")]
    public IActionResult LikeComment(PostOrCommentIdDto commentId)
    {
        try
        {
            FetchPostService.LikeComment(commentId);

            return Ok(new { message = "Comment liked" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't like comment. {ex.Message}" });

            throw;
        }
    }

    [HttpPost]
    [Route("dislikecomment")]
    public IActionResult DislikeComment(PostOrCommentIdDto commentId)
    {
        try
        {
            FetchPostService.DislikeComment(commentId);

            return Ok(new { message = "Comment disliked" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Couldn't dislike comment. {ex.Message}" });

            throw;
        }
    }
}

// http://localhost:5049/api/postgrespost/getpost?id=51
// http://localhost:5049/api/postgrespost/getallposts
// http://localhost:5049/api/postgrespost/deletepost?id=1
// http://localhost:5049/api/postgrespost/addpost
// http://localhost:5049/api/postgrespost/getsubreddits
// http://localhost:5049/api/postgrespost/getusers
// http://localhost:5049/api/postgrespost/addcomment
// http://localhost:5049/api/postgrespost/likepost
