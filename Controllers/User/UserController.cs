using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    
    
    [HttpPost]
    [Route("register")]
    public string Register(Http.Requests.User.User user)
    {
         return "ok";
        // return useCase.Execute(user);
    }
}