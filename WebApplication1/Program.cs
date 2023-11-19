using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var securityKey = new byte[32];
using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
{
    rng.GetBytes(securityKey);
}
var base64Secret = Convert.ToBase64String(securityKey);

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IVolunteersService, VolunteersService>();
builder.Services.AddScoped<IMembersServices, MembersServices>();
builder.Services.AddScoped<INewsService, NewsService>();


builder.Services.AddDbContext<ServiceContext>(
options =>
options.UseSqlServer("name=ConnectionStrings:ServiceContext"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAll");
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
