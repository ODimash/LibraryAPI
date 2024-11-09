using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Book
	{
		[Key]
		public int Id { set; get; }

		[Required, MaxLength(128)]
		public required string Title { get; set; }

		[Required, MaxLength(128)]
		public required string Author { get; set; }

		public ICollection<ReadingSession>? ReadingSessions { get; set; }

		[Column(TypeName = "varchar(20)")]
		public Ganre Ganre { get; set; }
	}


	public enum Ganre
	{
		FANTASY,
		ACTION,
		MYSTERY,
		HORROR,
		HISTORICAL,
		ROMANCE,
	}

}
