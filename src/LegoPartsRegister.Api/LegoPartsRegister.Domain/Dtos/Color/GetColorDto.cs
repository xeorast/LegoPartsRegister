using LegoPartsRegister.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace LegoPartsRegister.Domain.Dtos.Color;

public record GetColorDto
{
#nullable disable warnings
	public int Id { get; set; }

	[StringLength( 64 )]
	public string Name { get; set; }

	[StringLength( 6, MinimumLength = 6 )]
	public string HexValue { get; set; }
	public bool IsTrans { get; set; }
#nullable restore

	public static Expression<Func<ColorModel, GetColorDto>> FromColorExp => fromColorExp;
	static readonly Expression<Func<ColorModel, GetColorDto>> fromColorExp = ( ColorModel color ) => new GetColorDto()
	{
		Id = color.Id,
		Name = color.Name,
		HexValue = color.HexValue,
		IsTrans = color.IsTrans,
	};

	static readonly Func<ColorModel, GetColorDto> fromColor = fromColorExp.Compile();
	public static GetColorDto FromColor( ColorModel color )
	{
		return fromColor( color );
	}

}
