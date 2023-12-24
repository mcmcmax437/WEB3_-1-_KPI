using Microsoft.EntityFrameworkCore;

namespace Lab5_WebApi
{
    public class Program
    {

        private const string connectionString = "server=127.0.0.1;user=root;password=Kukimyhund437*;database=HotelDB;port=3306";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.
            //builder.Services.AddMvc();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<Hotel_BAL.Interfaces.IRoomService, Hotel_BAL.Interface_Implementation.RoomService>();
            builder.Services.AddScoped<Hotel_DAL.Interfaces.IRoomRepository, Hotel_DAL.Interface_Imlementation.RoomRepository>();

            builder.Services.AddScoped<Hotel_BAL.Interfaces.IBookingService, Hotel_BAL.Interface_Implementation.BookingService>();
            builder.Services.AddScoped<Hotel_DAL.Interfaces.IBookingRepository, Hotel_DAL.Interface_Imlementation.BookingRepository>();


            // Assume you have access to DbContextOptionsBuilder optionsBuilder
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


            builder.Services.AddDbContext<Hotel_DAL.HotelContext>();

            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
