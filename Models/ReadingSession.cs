namespace Library.Models {
    public class ReadingSession {
        public int Id {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime? EndTime {get;set;}
        public User User {get;set;}
        public int UserId {get;set;}
        public Book Book {get;set;}
        public int BookId {get;set;}

        public Status Status {get;set;}

    }


    public enum Status {
        READING,
        FINISHED,
    }
}
