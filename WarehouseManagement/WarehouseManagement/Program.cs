using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Data;
using WarehouseManagement.Repositories.Implementations;
using WarehouseManagement.Repositories.Interfaces;
using WarehouseManagement.Services.Implementations;
using WarehouseManagement.Services.Interfaces;

namespace WarehouseManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Mapping
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //repositories
            builder.Services.AddScoped<IStoreRepository, StoreRepository>();

            //services
            builder.Services.AddScoped<IStoreService, StoreService>();

            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1,0);

                options.AssumeDefaultVersionWhenUnspecified = true;

                options.ReportApiVersions = true;

                options.ApiVersionReader = new UrlSegmentApiVersionReader();

            }).AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });


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
