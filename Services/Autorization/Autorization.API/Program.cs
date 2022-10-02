using Authorization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddMvc();
services.AddEndpointsApiExplorer();

// Add API services
services.AddInfrastructureDependencies(builder.Configuration);

// Configure CORS Policy and Cookie
services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
{
    policy.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));
services.ConfigureApplicationCookie(options => {
    options.Cookie.SameSite = SameSiteMode.None;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
