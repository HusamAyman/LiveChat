using LiveChat.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adding required Services to the container.
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.ConfigureJwtSettings(builder.Configuration);
builder.Services.AddServicesAndRepositories(builder.Configuration);
builder.Services.AddAuthentication();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
