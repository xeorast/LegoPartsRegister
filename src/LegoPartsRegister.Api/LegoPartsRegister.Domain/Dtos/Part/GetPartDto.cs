using LegoPartsRegister.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace LegoPartsRegister.Domain.Dtos.Part;

public record GetPartDto
{
#nullable disable warnings
	[Required]
	public int Id { get; set; }

	[Required]
	[StringLength( 32 )]
	public string No { get; set; }

	[Required]
	[StringLength( 512 )]
	public string Name { get; set; }
#nullable restore

	public static Expression<Func<PartModel, GetPartDto>> FromPartExp => fromPartExp;
	static readonly Expression<Func<PartModel, GetPartDto>> fromPartExp = ( PartModel part ) => new GetPartDto()
	{
		Id = part.Id,
		No = part.No,
		Name = part.Name,
	};

	static readonly Func<PartModel, GetPartDto> fromPart = fromPartExp.Compile();
	public static GetPartDto FromPart( PartModel part )
	{
		return fromPart( part );
	}

}
