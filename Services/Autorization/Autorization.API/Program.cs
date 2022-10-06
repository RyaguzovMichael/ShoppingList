using Authorization.API;
using Authorization.Application;
using Authorization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddMvc();
services.AddEndpointsApiExplorer();

// Configure Automapper
services.SetAutomapperProfiles();

// Configure JWT token
services.SetJwtTokenServices(builder.Configuration);

// Add API services
services.AddInfrastructureDependencies(builder.Configuration);
services.AddApplicationsServices();

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
app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["jwt"];
    if (!string.IsNullOrEmpty(token))
        context.Request.Headers.Add("Authorization", "Bearer " + token);

    await next();
});
app.UseAuthentication();
app.UseAuthorization();

app.Run();
