
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Concete;
using Services.Interfaces;
using System.Text;
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

            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = new TimeSpan(0,20,0),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    // this should tru if we use IDP its a diff application.
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("60cace8f-bc24-47cb-bb12-ebceba73220b"))
                };
            }
            );


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

            app.UseAuthentication(); // this line is used to enable authentication in the API and it should be placed before UseAuthorization() method
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
