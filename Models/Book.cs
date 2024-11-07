using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book {
        public int Id {set; get;}
        public string Title {get; set;}
        public string Author {get; set;}

        public ICollection<ReadingSession> ReadingSessions {get; set;}

        [ColumnAttribute(TypeName = "nvarchar(20)")]
        public Ganre Ganre {get;set;}
    }


    public enum Ganre {
        FANTASY,
        ACTION,
        MYSTERY,
        HORROR,
        HISTORICAL,
        ROMANCE,
    }

}
