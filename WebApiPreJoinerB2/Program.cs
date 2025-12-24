
using Asp.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;

namespace WebApiPreJoinerB2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<APIDAL.Models.AppDatabase>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<APIDAL.Interfaces.IBook, APIDAL.Repos.BookRepo>();
            builder.Services.AddScoped<APIDAL.Interfaces.IUser, APIDAL.Repos.UserRepo>();



            // versioning 
            // middleware confi

            //api versioning dependency
            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true; // if no version is specied the application will exe default method 

                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0); // if verison id specid this will execute

                options.ReportApiVersions = true;  // responce header inluces supported version
            }).AddMvc(o =>
            {
                o.Conventions.Add(new VersionByNamespaceConvention()); //version controller based on their namespace
            }).AddApiExplorer(x =>
            {
                x.GroupNameFormat = "'v'V";
                x.SubstituteApiVersionInUrl = true; // this helpful for swagger
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
