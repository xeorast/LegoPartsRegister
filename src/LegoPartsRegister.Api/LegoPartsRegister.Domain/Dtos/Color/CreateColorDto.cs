using LegoPartsRegister.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace LegoPartsRegister.Domain.Dtos.Color;

public class CreateColorDto
{
#nullable disable warnings
	[StringLength( 64 )]
	public string Name { get; set; }

	[StringLength( 6, MinimumLength = 6 )]
	public string HexValue { get; set; }
	public bool IsTrans { get; set; }
#nullable restore

	public ColorModel ToColor()
	{
		return new ColorModel( Name, HexValue );
	}
}
