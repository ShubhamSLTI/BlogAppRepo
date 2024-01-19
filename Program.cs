using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BlogAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}




//using Microsoft.EntityFrameworkCore;
//using System.Configuration;




//var builder = WebApplication.CreateBuilder(args);

////builder.Services.AddDbContext<AppDbContext>(options =>
////       options.UseSqlServer("Server=92RZXS3\\SQLEXPRESS;Database=BlogAppDB;Trusted_Connection=True;MultipleActiveResultSets=True;"));

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
