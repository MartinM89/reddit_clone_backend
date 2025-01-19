using Microsoft.AspNetCore.Mvc;

// namespace test_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostgresUserController : ControllerBase
{
    [HttpGet]
    [Route("getuser")]
    public IActionResult GetUser(string email)
    {
        try
        {
            var user = FetchData.GetUser(email);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
