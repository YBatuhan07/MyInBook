using Microsoft.EntityFrameworkCore;
using MyInBook.Business.Abstract;
using MyInBook.Business.Concrete;
using MyInBook.Data;
using MyInBook.Data.Repositories.BookRepositories;

namespace MyInBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IBookService,BookService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddDbContext<MyInBookDatabaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConntection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
