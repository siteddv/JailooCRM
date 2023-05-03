using JailooCRM;
using JailooCRM.DAL;
using Microsoft.AspNetCore.Diagnostics;
using System.Globalization;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PgContext>();
builder.Services.AddTransient<IRepository<Department, int>, Repository<Department, int>>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// -------------------------------------------------------------------------
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Use(async (context, next) =>
//{
//    context.Response.ContentType = "application/json";

//    await context.Response
//        .WriteAsync(new Response(
//            context.Response.StatusCode,
//            "poshel nahui",
//            false)
//        .ToString());
//    return;

//    await next();
//});

app.Run();