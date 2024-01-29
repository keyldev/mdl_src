
using MailKit;
using MailService.Data;
using MailService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MailService
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


            // Dependency Injection for repo & service
            builder.Services.AddScoped<MailService.Services.IMailService, MailService.Services.MailService>(); 
            builder.Services.AddScoped<IMailRepository, MailRepository>();

            // Database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultString"), new MySqlServerVersion(new Version(8, 0, 32)));
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