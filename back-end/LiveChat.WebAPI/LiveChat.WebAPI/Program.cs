using LiveChat.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adding required Services to the container.
builder.Services.AddApplicationDbContext(builder.Configuration);


var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
