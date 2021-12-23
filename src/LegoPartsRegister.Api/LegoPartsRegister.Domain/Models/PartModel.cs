using System.ComponentModel.DataAnnotations;

namespace LegoPartsRegister.Domain.Models;

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

}
