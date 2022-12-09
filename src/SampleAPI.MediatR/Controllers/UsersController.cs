using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.Shared.Models.InputModels;
using System.Net.Mime;

namespace SampleAPI.MediatR.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController : ControllerBase
{
    private readonly IMediator mediator;

    public UsersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        try
        {
            var result = await mediator.Send(new GetUsersListQuery());

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        try
        {
            var result = await mediator.Send(new GetUserByIdQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(UserCreateInputModel request)
    {
        try
        {
            var result = await mediator.Send(new CreateUserCommand(request));

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync(UserEditInputModel request)
    {
        try
        {
            var result = await mediator.Send(new UpdateUserCommand(request));

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserAsync(UserDeleteInputModel request)
    {
        try
        {
            var result = await mediator.Send(new DeleteUserCommand(request));

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}