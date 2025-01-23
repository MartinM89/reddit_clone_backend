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
    public IActionResult AddPost(string title)
    {
        try
        {
            FetchPostService.AddPost(title);
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
}

// http://localhost:5049/api/postgrespost/getpost?id=1
// http://localhost:5049/api/postgrespost/getallposts
// http://localhost:5049/api/postgrespost/deletepost?id=1
// http://localhost:5049/api/postgrespost/addpost?title=New_Post
