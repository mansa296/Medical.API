using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Newtonsoft.Json.Converters;
using Medical.API.Registrations;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);



builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ConfigureHttpsDefaults(s =>
    {
        s.SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
    });
});

builder
    .Configuration
    .RegisterKeyVault();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});

builder.Services
    .AddEndpointsApiExplorer()
    .RegisterSwagger()
    .AddCors();

builder.Services
    .RegisterOptions(builder.Configuration)
    //.RegisterAuth(builder.Configuration)
    .RegisterRepositories()
    .RegisterDomains()
    .RegisterAdapters()
    .RegisterInfrastructure(builder.Configuration);

builder.Services.AddDistributedMemoryCache();

builder.Services.RegisterEntityFramework(builder.Configuration);

builder.Services.RegisterServices();

var app = builder.Build();

app.UseRegisteredSwagger();

app.RegisterMiddlewares();
app.UseHttpsRedirection();

app.UseCors(opts => opts.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();