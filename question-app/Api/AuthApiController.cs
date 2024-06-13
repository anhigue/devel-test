using Microsoft.AspNetCore.Mvc;
using question_app.Dto.Request;
using question_app.Dto.Response;

namespace question_app.Api;
public class AuthApiController : Controller {

    private readonly AppDbContext _context;

    public AuthApiController(AppDbContext context) {
        _context = context;
    }

    [HttpPost("api/auth/login")]
    public IActionResult login([FromBody] AuthRequest data) {
        // Check if user exists
        try
        {
            List<UserModel> users = _context.Users.ToList();
            foreach (UserModel user in users)
            {
                Console.WriteLine(user.username);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return Ok(new ApiResponse {
            IsOk = true,
            Message = "Login successful",
        });
    }

    [HttpPost("api/auth/logout")]
    public IActionResult logout() {
        return Ok();
    }

}