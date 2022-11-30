using API_Alunos.Context;
using API_Alunos.Repositorio;
using API_Alunos.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Obter a string de conexão com o banco de dadosdo arquivo appsettings.json
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(
                   options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
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