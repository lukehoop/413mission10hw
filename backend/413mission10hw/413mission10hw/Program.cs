using Microsoft.EntityFrameworkCore;
using _413mission10hw.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext with SQLite
builder.Services.AddDbContext<BowlingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingDb")));

// Add CORS - allow React app on Vite default port 5173
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowReactApp"); // Make sure this is before MapControllers
app.UseAuthorization();
app.MapControllers();

app.Run();