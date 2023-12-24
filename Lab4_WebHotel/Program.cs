using Hotel_BAL.Interface_Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Lab4_WebHotel
{
    public class Program
    {
        private const string connectionString = "server=127.0.0.1;user=root;password=Kukimyhund437*;database=HotelDB;port=3306";
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.
            //builder.Services.AddMvc();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<Hotel_BAL.Interfaces.IRoomService, Hotel_BAL.Interface_Implementation.RoomService>();
            builder.Services.AddScoped<Hotel_DAL.Interfaces.IRoomRepository, Hotel_DAL.Interface_Imlementation.RoomRepository>();

            builder.Services.AddScoped<Hotel_BAL.Interfaces.IBookingService, Hotel_BAL.Interface_Implementation.BookingService>();
            builder.Services.AddScoped<Hotel_DAL.Interfaces.IBookingRepository, Hotel_DAL.Interface_Imlementation.BookingRepository>();


            // Assume you have access to DbContextOptionsBuilder optionsBuilder
            DbContextOptionsBuilder optionsBuilder  = new DbContextOptionsBuilder();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


            builder.Services.AddDbContext<Hotel_DAL.HotelContext>();
            
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())

            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
   
            app.UseEndpoints(endpoints =>
            {
                //Configuring the MVC middleware to the request processing pipeline
                endpoints.MapDefaultControllerRoute();
            });

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}