using DigiBite_Api.Configurations;
using DigiBite_Api.DependencyInjection;
using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.Filter;
using DigiBite_Core.IServices;
using DigiBite_Core.Middleware;
using DigiBite_Core.Models.Entities;
using DigiBite_Infra.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(c => c.Filters.Add<ApiResponseFilter>());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

//Add Scoped
builder.Services.AddMultiScoped();
//Email Sender Service
builder.Services.AddTransient<IEmailService, EmailService>();

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
    op.SignIn.RequireConfirmedPhoneNumber = false;
    op.SignIn.RequireConfirmedAccount = true;
    op.SignIn.RequireConfirmedEmail = true;
})
 .AddEntityFrameworkStores<DigiBiteContext>()
 .AddSignInManager<SignInManager<AppUser>>()
 .AddUserManager<UserManager<AppUser>>()
 .AddDefaultTokenProviders();


//Add Custom Jwt Authentication
builder.Services.AddCustomJwtAuth(builder.Configuration);

//Add Authorization Policies
builder.Services.AddAuthorization(o =>
{
    foreach (var claim in RoleClaim.Claims)
        o.AddPolicy(claim.Key, policy => policy.RequireClaim(claim.Key, "true"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "DigiBite V1"));
}

app.UseHttpsRedirection();

// Enable serving static files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads")),
    RequestPath = "/Uploads" // URL path to access the static files
});

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<LanguageMiddleware>();
app.MapControllers();

app.Run();
