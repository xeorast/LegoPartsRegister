using LegoPartsRegister.Domain.Models;

namespace LegoPartsRegister.Domain.Dtos.User;

public class CreateUserDto
{
#nullable disable warnings
	public string Username { get; set; }
	public string Password { get; set; }
#nullable restore

	public UserModel ToUser( string uuid, string passwordHash )
	{
		return new( uuid, Username, passwordHash );
	}

}
