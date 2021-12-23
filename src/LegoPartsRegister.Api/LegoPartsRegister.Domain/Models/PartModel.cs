using LegoPartsRegister.Domain.Relations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LegoPartsRegister.Domain.Models;

[Index( nameof( No ), IsUnique = true )]
[Index( nameof( Name ) )]
public class PartModel
{
	public PartModel( string no, string name )
	{
		No = no;
		Name = name;
	}

	public int Id { get; set; }

	[StringLength( 32 )]
	public string No { get; set; }

	[StringLength( 512 )]
	public string Name { get; set; }

	public List<ColorModel>? Colors { get; set; }
	public List<ElementModel>? Elements { get; set; }
}
