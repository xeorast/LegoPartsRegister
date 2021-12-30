using LegoPartsRegister.Domain.Dtos.Color;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegoPartsRegister.Api.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class ColorsController : ControllerBase
{
	private readonly IColorsService _colorsService;

	public ColorsController( IColorsService colorsService )
	{
		_colorsService = colorsService;
	}

	[HttpGet]
	public async Task<ActionResult<GetColorDto[]>> GetColors()
	{
		return await _colorsService.GetColors();
	}

	[HttpGet( "{id}" )]
	public async Task<ActionResult<GetColorDto>> GetColor( int id )
	{
		var color = await _colorsService.GetColor( id );
		if ( color is null )
		{
			return NotFound();
		}

		return color;
	}

	[HttpPost]
	public async Task<ActionResult<GetColorDto>> CreateColor( [FromBody] CreateColorDto dto )
	{
		try
		{
			var color = await _colorsService.CreateColor( dto );
			return color;
		}
		catch ( ArgumentException e )
		{
			return BadRequest( $"color with given {e.Message} already exists" );
		}

	}

	[HttpDelete( "{id}" )]
	public async Task<IActionResult> DeleteColor( int id )
	{
		try
		{
			await _colorsService.DeleteColor( id );
		}
		catch ( ArgumentException )
		{
			return NotFound();
		}

		return NoContent();
	}


}
