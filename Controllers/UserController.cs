using Microsoft.AspNetCore.Mvc;
using WebAPI.DBContext;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<UserController> _logger;
    private readonly DatabaseContext _databaseContext;
    public UserController(ILogger<UserController> logger, DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _databaseContext.Users.ToList();
        return Ok(new{result = users,message = "success"});
    }
    [HttpPost]
    public IActionResult AddUsers(User user)
    {
        var users = _databaseContext.Add(user);
        _databaseContext.SaveChanges();
        return Ok(new{message = "success"});
    }
    [HttpPut]
    public IActionResult UpdateUsers(User user)
    {
        var users = _databaseContext.Update(user);
        _databaseContext.SaveChanges();
        return Ok(new{message = "success"});
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUsers(int id)
    {
        var user = _databaseContext.Users.SingleOrDefault(o => o.Id == id);
        if(user != null)
        {
        var users = _databaseContext.Remove(user);
        _databaseContext.SaveChanges();
        }
        return Ok(new{message = "success"});
        
    }
}
