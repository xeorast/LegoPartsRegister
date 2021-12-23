using LegoPartsRegister.Data;
using LegoPartsRegister.Domain.Dtos.Part;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Api.Services;

public interface IPartsService
{
	Task<GetPartDto[]> GetParts();
	Task<GetPartDto?> GetPart( string no );
	Task<GetPartDto> CreatePart( CreatePartDto dto );
	Task DeletePart( string no );
}

public class PartsService : IPartsService
{
	private readonly AppDbContext _dbContext;

	public PartsService( AppDbContext dbContext )
	{
		_dbContext = dbContext;
	}

	public async Task<GetPartDto[]> GetParts()
	{
		return await _dbContext.Parts
			.Select( GetPartDto.FromPartExp )
			.ToArrayAsync();
	}

	public async Task<GetPartDto?> GetPart( string no )
	{
		return await _dbContext.Parts
			.Where( p => p.No == no )
			.Select( GetPartDto.FromPartExp )
			.FirstOrDefaultAsync();
	}

	public async Task<GetPartDto> CreatePart( CreatePartDto dto )
	{
		if ( await _dbContext.Parts.Where( p => p.No == dto.No ).AnyAsync() )
		{
			throw new ArgumentException( nameof( dto.No ), nameof( dto ) );
		}

		var part = dto.ToPart();

		_ = _dbContext.Parts.Add( part );
		_ = await _dbContext.SaveChangesAsync();

		return GetPartDto.FromPart( part );
	}

	public async Task DeletePart( string no )
	{
		var part = await _dbContext.Parts
			.Where( p => p.No == no )
			.FirstOrDefaultAsync();

		if ( part is null )
		{
			throw new ArgumentException( "", nameof( no ) );
		}

		_ = _dbContext.Parts.Remove( part );
		_ = await _dbContext.SaveChangesAsync();
	}


}
