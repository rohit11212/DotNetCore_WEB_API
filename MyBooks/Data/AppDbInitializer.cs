using MyBooks.Data.Model;

namespace MyBooks.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Book 1",
                        Descripton = "Demo Book",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Price = 50,
                        Genre = "Self",
                        CoverURL = "www.Google.com",
                        AddedDaste = DateTime.Now,
                        Author = "Mani"
                    },

                    new Book()
                    {
                        Title = "Book 2",
                        Descripton = "Demo Book 2",
                        IsRead = false,
                        Price = 540,
                        Genre = "Horror",
                        CoverURL = "www.Horror.com",
                        AddedDaste = DateTime.Now,
                        Author = "Rohit"
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
