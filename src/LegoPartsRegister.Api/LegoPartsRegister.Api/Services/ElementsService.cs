using LegoPartsRegister.Data;
using LegoPartsRegister.Domain.Dtos.Element;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Api.Services;

public interface IElementsService
{
	Task<GetElementDto[]> GetElements();
	Task<GetElementDto?> GetElement( int id );
	Task DeleteElement( int id );
	Task<GetElementDto> CreateElement( CreateElementDto dto );
}

public class ElementsService : IElementsService
{
	private readonly AppDbContext _dbContext;

	public ElementsService( AppDbContext dbContext )
	{
		_dbContext = dbContext;
	}

	public async Task<GetElementDto[]> GetElements()
	{
		return await _dbContext.Elements
			.Select( GetElementDto.FromElementExp )
			.ToArrayAsync();
	}

	public async Task<GetElementDto?> GetElement( int id )
	{
		return await _dbContext.Elements
			.Where( e => e.Id == id )
			.Select( GetElementDto.FromElementExp )
			.FirstOrDefaultAsync();
	}

	public async Task<GetElementDto> CreateElement( CreateElementDto dto )
	{
		if ( await _dbContext.Elements.Where( e => e.No == dto.No ).AnyAsync() )
		{
			throw new ArgumentException( nameof( dto.No ), nameof( dto ) );
		}
		if ( await _dbContext.Elements.Where( e => e.PartId == dto.PartId && e.ColorId == dto.ColorId ).AnyAsync() )
		{
			throw new ArgumentException( $"{nameof( dto.PartId )}, {nameof( dto.ColorId )}", nameof( dto ) );
		}

		var element = dto.ToElement();

		_ = _dbContext.Elements.Add( element );
		_ = await _dbContext.SaveChangesAsync();

		return GetElementDto.FromElement( element );
	}

	public async Task DeleteElement( int id )
	{
		var element = await _dbContext.Elements
			.Where( e => e.Id == id )
			.FirstOrDefaultAsync();

		if ( element is null )
		{
			throw new ArgumentException( "", nameof( id ) );
		}

		_ = _dbContext.Elements.Remove( element );
		_ = await _dbContext.SaveChangesAsync();
	}
}
