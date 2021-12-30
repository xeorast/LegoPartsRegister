using LegoPartsRegister.Data;
using LegoPartsRegister.Domain.Dtos.Color;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Api.Services;

public interface IColorsService
{
	Task<GetColorDto> CreateColor( CreateColorDto dto );
	Task DeleteColor( int id );
	Task<GetColorDto?> GetColor( int id );
	Task<GetColorDto[]> GetColors();
}

public class ColorsService : IColorsService
{
	private readonly AppDbContext _dbContext;

	public ColorsService( AppDbContext dbContext )
	{
		_dbContext = dbContext;
	}

	public async Task<GetColorDto[]> GetColors()
	{
		return await _dbContext.Colors
			.Select( GetColorDto.FromColorExp )
			.ToArrayAsync();
	}

	public async Task<GetColorDto?> GetColor( int id )
	{
		return await _dbContext.Colors
			.Where( c => c.Id == id )
			.Select( GetColorDto.FromColorExp )
			.FirstOrDefaultAsync();
	}

	public async Task<GetColorDto> CreateColor( CreateColorDto dto )
	{
		if ( await _dbContext.Colors.Where( c => c.Name == dto.Name ).AnyAsync() )
		{
			throw new ArgumentException( nameof( dto.Name ), nameof( dto ) );
		}
		if ( await _dbContext.Colors.Where( c => c.HexValue == dto.HexValue ).AnyAsync() )
		{
			throw new ArgumentException( nameof( dto.HexValue ), nameof( dto ) );
		}

		var color = dto.ToColor();

		_ = _dbContext.Colors.Add( color );
		_ = await _dbContext.SaveChangesAsync();

		return GetColorDto.FromColor( color );
	}

	public async Task DeleteColor( int id )
	{
		var color = await _dbContext.Colors
			.Where( c => c.Id == id )
			.FirstOrDefaultAsync();

		if ( color is null )
		{
			throw new ArgumentException( "", nameof( id ) );
		}

		_ = _dbContext.Colors.Remove( color );
		_ = await _dbContext.SaveChangesAsync();
	}
}
