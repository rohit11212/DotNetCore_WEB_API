using MyBooks.Data.Model;
using MyBooks.Data.NewFolder;
using System.Threading;

namespace MyBooks.Data.Services
{
    public class BookService
    {
        private AppDBContext dBContext;
        public BookService(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Descripton = book.Descripton,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Price = book.Price,
                Genre = book.Genre,
                CoverURL = book.CoverURL,
                Author = book.Author,
                AddedDaste = DateTime.Now
            };

            dBContext.Books.Add(_book);
            dBContext.SaveChanges();
        }

        public List<Book> GetAllBooks() => dBContext.Books.ToList();

        public Book GetBookById(int id) => dBContext.Books.FirstOrDefault(x => x.Id == id);

        public Book UpdateBookId(int id, BookVM book)
        {
            var bookPresent = dBContext.Books.FirstOrDefault(c => c.Id == id);
            if (bookPresent != null)
            {
                bookPresent.Title = book.Title;
                bookPresent.Descripton = book.Descripton;
                bookPresent.IsRead = book.IsRead;
                bookPresent.DateRead = book.IsRead ? book.DateRead : null;
                bookPresent.Price = book.Price;
                bookPresent.Genre = book.Genre;
                bookPresent.CoverURL = book.CoverURL;
                bookPresent.Author = book.Author;

                dBContext.SaveChanges();
            }
            return bookPresent;

        }
        public void DeleteBookId(int id)
        {
            var bookPresent = dBContext.Books.FirstOrDefault(c => c.Id == id);
            if (bookPresent != null)
            {
                
                dBContext.Books.Remove(bookPresent);
                dBContext.SaveChanges();

            }
        }

    }
}
