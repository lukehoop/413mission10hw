using Microsoft.EntityFrameworkCore;
using _413mission10hw.Data;

var builder = WebApplication.CreateBuilder(args);

// register mvc controllers for api routes
builder.Services.AddControllers();

// connect entity framework to the sqlite bowling database
builder.Services.AddDbContext<BowlingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingDb")));

// allow browser requests from the vite dev server on localhost and loopback
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins(
                       "http://localhost:5173",
                       "http://127.0.0.1:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// cors must run before routing maps controller endpoints
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();
