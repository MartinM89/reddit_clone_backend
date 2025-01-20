using Microsoft.AspNetCore.Mvc;

// namespace test_project.Controllers;

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
            var user = FetchData.GetPost(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet]
    [Route("getallposts")]
    public IActionResult GetAllPosts()
    {
        try
        {
            var posts = FetchData.GetAllPosts();
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}

// http://localhost:5049/api/postgrespost/getpost?id=1
// http://localhost:5049/api/postgrespost/getallposts
