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
            Console.WriteLine(
                $"Received post data: Title={postData.Title}, UserName={postData.UserName}, SubRedditName={postData.SubRedditName}, Content={postData.Content}"
            );

            Console.WriteLine("Calling FetchPostService.AddPost");

            FetchPostService.AddPost(
                postData.Title,
                postData.UserName,
                postData.SubRedditName,
                postData.Content
            );

            Console.WriteLine("Post added successfully");

            return Ok(new { Message = "Post added" });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding post: {ex.Message}");
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
}

// http://localhost:5049/api/postgrespost/getpost?id=1
// http://localhost:5049/api/postgrespost/getallposts
// http://localhost:5049/api/postgrespost/deletepost?id=1
// http://localhost:5049/api/postgrespost/addpost
// http://localhost:5049/api/postgrespost/getsubreddits
