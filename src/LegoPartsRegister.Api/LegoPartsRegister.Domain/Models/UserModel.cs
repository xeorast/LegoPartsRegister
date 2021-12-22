using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LegoPartsRegister.Domain.Models;

[Index( nameof( Uuid ), IsUnique = true )]
[Index( nameof( Username ), IsUnique = true )]
public class UserModel
{
	public UserModel( string uuid, string username, string passwordHash )
	{
		Uuid = uuid;
		Username = username;
		PasswordHash = passwordHash;
	}

	public int Id { get; set; }

	[StringLength( 24, MinimumLength = 24 )]
	public string Uuid { get; set; }

	[StringLength( 32, MinimumLength = 3 )]
	public string Username { get; set; }

	public string PasswordHash { get; set; }

}
