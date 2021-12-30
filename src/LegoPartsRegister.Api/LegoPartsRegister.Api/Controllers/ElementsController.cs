using LegoPartsRegister.Domain.Dtos.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegoPartsRegister.Api.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class ElementsController : ControllerBase
{
	private readonly IElementsService _elementsService;

	public ElementsController( IElementsService elementsService )
	{
		_elementsService = elementsService;
	}

	[HttpGet]
	public async Task<ActionResult<GetElementDto[]>> GetElements()
	{
		return await _elementsService.GetElements();
	}

	[HttpGet( "{id}" )]
	public async Task<ActionResult<GetElementDto>> GetElement( int id )
	{
		var element = await _elementsService.GetElement( id );
		if ( element is null )
		{
			return NotFound();
		}

		return element;
	}

	[HttpPost]
	public async Task<ActionResult<GetElementDto>> CreateElement( [FromBody] CreateElementDto dto )
	{
		try
		{
			var element = await _elementsService.CreateElement( dto );

			return CreatedAtAction( nameof( GetElement ), new { id = element.Id }, element );
		}
		catch ( ArgumentException e )
		{
			return Conflict( $"there already exists element with given {e.Message}" );
		}

	}

	[HttpDelete( "{id}" )]
	public async Task<IActionResult> DeleteElement( int id )
	{
		try
		{
			await _elementsService.DeleteElement( id );
		}
		catch ( ArgumentException )
		{
			return NotFound();
		}

		return NoContent();
	}

}
