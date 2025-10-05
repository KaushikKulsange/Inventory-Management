using AutoMapper;
using Inventory_Management_System.BusinessLogic.ILogic;
using Inventory_Management_System.BusinessLogic.Logic;
using Inventory_Management_System.BusinessLogic.Mappings;
using Inventory_Management_System.DataAccess.IRepository;
using Inventory_Management_System.DataAccess.Repository;
using Inventory_Management_System.DbConntext.Data;
using Inventory_Management_System_API.GlobalExceptionHandler;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();  // To Make Controller Discovered by ASP.NET Core
            builder.Services.AddDbContext<ProductDbContext>( options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));

            });
            builder.Services.AddAutoMapper(typeof(Mapclass));
            builder.Services.AddScoped<CustomExceptionHandler>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();

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


            app.UseMiddleware<CustomExceptionHandler>();
            app.MapControllers();

            app.Run();
        }
    }

}
