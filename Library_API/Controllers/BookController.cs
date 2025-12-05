using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    [HttpGet("ping")]
    public string Ping()
    {
        return "Pong";
        return "Pong";
    }
    
}