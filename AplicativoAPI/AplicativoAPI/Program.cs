
using AplicativoAPI.Persistence;
using AplicativoAPI.Persistence.Repositories;
using AplicativoAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AplicativoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string mySqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            //verifique a versão do servidor MySql e coloque aqui o que estará fazendo uso
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

            builder.Services.AddDbContext<TutoringDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(stringConnection, serverVersion));

            //ainda devo colocar para encontrar a versão automaticamente
            //builder.Services.AddDbContext<TutoringDbContext>(options =>
            //options.UseMySql(ServerVersion.AutoDetect(mySqlConnectionString)));

            builder.Services.AddScoped(typeof(ITutoringRepository<>), typeof(TutoringRepository<>));

            builder.Services.AddScoped(typeof(ITutoringService<>), typeof(TutoringService<>));
            

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