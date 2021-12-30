using LegoPartsRegister.Domain.Relations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

	[StringLength( 64 )]
	public string Name { get; set; }

	[StringLength( 6, MinimumLength = 6 )]
	public string HexValue { get; set; }
	public bool IsTrans { get; set; }

	public List<PartModel>? Parts { get; set; }
	public List<ElementModel>? Elements { get; set; }
}
