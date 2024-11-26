using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Context
	{
		[Key, ForeignKey("Book")]
		public int Id { get; set; }
		public required string Text { get; set; }
	}
}