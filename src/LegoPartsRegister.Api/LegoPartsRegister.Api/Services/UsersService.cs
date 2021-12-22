using LegoPartsRegister.Data;
using LegoPartsRegister.Domain.Dtos.User;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Api.Services;

public interface IUsersService
{
	Task<GetUserDto?> GetUser( string uuid );
	Task<GetUserDto[]> GetUsers();
	Task<GetUserDto> CreateUser( CreateUserDto dto );
	Task DeleteUser( string uuid );
}

public class UsersService : IUsersService
{
	private readonly AppDbContext _dbContext;

	public UsersService( AppDbContext dbContext )
	{
		_dbContext = dbContext;
	}

	public async Task<GetUserDto[]> GetUsers()
	{
		return await _dbContext.Users
			.Select( GetUserDto.FromUserExp )
			.ToArrayAsync();
	}

	public async Task<GetUserDto?> GetUser( string uuid )
	{
		return await _dbContext.Users
			.Where( u => u.Uuid == uuid )
			.Select( GetUserDto.FromUserExp )
			.FirstOrDefaultAsync();
	}

	public async Task<GetUserDto> CreateUser( CreateUserDto dto )
	{
		if ( await _dbContext.Users.Where(u=>u.Username ==dto.Username).AnyAsync() )
		{
			throw new ArgumentException();
		}

		var user = dto.ToUser( await GenerateUuid(), dto.Password );

		_ = _dbContext.Users.Add( user );
		_ = await _dbContext.SaveChangesAsync();

		return GetUserDto.FromUser( user );
	}

	public async Task DeleteUser( string uuid )
	{
		var user = await _dbContext.Users
			.Where( u => u.Uuid == uuid )
			.FirstOrDefaultAsync();

		if ( user is null )
		{
			throw new ArgumentException( "", nameof( uuid ) );
		}

		_ = _dbContext.Users.Remove( user );
		_ = await _dbContext.SaveChangesAsync();
	}


	private async Task<string> GenerateUuid()
	{
		string uuid;
		do
		{
			var guid = Guid.NewGuid();
			uuid = Base64UrlTextEncoder.Encode( guid.ToByteArray() );

		} while ( await _dbContext.Users.Where( u => u.Uuid == uuid ).AnyAsync() );

		return uuid;
	}

}
