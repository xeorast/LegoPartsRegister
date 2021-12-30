using LegoPartsRegister.Domain.Relations;
using System.Linq.Expressions;

namespace LegoPartsRegister.Domain.Dtos.Element;

public record GetElementDto
{
#nullable disable warnings
	public int Id { get; set; }
	public string No { get; set; }
	public int PartId { get; set; }
	public int ColorId { get; set; }
#nullable restore

	public static Expression<Func<ElementModel, GetElementDto>> FromElementExp => fromElementExp;
	static readonly Expression<Func<ElementModel, GetElementDto>> fromElementExp = ( ElementModel element ) => new GetElementDto()
	{
		Id = element.Id,
		No = element.No,
		PartId = element.PartId,
		ColorId = element.ColorId,
	};

	static readonly Func<ElementModel, GetElementDto> fromElement = fromElementExp.Compile();
	public static GetElementDto FromElement( ElementModel element )
	{
		return fromElement( element );
	}
}
