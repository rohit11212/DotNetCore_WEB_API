using Microsoft.EntityFrameworkCore;
using MyBooks.Data;
using MyBooks.Data.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddDbContext<AppDBContext>(o =>
        {
            string connStr = builder.Configuration.GetConnectionString("DefaultConnectionString");
            o.UseSqlServer(connStr);
        });

        builder.Services.AddTransient<BookService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen
            (c => { c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RohitBooks", Version = "v2" }); });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "RohitBooks_V2"));
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        AppDbInitializer.Seed(app);
        app.Run();
    }
}