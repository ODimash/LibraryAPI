using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

		[Required, MinLength(128)]
		public required string Description { get; set; }

		[Required]
		public required Context Context { get; set; }

		[Required]
		public required string Cover { get; set; }

		public required int RatingCount { get; set; } = 0;
		public required int Rating { get; set; } = 5;

		[JsonIgnore]
		[Required, MaxLength(128)]
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
