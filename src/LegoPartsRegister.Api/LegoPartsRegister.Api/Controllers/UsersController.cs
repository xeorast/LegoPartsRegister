using LegoPartsRegister.Domain.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegoPartsRegister.Api.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class UsersController : ControllerBase
{
	private readonly IUsersService _usersService;

	public UsersController( IUsersService usersService )
	{
		_usersService = usersService;
	}

	[HttpGet]
	public async Task<ActionResult<GetUserDto[]>> GetUsers()
	{
		return await _usersService.GetUsers();
	}

	[HttpGet( "{uuid}" )]
	public async Task<ActionResult<GetUserDto>> GetUser( string uuid )
	{
		var user = await _usersService.GetUser( uuid );
		if ( user is null )
		{
			return NotFound();
		}

		return user;
	}

	[HttpPost]
	public async Task<ActionResult<GetUserDto>> CreateUser( [FromBody] CreateUserDto dto )
	{
		try
		{
			var user = await _usersService.CreateUser( dto );
			return user;
		}
		catch ( ArgumentException )
		{
			return BadRequest( "username taken" );
		}

	}

	[HttpDelete( "{uuid}" )]
	public async Task<IActionResult> DeleteUser( string uuid )
	{
		try
		{
			await _usersService.DeleteUser( uuid );
		}
		catch ( ArgumentException )
		{
			return NotFound();
		}

		return NoContent();
	}

}
