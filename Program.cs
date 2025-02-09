using EssentialsSupps_Backend.Infrastructure.Config;
using EssentialsSupps_Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Services
DependencyInjection.ConfigureServices(builder.Services, builder.Configuration);

// Production's Database Connection
builder.Configuration.AddEnvironmentVariables();


// Connection to Database
builder.Services.AddDbContext<EssentialsSuppsdbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI( c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ejemplo de API"));
app.MapControllers();
app.Run();