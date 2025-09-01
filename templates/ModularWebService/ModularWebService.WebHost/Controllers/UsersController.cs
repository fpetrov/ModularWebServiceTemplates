using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularWebService.Contracts.Users;

namespace ModularWebService.WebHost.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        GetUsersRequest request = new();
        List<UserDto> users = await mediator.Send(request);
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDto>> GetById(uint id)
    {
        GetUserRequest request = new(id);
        UserDto user = await mediator.Send(request);
        return Ok(user);
    }
}