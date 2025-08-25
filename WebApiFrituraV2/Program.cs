using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiFrituraV2.Models;
using WebApiFrituraV2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext
builder.Services.AddDbContext<TiendaFriturasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"))
);

// Add services to the container
builder.Services.AddControllers();

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey")),
            ClockSkew = TimeSpan.Zero
        };
    });

// Configure Authorization Policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

// Add Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Redirection to Swagger UI if accessing root
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html", permanent: false);
        return;
    }
    await next();
});

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable Swagger
    app.UseSwaggerUI();  // Enable Swagger UI
}

app.UseHttpsRedirection();
app.UseFileLogging();
app.UseAuthentication();  // Add authentication middleware
app.UseAuthorization();  // Add authorization middleware
app.MapControllers();     // Map controllers

app.Run();

