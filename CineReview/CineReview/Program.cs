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


using System;
using CineReview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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