
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Concete;
using Services.Interfaces;
using ViewModels.Request;

namespace CrudAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();  // This line is requried to run comtroller files as controller

            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true; // this line is used to include the supported API versions in the response headers
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1.0);  // this line is used to set the default API version to 1.0
                options.AssumeDefaultVersionWhenUnspecified = true; // this line is used to set the default version of the API when the client does not specify a version in the request
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddTransient<IProductService, ProductService>(); // This line is used to register the service and interface for DI (Dependency Injection) in the API layer


            // to add validation
            builder.Services.AddScoped<IValidator<AddProductRequest>, AddProductRequestValidator>(); // this line is used to register the validator for AddProductRequest class and
                                                                                                     // IValidator is the interface provided by FluentValidation library and
                                                                                                     // AddProductRequestValidator is the class which we have created to validate the AddProductRequest model

            string connectionString = builder.Configuration.GetConnectionString("ConCrudApiDBContext"); // this line is used to get the connection string from appsettings.json file

            builder.Services.AddDbContext<CrudApiDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }); // after this we need to run migrations to create DB

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();  // This line is used to redirect http request to https request

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
