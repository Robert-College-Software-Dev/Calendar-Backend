using Microsoft.AspNetCore.Mvc;

public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public AuthDetails Auth { get; set; }
}

public class AuthDetails
{
    public string ClientId { get; set; }
    public string ApplicationId { get; set; }
}


[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly User _context; // Replace YourDbContext with your actual DbContext

    public UserController(User context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        try
        {
            // Save user to the database
            _context.Username.Add(user);

            return Ok(user); // Return the created user
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
}
