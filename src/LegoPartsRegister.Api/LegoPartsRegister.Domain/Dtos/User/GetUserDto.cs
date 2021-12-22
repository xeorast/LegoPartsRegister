using LegoPartsRegister.Domain.Models;
using System.Linq.Expressions;

namespace LegoPartsRegister.Domain.Dtos.User;

public class GetUserDto
{
#nullable disable warnings
	public string Uuid { get; set; }
	public string Username { get; set; }

#nullable restore

	public static Expression<Func<UserModel, GetUserDto>> FromUserExp => fromUserExp;
	static readonly Expression<Func<UserModel, GetUserDto>> fromUserExp = ( UserModel user ) => new GetUserDto()
	{
		Uuid = user.Uuid,
		Username = user.Username,
	};

	static readonly Func<UserModel, GetUserDto> fromUser = fromUserExp.Compile();
	public static GetUserDto FromUser( UserModel user )
	{
		return fromUser( user );
	}

}
