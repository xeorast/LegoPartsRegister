using LegoPartsRegister.Domain.Relations;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Domain.Models;

[Index( nameof( Name ), IsUnique = true )]
[Index( nameof( HexValue ), IsUnique = true )]
public class ColorModel
{
	public ColorModel( string name, string hexValue )
	{
		Name = name;
		HexValue = hexValue;
	}

	public int Id { get; set; }
	public string Name { get; set; }
	public string HexValue { get; set; }
	public bool IsTrans { get; set; }

	public List<PartModel>? Parts { get; set; }
	public List<ElementModel>? Elements { get; set; }
}
