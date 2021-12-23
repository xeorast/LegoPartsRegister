using LegoPartsRegister.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace LegoPartsRegister.Domain.Dtos.Part;

public record CreatePartDto
{
#nullable disable warnings
	[Required]
	[StringLength( 32 )]
	public string No { get; set; }

	[Required]
	[StringLength( 512 )]
	public string Name { get; set; }
#nullable restore

	public PartModel ToPart()
	{
		return new PartModel( No, Name );
	}

}
