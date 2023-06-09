using JailooCRM;
using JailooCRM.BLL;
using JailooCRM.DAL;
using JailooCRM.DAL.Common;
using JailooCRM.DAL.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PgContext>();
builder.Services.AddScoped<IRepository<Department, int>, Repository<Department, int>>();
builder.Services.AddScoped<IRepository<Subcategory, int>, Repository<Subcategory, int>>();
builder.Services.AddScoped<IRepository<Log, int>, Repository<Log, int>>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddTransient<AuthManager>();
builder.Services.AddControllers();
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<PgContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var jwtsection = config.GetSection(nameof(JwtSettings));
builder.Services.Configure<JwtSettings>(jwtsection);
var jwtsettings = jwtsection.Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtsettings.Issuer,
        ValidAudience = jwtsettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings.Key))
    };
});

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
app.UseAuthentication();
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