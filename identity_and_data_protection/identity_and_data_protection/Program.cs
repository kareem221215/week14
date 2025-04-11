
using identity_and_data_protection.Entity;
using Microsoft.AspNetCore.Identity;
using identity_and_data_protection.Data; 
using Microsoft.EntityFrameworkCore;

namespace identity_and_data_protection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();


            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();


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
