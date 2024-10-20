using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Aqu� registra los repositorios para cada entidad
builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IBaseRepository<Movie>, MovieRepository>();
builder.Services.AddScoped<IBaseRepository<Director>, DirectorRepository>();
builder.Services.AddScoped<IBaseRepository<Membership>, MembershipRepository>();

// Aqu� registra los servicios para cada entidad
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IMembershipService, MembershipService>();

var app = builder.Build();

// Mover la ejecuci�n del comando PRAGMA dentro del pipeline de solicitudes.
app.Use(async (context, next) =>
{
    // Obt�n el contexto de la base de datos desde el servicio
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
        dbContext.Database.ExecuteSqlRaw("PRAGMA journal_mode = DELETE;");
    }

    await next(); // Contin�a con el pipeline de middleware
});

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
