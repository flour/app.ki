using AppKi.Business;
using Flour.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

builder.Services
    .AddControllers().Services
    .AddBusiness(builder.Configuration)
    .AddSpaStaticFiles(e => e.RootPath = "dist");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
#pragma warning disable ASP0014
app.UseEndpoints(_ => { });
#pragma warning restore ASP0014
app.Use((ctx, next) =>
{
    if (!ctx.Request.Path.StartsWithSegments("/api") &&
        !ctx.Request.Path.StartsWithSegments("/files") &&
        !ctx.Request.Path.StartsWithSegments("/swagger")) return next();
    ctx.Response.StatusCode = 404;
    return Task.CompletedTask;
});
app.UseSpaStaticFiles();
app.UseSpa(spa =>
{
    if (builder.Environment.IsDevelopment())
        spa.UseProxyToSpaDevelopmentServer("http://127.0.0.1:3001");
});

app.MapControllers();
app.Run();