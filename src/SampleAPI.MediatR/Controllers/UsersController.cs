using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.MediatR.BusinessLayer.Commands;
using SampleAPI.MediatR.BusinessLayer.Queries;
using SampleAPI.MediatR.Shared.Models.DTO;
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

            if (result.Count == 0)
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
    public async Task<IActionResult> CreateUserAsync(UserDTO request)
    {
        try
        {
            var result = await mediator.Send(new CreateUserCommand(request.Cognome, request.Nome, request.Telefono, request.Email));

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
    public async Task<IActionResult> UpdateUserAsync(UserDTO request)
    {
        try
        {
            var result = await mediator.Send(new UpdateUserCommand(request.Id, request.Cognome, request.Nome, request.Telefono, request.Email));

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
    public async Task<IActionResult> DeleteUserAsync(UserDTO request)
    {
        try
        {
            var result = await mediator.Send(new DeleteUserCommand(request.Id));

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