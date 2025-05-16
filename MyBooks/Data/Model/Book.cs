namespace MyBooks.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Price { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverURL { get; set; }
        public DateTime AddedDaste { get; set; }
    }
}
