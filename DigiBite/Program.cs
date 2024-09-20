using DigiBite_Api.Configurations;
using DigiBite_Core.Context;
using DigiBite_Core.Middleware;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Scoped
builder.Services.AddMultiScoped();

//DbContext Config
builder.Services.AddDbContext<DigiBiteContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

//CORS
builder.Services.AddCors();

//Identity Config
builder.Services.AddIdentity<AppUser, IdentityRole>(op =>
{
    op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    op.User.RequireUniqueEmail = true;

})
 .AddEntityFrameworkStores<DigiBiteContext>()
 .AddSignInManager<SignInManager<AppUser>>()
 .AddUserManager<UserManager<AppUser>>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<LanguageMiddleware>();
app.MapControllers();

app.Run();
