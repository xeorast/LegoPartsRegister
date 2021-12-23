using LegoPartsRegister.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Domain.Relations;

[Index( nameof( No ), IsUnique = true )]
[Index( nameof( PartId ), nameof( ColorId ), IsUnique = true )]
public class ElementModel
{
	public ElementModel( string no, int partId, int colorId )
	{
		No = no;
		PartId = partId;
		ColorId = colorId;
	}

	public int Id { get; set; }
	public string No { get; set; }
	public int PartId { get; set; }
	public int ColorId { get; set; }

	public PartModel? Part { get; set; }
	public ColorModel? Color { get; set; }
}
