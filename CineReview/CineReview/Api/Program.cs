//using System;
//using CineReview.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

//namespace CineReview
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //var builder = WebApplication.CreateBuilder(args);
//            //builder.Services.AddDbContext<CineReviewContext>(options =>
//            // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//            ////var app = builder.Build();

//            //builder.Services.AddHttpsRedirection(options =>
//            //{
//            //    options.HttpsPort = 5001;
//            //});

//            //builder.Services.AddEndpointsApiExplorer();
//            //builder.Services.AddSwaggerGen();


//            //var app = builder.Build();

//            //if (app.Environment.IsDevelopment())
//            //{
//            //    app.UseSwagger();
//            //    app.UseSwaggerUI();
//            //}


//            //// Middleware para HTTPS
//            //app.UseHttpsRedirection();

//            //// Rota simples para testar
//            //app.MapGet("/", () => "Rodando em HTTPS 🚀");

//            //// Inicia o servidor
//            //app.Run();









//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddDbContext<CineReviewContext>(options =>
//            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();

//            app.MapControllers();

//            app.Run();
//        }
//    }
//}


using CineReview.Application.Service;
using CineReview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configurando HttpClient para TmdbService

builder.Services.AddHttpClient();

// Registrando as services
builder.Services.AddScoped<TmdbService>();
builder.Services.AddScoped<FilmeService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<SerieService>();
builder.Services.AddScoped<MidiaService>();
builder.Services.AddScoped<FavoritoService>();
builder.Services.AddScoped<AvaliacaoService>();





// Adicionando o DbContext ao contêiner de serviços
builder.Services.AddDbContext<CineReviewContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


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