using LiveChat.Infrastructure.DependencyInjection;
using LiveChat.WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Adding required Services to the container.
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.ConfigureJwtSettings(builder.Configuration);
builder.Services.AddServicesAndRepositories(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostDemo", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(_ => true) // allows file:// and anything
            .AllowCredentials();
    });
});
builder.Services.AddControllers();
builder.Services.AddSignalR();


var app = builder.Build();

/*app.UseHttpsRedirection();*/
app.UseCors("AllowLocalhostDemo");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("hubs/chat");
app.Run();
