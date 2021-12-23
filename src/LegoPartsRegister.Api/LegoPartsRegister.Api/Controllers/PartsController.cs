using LegoPartsRegister.Domain.Dtos.Part;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegoPartsRegister.Api.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class PartsController : ControllerBase
{
	private readonly IPartsService _partsService;

	public PartsController( IPartsService partsService )
	{
		_partsService = partsService;
	}

	[HttpGet]
	public async Task<ActionResult<GetPartDto[]>> GetParts()
	{
		return await _partsService.GetParts();
	}

	[HttpGet( "{no}" )]
	public async Task<ActionResult<GetPartDto>> GetPart( string no )
	{
		var part = await _partsService.GetPart( no );
		if ( part is null )
		{
			return NotFound();
		}

		return part;
	}

	[HttpPost]
	public async Task<ActionResult<GetPartDto>> CreatePart( [FromBody] CreatePartDto dto )
	{
		try
		{
			var part = await _partsService.CreatePart( dto );
			return part;
		}
		catch ( ArgumentException )
		{
			return BadRequest( "part already exists" );
		}

	}

	[HttpDelete( "{no}" )]
	public async Task<IActionResult> DeletePart( string no )
	{
		try
		{
			await _partsService.DeletePart( no );
		}
		catch ( ArgumentException )
		{
			return NotFound();
		}

		return NoContent();
	}


}
