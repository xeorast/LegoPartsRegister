using LegoPartsRegister.Domain.Relations;

namespace LegoPartsRegister.Domain.Dtos.Element;

public record CreateElementDto
{
#nullable disable warnings
	public string No { get; set; }
	public int PartId { get; set; }
	public int ColorId { get; set; }
#nullable restore

	public ElementModel ToElement()
	{
		return new ElementModel( No, PartId, ColorId );
	}

}
